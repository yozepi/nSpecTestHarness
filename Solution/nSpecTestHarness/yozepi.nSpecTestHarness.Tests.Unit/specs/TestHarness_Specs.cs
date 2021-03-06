﻿using Moq;
using NSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NSpec.Domain.Formatters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace yozepi.Tests.Unit.specs
{
    class TestHarness_Specs : nspec
    {

        void constructor_behavior()
        {
            var subjectMock = new Mock<nSpecTestHarness>();
            subjectMock.CallBase = true;
            var subject = subjectMock.Object;
            it["should set the internal formatter property a ConsoleFormatter instance"] = () =>
                subject.Formatter.Should().BeOfType<ConsoleFormatter>();
        }

        void LoadSpecs_method()
        {
            var subjectMock = new Mock<nSpecTestHarness>();
            subjectMock.CallBase = true;
            var subject = subjectMock.Object;
            Func<Type[]> expected = () => new Type[] { typeof(string), typeof(int) };
            subject.LoadSpecs(expected);
            it["should set the protected specFinder property"] = () =>
            {
                subject.specFinder.Should().Be(expected);
            };
        }

        void RunSpecs_method()
        {
            var subjectMock = new Mock<nSpecTestHarness>();
            subjectMock.CallBase = true;
            var subject = subjectMock.Object;
            Func<Type[]> specFinder = null;
            Action action = () => subject.RunSpecs(specFinder);

            context["when there are pending specs"] = () =>
            {
                before = () => specFinder = () => new Type[] { typeof(PendingSpecsExample) };

                it["should raise AssertInconclusiveException exception with a count of pending specs in the message"] = () =>
                    action.ShouldThrow<AssertInconclusiveException>()
                        .And.Message.Should().Contain("spec(s) are marked as pending.");
            };

            context["when there are specs tagged with \"focus\""] = () =>
            {
                before = () => specFinder = () => new Type[] { typeof(FocusedTestsExample) };

                it["should raise AssertInconclusiveException exception indicating tagged specs in the message"] = () =>
                   action.ShouldThrow<AssertInconclusiveException>()
                        .And.Message.Should().Contain("One or more specs are tagged with focus.");
            };

            context["when there are no specs to run"] = () =>
            {
                before = () => specFinder = () => new Type[] { typeof(NoSpecsExample) };

                it["should raise AssertInconclusiveException exception indicating there are no specs"] = () =>
                  action.ShouldThrow<AssertInconclusiveException>()
                        .And.Message.Should().Contain("Spec count is zero.");

            };
        }

        void RunMySpecs_method()
        {

            var subject = new MySpecsExample();

            subject.RunMySpecs();
            it["should only load the specs for this class"] = () =>
                subject.specFinder().Should().OnlyContain((t) => t == typeof(MySpecsExample));

        }

    }
}
