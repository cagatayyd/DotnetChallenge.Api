using DotnetChallenge.Application.Models.Order;
using DotnetChallenge.Application.Models.CarrierConfiguration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetChallenge.Application.Models.Carrier
{
	public class CarrierModel : BaseModel
	{
		[Required]
		public string CarrierName { get; set; }
		public bool CarrierIsActive { get; set; }
		[Required]
		public decimal CarrierPlusDesiCost { get; set; }
		public int CarrierConfigurationId { get; set; }
		public int OrderId { get; set; }
	}
}
