using System;
using System.Collections;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers;
using Castle.Windsor;
using NSubstitute;
using NUnit.Framework;

namespace Stuff.Tests
{
    [TestFixture]
    internal sealed class SomethingTests : AutoMockTestBase
    {
        [Test]
        public void FunctionUnderTest_ExpectedResult_UnderCondition()
        {
            // Arrange
            var sut = Container.Resolve <ISomething>();

            // Act


            // Assert

        }
    }

    public class AutoMockTestBase
    {
        private readonly WindsorContainer m_Container;

        public AutoMockTestBase()
        {
            m_Container = new WindsorContainer();
            m_Container.Register(Component.For<LazyComponentAutoMocker>());

            m_Container.Register(Component.For <ISomething>()
                                          .ImplementedBy <Something>()
                                          .LifestyleTransient());

//            m_Container.Register(Component.For<ISomethingElse>()
//                                          .ImplementedBy<SomethingElse>()
//                                          .LifestyleTransient());
        }

        protected WindsorContainer Container
        {
            get { return m_Container; }
        }
    }

    public class LazyComponentAutoMocker : ILazyComponentLoader
    {
        public IRegistration Load(string key, Type service, IDictionary arguments)
        {
            return Component.For(service)
                            .Instance(Substitute.For(new[]
                                                     {
                                                         service
                                                     },
                                                     null));
        }
    }
}
