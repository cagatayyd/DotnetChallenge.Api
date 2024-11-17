using DotnetChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetChallenge.Application.Abstractions.Services
{
	public interface ICarrierService
	{
		Task InsertCarrierAsync(Carrier carrier);
		Task UpdateCarrierAsync(Carrier carrier);
		Task<Carrier> GetCarrierByIdAsync(int carrierId);
		Task<IList<Carrier>> GetAllCarriersAsync();
		Task<bool> DeleteCarrierAsync(Carrier carrier);
	}
}
