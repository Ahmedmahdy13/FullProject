using Domain.Entities.Audit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
	public class BuildingConfigruation : IEntityTypeConfiguration<Building>
	{
		public void Configure(EntityTypeBuilder<Building> builder)
		{
			builder.HasKey(p => p.Id);
		}
	}



	public class BuildingManagerConfigruation : IEntityTypeConfiguration<BuildingManager>
	{
		public void Configure(EntityTypeBuilder<BuildingManager> builder)
		{
			throw new NotImplementedException();
		}
	}



}
