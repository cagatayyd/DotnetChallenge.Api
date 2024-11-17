using DotnetChallenge.Application.Models.Carrier;
using DotnetChallenge.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DotnetChallenge.Application.Models.Order
{
	public class OrderModel : BaseModel
	{
		[JsonIgnore]
		public int CarrierId { get; set; }
		[Required]
		public int OrderDesi { get; set; }
		[Required]
		public DateTime OrderDate { get; set; }
		[JsonIgnore]
		public decimal OrderCarrierCost { get; set; }

	}
}
