using System;
using Xunit;
using DRI.BasicDI.UnitTests.TestClasses;
using DRI.BasicDI.Exceptions;

namespace DRI.BasicDI.UnitTests
{
    public class RegistrationTests: TestsBaseClass
    {
        [Fact]
        public void Should_register_concrete_types()
        {
            container.Register<TestClassA>();
            var instance = container.GetInstance<TestClassA>();
            Assert.IsType<TestClassA>(instance);
        }

        [Fact]
        public void Should_throw_AlreadyRegisteredException_when_registering_dependency_more_than_once()
        {
            container.Register<TestClassA>();
            Action act = () => container.Register<TestClassA>();
            var alreadyRegisteredException = Assert.Throws<AlreadyRegisteredException>(() => act());
            Assert.Equal("Type is already registered.", alreadyRegisteredException.Message);
        }
    }
}