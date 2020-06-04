﻿using System;
namespace Users.Domain.ValueObject
{
    public class Email
    {
        public string Value { get; private set; }

        public Email(string email)
        {
            this.Value = email;
        }
    }
}
