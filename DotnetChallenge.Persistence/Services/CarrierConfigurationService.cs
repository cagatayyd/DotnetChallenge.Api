using DotnetChallenge.Application.Abstractions.Services;
using DotnetChallenge.Application.Repositories;
using DotnetChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetChallenge.Persistence.Services
{
	public class CarrierConfigurationService : ICarrierConfigurationService
	{
		#region Fields
		private readonly ICarrierConfigurationWriteRepository _carrierConfigurationWriteRepository;
		private readonly ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;
		#endregion

		#region Ctor
		public CarrierConfigurationService(ICarrierConfigurationWriteRepository carrierConfigurationWriteRepository,
										ICarrierConfigurationReadRepository carrierConfigurationReadRepository)
		{
			_carrierConfigurationWriteRepository = carrierConfigurationWriteRepository;
			_carrierConfigurationReadRepository = carrierConfigurationReadRepository;
		}
		#endregion

		#region Methods

		public async Task InsertCarrierConfigurationAsync(CarrierConfiguration carrierConfiguration)
		{
			await _carrierConfigurationWriteRepository.AddAsync(carrierConfiguration);
			await _carrierConfigurationWriteRepository.SaveAsync();
		}
		public async Task UpdateCarrierConfigurationAsync(CarrierConfiguration carrierConfiguration)
		{
			_carrierConfigurationWriteRepository.Update(carrierConfiguration);
			await _carrierConfigurationWriteRepository.SaveAsync();
		}
		public async Task<CarrierConfiguration> GetCarrierConfigurationByIdAsync(int carrierConfigurationId)
		{
			return await _carrierConfigurationReadRepository.GetByIdAsync(carrierConfigurationId);
		}
		public async Task<IList<CarrierConfiguration>> GetAllCarrierConfigurationsAsync()
		{
			return await _carrierConfigurationReadRepository.GetAll().ToListAsync();
		}
		public async Task<bool> DeleteCarrierConfigurationAsync(CarrierConfiguration carrierConfiguration)
		{
			var response = await _carrierConfigurationWriteRepository.RemoveAsync(carrierConfiguration);
			await _carrierConfigurationWriteRepository.SaveAsync();
			return response;
		}

		#endregion
	}
}
