using System;
using System.Collections.Generic;
using System.Text;

namespace DRI.BasicDI.Exceptions
{
    public sealed class CircularDependencyException : Exception
    {
        public override string Message => "Type contains circular dependency.";
    }
}