using AutoMapper;
using MariuszCompany.AwsomeTrip.Application.Interfaces.Repositories;
using MariuszCompany.AwsomeTrip.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MariuszCompany.AwsomeTrip.Application.Features.Trip.Query.ListTripsQuery
{
    public class ListTripsHandler : IRequestHandler<ListTripsQuery, PagedResponse<IEnumerable<ListTripsVM>>>
    {
        private readonly ITripListRepository _tripListRepository;
        private readonly IMapper _mapper;
        public ListTripsHandler(ITripListRepository tripListRepository, IMapper mapper)
        {
            _tripListRepository = tripListRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<ListTripsVM>>> Handle(ListTripsQuery request, CancellationToken cancellationToken)
        {
            var pageSize = request.PageSize ?? 25;
            var trips = await _tripListRepository.GetList(request.PageNumber.Value, pageSize);
            var vm = _mapper.Map<IEnumerable<ListTripsVM>>(trips);

            return new PagedResponse<IEnumerable<ListTripsVM>>(vm, request.PageNumber.Value, pageSize);
        }
    }
}
