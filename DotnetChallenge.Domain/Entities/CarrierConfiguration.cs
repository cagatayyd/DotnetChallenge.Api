using DotnetChallenge.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetChallenge.Domain.Entities
{
	public class CarrierConfiguration : BaseEntity
	{
		[Required]
		public int CarrierId { get; set; }
		[Required]
		public int CarrierMaxDesi { get; set; }
		[Required]
		public int CarrierMinDesi { get; set; }
		[Required]
		public decimal CarrierCost { get; set; }
	}
}
