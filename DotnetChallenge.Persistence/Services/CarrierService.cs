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
	public class CarrierService : ICarrierService
	{
		#region Fields
		private readonly ICarrierWriteRepository _carrierWriteRepository;
		private readonly ICarrierReadRepository _carrierReadRepository;
		#endregion

		#region Ctor
		public CarrierService(ICarrierWriteRepository carrierWriteRepository, ICarrierReadRepository carrierReadRepository)
		{
			_carrierWriteRepository = carrierWriteRepository;
			_carrierReadRepository = carrierReadRepository;
		}

		#endregion

		#region Methods
		public async Task InsertCarrierAsync(Carrier carrier)
		{
			await _carrierWriteRepository.AddAsync(carrier);
			await _carrierWriteRepository.SaveAsync();
		}
		public async Task UpdateCarrierAsync(Carrier carrier)
		{
			_carrierWriteRepository.Update(carrier);
			await _carrierWriteRepository.SaveAsync();
		}
		public async Task<Carrier> GetCarrierByIdAsync(int carrierId)
		{
			return await _carrierReadRepository.GetByIdAsync(carrierId);
		}
		public async Task<IList<Carrier>> GetAllCarriersAsync()
		{
			return await _carrierReadRepository.GetAll().ToListAsync();
		}
		public async Task<bool> DeleteCarrierAsync(Carrier carrier)
		{
			var response = await _carrierWriteRepository.RemoveAsync(carrier);
			await _carrierWriteRepository.SaveAsync();
			return response;
		}
		#endregion
	}
}
