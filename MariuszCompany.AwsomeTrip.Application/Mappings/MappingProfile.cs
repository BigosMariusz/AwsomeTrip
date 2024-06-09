using AutoMapper;
using MariuszCompany.AwsomeTrip.Application.Features.Trip.Query.GetSingleTripQuery;
using MariuszCompany.AwsomeTrip.Application.Features.Trip.Query.ListTripsQuery;
using MariuszCompany.AwsomeTrip.Application.Features.Trip.Query.SearchTripsQuery;
using MariuszCompany.AwsomeTrip.Application.Features.TripManagment.Commands.CreateTripCommand;
using MariuszCompany.AwsomeTrip.Application.Features.TripManagment.Commands.EditTripCommand;
using MariuszCompany.AwsomeTrip.Application.Features.TripManagment.Commands.RegisterForTripCommand;
using MariuszCompany.AwsomeTrip.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MariuszCompany.AwsomeTrip.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateTripCommand, Trip>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Registrations, o => o.Ignore())
                .ForMember(d => d.DateCreatedUtc, o => o.Ignore())
                .ForMember(d => d.DateModifiedUtc, o => o.Ignore());

            CreateMap<EditTripCommand, Trip>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Registrations, o => o.Ignore())
                .ForMember(d => d.DateCreatedUtc, o => o.Ignore())
                .ForMember(d => d.DateModifiedUtc, o => o.Ignore());

            CreateMap<Trip, SearchTripsVM>();

            CreateMap<Trip, GetSingleTripVM>();

            CreateMap<Trip, ListTripsVM>();

            CreateMap<RegisterForTripCommand, Registration>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Trip, o => o.Ignore())
                .ForMember(d => d.DateCreatedUtc, o => o.Ignore())
                .ForMember(d => d.DateModifiedUtc, o => o.Ignore());
        }
    }
}
