using System;
using System.Collections.Generic;
using System.Text;

namespace DRI.BasicDI.UnitTests.TestClasses
{
    internal class TestClassB
    {
        public bool IsInitialized { get; } = false;
        public TestClassB(TestClassC testClassC)
        {
            IsInitialized = true;
        }
    }
}