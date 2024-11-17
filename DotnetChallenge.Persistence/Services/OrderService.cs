using DotnetChallenge.Application.Abstractions.Services;
using DotnetChallenge.Application.Models.Carrier;
using DotnetChallenge.Application.Repositories;
using DotnetChallenge.Domain.Entities;
using DotnetChallenge.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetChallenge.Persistence.Services
{
	public class OrderService : IOrderService
	{
		#region Fields
		private readonly IOrderWriteRepository _orderWriteRepository;
		private readonly IOrderReadRepository _orderReadRepository;
		private readonly ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;
		private readonly ICarrierReadRepository _carrierReadRepository;
		#endregion

		#region Ctor
		public OrderService(IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository,
							ICarrierConfigurationReadRepository carrierConfigurationReadRepository, ICarrierReadRepository carrierReadRepository)
		{
			_orderWriteRepository = orderWriteRepository;
			_orderReadRepository = orderReadRepository;
			_carrierConfigurationReadRepository = carrierConfigurationReadRepository;
			_carrierReadRepository = carrierReadRepository;
		}
		#endregion

		#region Methods
		public async Task<(decimal carrierCost, int carrierId)> CalculateCarrierCostAsync(int orderDesi)
		{
			var carrierConfigs = _carrierConfigurationReadRepository.GetAll();

			var matchingCarrierConfigs = carrierConfigs
				.Where(c => orderDesi >= c.CarrierMinDesi && orderDesi <= c.CarrierMaxDesi)
				.OrderBy(c => c.CarrierCost)
				.ToList();

			if (matchingCarrierConfigs.Any())
			{
				var selectedCarrierConfig = matchingCarrierConfigs.First();
				decimal totalCarrierCost = orderDesi * selectedCarrierConfig.CarrierCost;

				return (totalCarrierCost, selectedCarrierConfig.CarrierId);
			}

			var closestCarrierConfigs = carrierConfigs
				.GroupBy(c => Math.Abs(c.CarrierMinDesi - orderDesi))
				.OrderBy(g => g.Key)
				.First()
				.OrderBy(c => c.CarrierCost)
				.ToList();

			var closestCarrierConfig = closestCarrierConfigs.First();
			decimal totalCarrierCostWithExtra = orderDesi * closestCarrierConfig.CarrierCost;

			if (orderDesi > closestCarrierConfig.CarrierMaxDesi)
			{
				var carrier = await _carrierReadRepository.GetByIdAsync(closestCarrierConfig.CarrierId);
				if (carrier == null)
					throw new Exception("Cannot find carrier information.");

				var desiDifference = orderDesi - closestCarrierConfig.CarrierMaxDesi;
				var additionalCost = desiDifference * carrier.CarrierPlusDesiCost;

				totalCarrierCostWithExtra += additionalCost;
			}

			return (totalCarrierCostWithExtra, closestCarrierConfig.CarrierId);
		}

		public async Task InsertOrderAsync(Order order)
		{
			await _orderWriteRepository.AddAsync(order);
			await _orderWriteRepository.SaveAsync();
		}
		public async Task UpdateOrderAsync(Order order)
		{
			_orderWriteRepository.Update(order);
			await _orderWriteRepository.SaveAsync();
		}
		public async Task<Order> GetOrderByIdAsync(int orderId)
		{
			return await _orderReadRepository.GetByIdAsync(orderId);
		}
		public async Task<IList<Order>> GetAllOrdersAsync()
		{
			return await _orderReadRepository.GetAll().ToListAsync();
		}
		public async Task<bool> DeleteOrderAsync(Order order)
		{
			bool result = await _orderWriteRepository.RemoveAsync(order);
			await _orderWriteRepository.SaveAsync();
			return result;
		}
	}
}
#endregion



