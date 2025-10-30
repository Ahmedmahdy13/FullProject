using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.BaseEntities
{
	public class BaseEntity
	{
		public string InsertBy { get; set; }
		public DateTime? InsertDate { get; set; } = DateTime.Now;

		public string UpdateBy { get; set; }
		public DateTime? UpdateDate { get; set; }

		public string DeleteBy { get; set; }
		public DateTime? DeleteDate { get; set; }

		public bool IsDeleted { get; set; }
	}
}
