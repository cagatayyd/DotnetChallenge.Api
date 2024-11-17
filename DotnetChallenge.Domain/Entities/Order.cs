using DotnetChallenge.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetChallenge.Domain.Entities
{
	public class Order: BaseEntity 
	{ 
		[Required]
		[ForeignKey(nameof(Carrier.Id))]
		public int CarrierId { get; set; }
		[Required]
		public int OrderDesi { get; set; }
		[Required]
		public DateTime OrderDate { get; set; }
		[Required]
		public decimal OrderCarrierCost { get; set; }
	}
}
