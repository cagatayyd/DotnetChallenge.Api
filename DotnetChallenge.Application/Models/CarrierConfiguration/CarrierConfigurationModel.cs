using DotnetChallenge.Application.Models.Carrier;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetChallenge.Application.Models.CarrierConfiguration
{
	public class CarrierConfigurationModel : BaseModel
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
