using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MariuszCompany.AwsomeTrip.Application.Exceptions
{
    public class NotFoundApiException : Exception
    {
        public NotFoundApiException() : base("Record not found.")
        {
        }
    }
}
