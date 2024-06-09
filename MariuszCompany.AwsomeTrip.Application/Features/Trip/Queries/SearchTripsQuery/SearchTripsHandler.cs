using AutoMapper;
using MariuszCompany.AwsomeTrip.Application.Interfaces.Repositories;
using MariuszCompany.AwsomeTrip.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MariuszCompany.AwsomeTrip.Application.Features.Trip.Query.SearchTripsQuery
{
    public class SearchTripsHandler : IRequestHandler<SearchTripsQuery, PagedResponse<IEnumerable<SearchTripsVM>>>
    {
        private readonly ITripListRepository _tripListRepository;
        private readonly IMapper _mapper;
        public SearchTripsHandler(ITripListRepository tripListRepository, IMapper mapper)
        {
            _tripListRepository = tripListRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<SearchTripsVM>>> Handle(SearchTripsQuery request, CancellationToken cancellationToken)
        {
            var pageSize = request.PageSize ?? 25;
            var trips = await _tripListRepository.SearchByCountry(request.Country, request.PageNumber.Value, pageSize);
            var vm = _mapper.Map<IEnumerable<SearchTripsVM>>(trips);

            return new PagedResponse<IEnumerable<SearchTripsVM>>(vm, request.PageNumber.Value, pageSize);
        }
    }
}
