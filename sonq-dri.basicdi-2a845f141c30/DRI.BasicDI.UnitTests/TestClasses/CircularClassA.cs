﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DRI.BasicDI.UnitTests.TestClasses
{
    internal class CircularClassA
    {
        public CircularClassA(CircularClassB circularClassB)
        {
        }
    }
}