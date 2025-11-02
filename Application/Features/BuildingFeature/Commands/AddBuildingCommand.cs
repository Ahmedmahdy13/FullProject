using Application.Shared;
using Domain.Entities.Audit;
using Infrastructure.Repositories.Base.UnitOfWork;
using Infrastructure.Repositories.Base.RepositoryBase;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace Application.Features.BuildingFeature.Commands
{
	public class AddBuildingCommand : IRequest<Result<int>>
	{
		public string Building_Name { get; set; }

		public int NumberOfFloors { get; set; }

		public string Building_Code { get; set; }

		public int BuildingManagerId { get; set; }
	}


	public class AddBuildingCommandHandler : IRequestHandler<AddBuildingCommand, Result<int>>
	{
	
		private readonly IUnitOfWork unitOfWork;
		private readonly IRepositoryBase<Building> _buildingRepo;
		private readonly IMapper _mapper;

		public AddBuildingCommandHandler(IUnitOfWork unitOfWork, IRepositoryBase<Building> buildingRepo ,  IMapper mapper)
		{
			

			this.unitOfWork = unitOfWork;
			_buildingRepo = unitOfWork.Repository<Building>();
			_mapper = mapper;
		}

		public async Task<Result<int>> Handle(AddBuildingCommand request, CancellationToken cancellationToken)
		{
			var entity = _mapper.Map<Building>(request);

			entity.BuildingManagerId = request.BuildingManagerId;

			_buildingRepo.Create(entity);

			var result = await unitOfWork.CompleteAsync(cancellationToken);

			if (result > 0)
			{
				return Result<int>.Success(entity.Id, "Success");
			}
			return Result<int>.Faild(0, "Faild");
		}
	}
}
