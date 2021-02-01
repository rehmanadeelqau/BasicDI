using System;
using System.Collections.Generic;
using System.Text;

namespace DRI.BasicDI.Exceptions
{
    public sealed class AlreadyRegisteredException : Exception
    {
        public override string Message => "Type is already registered.";
    }
}