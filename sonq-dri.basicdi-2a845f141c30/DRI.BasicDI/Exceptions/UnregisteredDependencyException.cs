using System;
using System.Collections.Generic;
using System.Text;

namespace DRI.BasicDI.Exceptions
{
    public sealed class UnregisteredDependencyException : Exception
    {
        public override string Message => "Type is unregistered. Please register the type first.";
    }
}