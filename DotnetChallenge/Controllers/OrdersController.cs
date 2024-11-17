using AutoMapper;
using DotnetChallenge.Application.Abstractions.Services;
using DotnetChallenge.Application.Models;
using DotnetChallenge.Application.Models.Order;
using DotnetChallenge.Application.Repositories;
using DotnetChallenge.Domain.Entities;
using DotnetChallenge.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetChallenge.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		#region Fields
		readonly private IOrderService _orderService;
		readonly private IMapper _mapper;
		#endregion

		#region Ctor
		public OrdersController(IOrderService orderService, IMapper mapper)
		{
			_orderService = orderService;
			_mapper = mapper;
		}
		#endregion

		#region Methods
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			try
			{
				var orders = await _orderService.GetAllOrdersAsync();
				if (orders == null || !orders.Any())
					return NotFound(new { message = "No orders found" });

				return Ok(orders);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "An error occurred while fetching orders", details = ex.Message });
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync(OrderModel model)
		{
			if (!ModelState.IsValid)
				return BadRequest(new { message = "Invalid order data", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
			try
			{
				int desiPlusOne = model.OrderDesi + 1;
				// Kargo maliyetini ve CarrierId'yi hesapla
				var (totalCarrierCost, carrierId) = await _orderService.CalculateCarrierCostAsync(desiPlusOne);

				// Modeli ve hesaplanan bilgileri entity'e dönüştür
				var order = _mapper.Map<Order>(model);
				order.CarrierId = carrierId;
				order.OrderCarrierCost = totalCarrierCost;
				// Siparişi ekle
				await _orderService.InsertOrderAsync(order);

				return Ok(new { message = "Order created successfully" });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "An error occurred while creating the order", details = ex.Message });
			}
		}


		[HttpPost("{id}")]
		public async Task<IActionResult> Update(OrderModel model)
		{
			if (!ModelState.IsValid)
				return BadRequest(new { message = "Invalid order data", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });

			try
			{
				// Siparişi al
				var order = await _orderService.GetOrderByIdAsync(model.Id);
				if (order == null)
					return NotFound(new { message = "Cannot find order" });

				var (totalCarrierCost, carrierId) = await _orderService.CalculateCarrierCostAsync(model.OrderDesi);

				_mapper.Map(model, order);
				order.CarrierId = carrierId;
				order.OrderCarrierCost = totalCarrierCost;

				// Siparişi güncelle
				await _orderService.UpdateOrderAsync(order);

				return Ok(new { message = "Order updated successfully" });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "An error occurred while updating the order", details = ex.Message });
			}
		}


		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var order = await _orderService.GetOrderByIdAsync(id);
				if (order == null)
					return NotFound(new { message = "Order not found" });

				bool isDeleted = await _orderService.DeleteOrderAsync(order);
				if (!isDeleted)
					return BadRequest(new { message = "Order could not be deleted" });

				return Ok(new { message = "Order deleted successfully" });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "An error occurred while deleting the order", details = ex.Message });
			}
		}

		#endregion

	}
}
