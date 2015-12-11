using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NSubstitute;
using NUnit.Core;
using NUnit.Core.Extensibility;
using NUnit.Framework;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoNSubstitute;
using Ploeh.AutoFixture.Kernel;
using Ploeh.AutoFixture.NUnit2;
using Ploeh.AutoFixture.NUnit2.Addins;
using System.Collections;
using System.Reflection;
using NUnit.Core;
using NUnit.Core.Extensibility;

namespace Stuff.AutoFixture.Tests
{
    [TestFixture]
    internal sealed class SomeThingTests
    {
        private IFixture m_Fixture;

        [SetUp]
        public void Setup()
        {
            m_Fixture = new Fixture()
                .Customize(new AutoNSubstituteCustomization());
        }

        [Theory, AutoData] // todo check for bug fix https://devnet.jetbrains.com/thread/475237
        public void FunctionUnderTest_ExpectedResult_UnderCondition(Something sut)
        {
            // Arrange
//            var fixture = new Fixture()
//                .Customize(new AutoNSubstituteCustomization());
//            var somethingElse = fixture.Freeze<ISomethingElse>();
//            var sut = fixture.Create<Something>();

            // Act
            sut.Do();

            // Assert
            //somethingElse.Received().DoSomethingElse();
        }


        [Test]
        public void WorkingFunctionUnderTest_ExpectedResult_UnderCondition()
        {
            // Arrange
            ISomethingElse somethingElse = m_Fixture.Freeze<ISomethingElse>();
            Something sut = m_Fixture.Create<Something>();

            // Act
            sut.Do();

            // Assert
            somethingElse.Received().DoSomethingElse();
        }
    }
}
