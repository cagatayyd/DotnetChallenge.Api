using AutoMapper;
using DotnetChallenge.Application.Abstractions.Services;
using DotnetChallenge.Application.Models.Carrier;
using DotnetChallenge.Application.Models.Order;
using DotnetChallenge.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetChallenge.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarriersController : ControllerBase
	{
		#region Fields
		readonly private ICarrierService _carrierService;
		readonly private IMapper _mapper;
		#endregion

		#region Ctor
		public CarriersController(ICarrierService carrierService, IMapper mapper)
		{
			_carrierService = carrierService;
			_mapper = mapper;
		}
		#endregion

		#region Methods
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			try
			{
				var carriers = await _carrierService.GetAllCarriersAsync();
				if (carriers == null || !carriers.Any())
					return NotFound(new { message = "No carriers found" });

				return Ok(carriers);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "An error occurred while fetching carriers", details = ex.Message });
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync(CarrierModel model)
		{
			if (!ModelState.IsValid)
			{
				var errors = ModelState.Values
					.SelectMany(v => v.Errors)
					.Select(e => e.ErrorMessage);
				return BadRequest(new { message = "Invalid carrier data", errors });
			}

			try
			{
				var carrier = _mapper.Map<Carrier>(model);
				await _carrierService.InsertCarrierAsync(carrier);
				return Ok(new { message = "Carrier created successfully" });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "An error occurred while creating the carrier", details = ex.Message });
			}
		}


		[HttpPut("{id}")]
		public async Task<IActionResult> Update(CarrierModel model)
		{
			if (!ModelState.IsValid)
				return BadRequest(new { message = "Invalid carrier data", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });

			try
			{
				var carrier = await _carrierService.GetCarrierByIdAsync(model.Id);
				if (carrier == null)
					return NotFound(new { message = "Cannot find carrier" });

				_mapper.Map(model, carrier); // Güncellenen alanları eşleştirir
				await _carrierService.UpdateCarrierAsync(carrier);
				return Ok(new { message = "Carrier updated successfully" });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "An error occurred while updating the carrier", details = ex.Message });
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var carrier = await _carrierService.GetCarrierByIdAsync(id);
				if (carrier == null)
					return NotFound(new { message = "Carrier not found" });

				bool isDeleted = await _carrierService.DeleteCarrierAsync(carrier);
				if (!isDeleted)
					return BadRequest(new { message = "Carrier could not be deleted" });

				return Ok(new { message = "Carrier deleted successfully" });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "An error occurred while deleting the carrier", details = ex.Message });
			}
		}

		#endregion
	}
}
