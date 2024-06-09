using MariuszCompany.AwsomeTrip.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariuszCompany.AwsomeTrip.Application.Features.TripManagment.Commands.RegisterForTripCommand
{
    public class RegisterForTripCommand : IRequest<Response<Guid>>
    {
        public string? Email { get; set; }
        public Guid? TripId { get; set; }
    }
}
