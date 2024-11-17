using AutoMapper;
using DotnetChallenge.Application.Models.Carrier;
using DotnetChallenge.Application.Models.CarrierConfiguration;
using DotnetChallenge.Application.Models.Order;
using DotnetChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetChallenge.Persistence.Mapping
{
	public class MappingBuilder : Profile
	{
        public MappingBuilder()
        {
            CreateMap<Order, OrderModel>().ReverseMap();

			CreateMap<CarrierConfigurationModel, CarrierConfiguration>().ReverseMap();
            CreateMap<CarrierModel, Carrier>().ReverseMap();
        }
    }
}
