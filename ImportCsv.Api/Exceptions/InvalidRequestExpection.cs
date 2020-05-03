using System;
using System.Collections.Generic;

namespace ImportCsv.Api.Exceptions
{
    public class InvalidRequestExpection : Exception
    {
        private static readonly string MessageDefault = "Invalid request, verify request for continue.";
        public IList<string> Errors {get; set;}

        public override string Message => MessageDefault;

        public InvalidRequestExpection(string message) : base(message)
        {
        }

        public InvalidRequestExpection(IList<string> errors)
        {
            Errors = errors;
        }

    }
}