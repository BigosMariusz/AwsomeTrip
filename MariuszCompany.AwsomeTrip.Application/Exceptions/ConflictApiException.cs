using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MariuszCompany.AwsomeTrip.Application.Exceptions
{
    public class ConflictApiException : Exception
    {
        public ConflictApiException() : base("Conflict failure.")
        {
        }
        public string ErrorMessage { get; private set; } = string.Empty;
        public ConflictApiException(string errorMessage)
            : this()
        {
            ErrorMessage = errorMessage;
        }
        
    }
}
