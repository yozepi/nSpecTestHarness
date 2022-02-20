namespace yozepi.nespec.core
{
    using NSpec;
    using NSpec.Domain;
    using NSpec.Domain.Formatters;
    using yozepi.nspec.core.tools;

    public abstract class nSpecTestHarness : NSpec.nspec
    {
        #region properties

        protected internal string? Tags { get; set; }
        protected internal IFormatter Formatter { get; set; }
        protected bool FailFast { get; set; }
        internal Func<Type[]>? specFinder { get; set; }
        private ISpecResultAssertions SpecAssertions { get; }

        #endregion //properties


        #region constructor

        public nSpecTestHarness(ISpecResultAssertions specAssertions)
        {
            this.SpecAssertions = specAssertions;
            this.Formatter = new ConsoleFormatter();
        }

        #endregion //constructor

        #region protected methods

        protected internal void LoadSpecs(Func<Type[]>? specFinder = null)
        {
            this.specFinder = specFinder;
        }

        protected internal void RunSpecs()
        {
            var types = FindSpecTypes();
            var finder = new SpecFinder(types, "");
            var tagsFilter = new Tags().Parse(Tags);
            var builder = new ContextBuilder(finder, tagsFilter, new DefaultConventions());
            var runner = new ContextRunner(tagsFilter, Formatter, FailFast);
            var contexts = builder.Contexts().Build();

            bool hasFocusTags = contexts.AnyTaggedWithFocus();
            if (hasFocusTags)
            {
                tagsFilter = new Tags().Parse(NSpec.Domain.Tags.Focus);

                builder = new ContextBuilder(finder, tagsFilter, new DefaultConventions());

                runner = new ContextRunner(tagsFilter, Formatter, FailFast);

                contexts = builder.Contexts().Build();
            }


            var results = runner.Run(contexts);

            //assert that there aren't any failures
            var failCount = results.Failures().Count();
            if (failCount != 0)
            {
                this.SpecAssertions.ReportFailureCount($"{failCount} failed of {results.Examples().Count()} test(s).");
            }

            var pending = results.Examples().Count(xmpl => xmpl.Pending);
            if (pending != 0)
            {
                this.SpecAssertions.ReportInclusive($"{pending} spec(s) are marked as pending.");
            }
            if (results.Examples().Count() == 0)
            {
                this.SpecAssertions.ReportInclusive("Spec count is zero.");
            }
            if (hasFocusTags)
            {
                this.SpecAssertions.ReportInclusive("One or more specs are tagged with focus.");
            }
        }

        protected internal void RunSpecs(Func<Type[]>? specFinder)
        {
            LoadSpecs(specFinder);
            RunSpecs();
        }

        protected internal void RunMySpecs()
        {
            LoadSpecs(() => new Type[] { this.GetType() });
            RunSpecs();
        }

        #endregion //protected methods

        #region helpers

        private Type[] FindSpecTypes()
        {
            if (specFinder != null)
            {
                return specFinder();
            }
            return GetType().Assembly.GetTypes();
        }

        #endregion //helpers
    }
}
