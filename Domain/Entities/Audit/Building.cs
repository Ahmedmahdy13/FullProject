using Domain.Const;
using Domain.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Audit
{
	[Table(nameof(Building), Schema = Schemas.AUDIT)]
	public class Building : BaseEntity
	{
		public int Id { get; set; }

		public string Building_Name { get; set; }

		public int NumberOfFloors { get; set; }

		public string Building_Code { get; set; }

		public int BuildingManagerId { get; set; }
		public BuildingManager BuildingManager { get; set; }

	}
}
