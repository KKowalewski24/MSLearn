﻿using System;

namespace RazorPagesIntro.Exceptions
{
    public class CustomerNotFoundException : CustomerException
    {
        public CustomerNotFoundException()
        {
        }

        public CustomerNotFoundException(string message)
            : base(message)
        {
        }

        public CustomerNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}