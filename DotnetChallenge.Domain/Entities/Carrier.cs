using DotnetChallenge.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetChallenge.Domain.Entities
{
	public class Carrier : BaseEntity
	{
		[Required]
		public string CarrierName { get; set; }
		public bool CarrierIsActive { get; set; }
		[Required]
		public decimal CarrierPlusDesiCost { get; set; }
        public int CarrierConfigurationId { get; set; }
        public int OrderId { get; set; }
		public ICollection<Order> Orders { get; set; }
		public ICollection<CarrierConfiguration> CarrierConfigurations { get; set; }
	}
}
