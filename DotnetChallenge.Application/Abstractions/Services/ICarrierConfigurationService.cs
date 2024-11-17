using DotnetChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetChallenge.Application.Abstractions.Services
{
	public interface ICarrierConfigurationService
	{
		Task InsertCarrierConfigurationAsync(CarrierConfiguration carrierConfiguration);
		Task UpdateCarrierConfigurationAsync(CarrierConfiguration carrierConfiguration);
		Task<CarrierConfiguration> GetCarrierConfigurationByIdAsync(int carrierConfigurationId);
		Task<IList<CarrierConfiguration>> GetAllCarrierConfigurationsAsync();
		Task<bool> DeleteCarrierConfigurationAsync(CarrierConfiguration carrierConfiguration);
	}
}
