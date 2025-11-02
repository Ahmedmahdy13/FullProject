using Application.Features.BuildingFeature.Commands;
using AutoMapper;
using Domain.Entities.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<AddBuildingCommand, Building>().ReverseMap();
		}
	}
}
