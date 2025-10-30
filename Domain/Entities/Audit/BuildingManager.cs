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
	[Table(nameof(BuildingManager) , Schema = Schemas.AUDIT)]
	public class BuildingManager : BaseEntity
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int Phone { get; set; }

		public string Email { get; set; }

		public ICollection<Building> Buildings { get; set; }
	}
}
