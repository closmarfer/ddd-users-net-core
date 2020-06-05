using System;
using System.Text.RegularExpressions;

namespace Users.Domain.ValueObject
{
    public abstract class ValueObjectAbstract
    {
        protected bool HasOnlyLetters(string str)
        {
            try
            {
                return Regex.IsMatch(str, @"^[a-zA-Z]+$");
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}