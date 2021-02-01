using DRI.BasicDI.Exceptions;
using DRI.BasicDI.UnitTests.TestClasses;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DRI.BasicDI.UnitTests
{
    public class GetInstanceTests : TestsBaseClass
    {
        [Fact]
        public void Should_instantiate_concrete_type_with_no_dependencies()
        {
            container.Register<TestClassC>();
            var testClassC = container.GetInstance<TestClassC>();
            Assert.IsType<TestClassC>(testClassC);
        }

        [Fact]
        public void Should_instantiate_concrete_type_with_concrete_dependency()
        {
            container.Register<TestClassB>();
            var testClassB = container.GetInstance<TestClassB>();
            Assert.IsType<TestClassB>(testClassB);
            Assert.Equal(testClassB.IsInitialized, true);
        }

        [Fact]
        public void Should_instantiate_concrete_type_with_multiple_concrete_dependencies()
        {
            container.Register<TestClassA>();
            var testClassA = container.GetInstance<TestClassA>();
            Assert.IsType<TestClassA>(testClassA);
        }

        [Fact]
        public void Should_throw_UnregisteredDependencyException_when_instantiating_unregistered_type()
        {
            Action act = () => container.GetInstance<TestClassA>();
            var unregisteredDependencyException = Assert.Throws<UnregisteredDependencyException>(() => act());
            Assert.Equal("Type is unregistered. Please register the type first.", unregisteredDependencyException.Message);
        }

        [Fact]
        public void Should_throw_UnregisteredDependencyException_when_instantiating_type_with_unregistered_dependency()
        {
            container.Register<TestClassA>();
            Action act = () => container.GetInstance<TestClassB>();
            var unregisteredDependencyException = Assert.Throws<UnregisteredDependencyException>(() => act());
            Assert.Equal("Type is unregistered. Please register the type first.", unregisteredDependencyException.Message);
        }

        [Fact]
        public void Should_throw_CircularDependencyException_when_instantiating_type_with_circular_dependency()
        {
            //container.Register<CircularClassA>();
            //container.Register<CircularClassB>();
            //container.Register<CircularClassC>();
            Action act = () => container.Register<CircularClassC>();
            var unregisteredDependencyException = Assert.Throws<CircularDependencyException>(() => act());
            Assert.Equal("Type contains circular dependency.", unregisteredDependencyException.Message);
        }
    }
}