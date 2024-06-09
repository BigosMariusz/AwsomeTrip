using MariuszCompany.AwsomeTrip.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariuszCompany.AwsomeTrip.Application.Features.TripManagment.Commands.DeleteTripCommand
{
    public class DeleteTripCommand : IRequest
    {
        public Guid? Id { get; set; }
    }
}
