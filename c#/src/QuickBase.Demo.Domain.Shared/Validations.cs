using System;
using System.Collections.Generic;

namespace QuickBase.Demo.Domain.Shared
{
    public static class Validations
    {
        public static string CheckEntityName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(
                    $"name can not be empty or white space!");
            }

            if (name.Length > ValidationConstants.MaxNameLength)
            {
                throw new ArgumentException(
                    $"name can not be longer than {ValidationConstants.MaxNameLength} chars!");
            }

            return name;
        }
    }
}
