using DotnetChallenge.Application.Models;
using DotnetChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetChallenge.Application.Abstractions.Services
{
	public interface IOrderService
	{
		Task InsertOrderAsync(Order order);
		Task UpdateOrderAsync(Order order);
		Task<Order> GetOrderByIdAsync(int orderId);
		Task<IList<Order>> GetAllOrdersAsync();
		Task<bool> DeleteOrderAsync(Order order);
		Task<(decimal carrierCost, int carrierId)> CalculateCarrierCostAsync(int orderDesi);
	}
}
