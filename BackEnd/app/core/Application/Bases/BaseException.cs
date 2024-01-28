﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bases
{
    public class BaseException : Exception
    {
        public BaseException() { }
        public BaseException(string message) : base(message) { }
    }
}