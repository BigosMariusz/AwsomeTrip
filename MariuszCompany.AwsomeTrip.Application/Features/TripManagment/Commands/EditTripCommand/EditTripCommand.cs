using MariuszCompany.AwsomeTrip.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariuszCompany.AwsomeTrip.Application.Features.TripManagment.Commands.EditTripCommand
{
    public class EditTripCommand : IRequest<Guid>
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDateUtc { get; set; }
        public byte? NumberOfSeats { get; set; }
    }
}
