using AutoMapper;
using DotnetChallenge.Application.Abstractions.Services;
using DotnetChallenge.Application.Models.CarrierConfiguration;
using DotnetChallenge.Domain.Entities;
using DotnetChallenge.Persistence.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetChallenge.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarrierConfigurationsController : ControllerBase
	{
		#region Fields
		readonly private ICarrierConfigurationService _carrierConfigurationService;
		readonly private IMapper _mapper;
		#endregion

		#region Ctor
		public CarrierConfigurationsController(ICarrierConfigurationService carrierConfigurationService, IMapper mapper)
		{
			_carrierConfigurationService = carrierConfigurationService;
			_mapper = mapper;
		}
		#endregion

		#region Methods
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			try
			{
				var configurations = await _carrierConfigurationService.GetAllCarrierConfigurationsAsync();
				if (configurations == null || !configurations.Any())
					return NotFound(new { message = "No carrier configurations found" });

				return Ok(configurations);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "An error occurred while fetching carrier configurations", details = ex.Message });
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync(CarrierConfigurationModel model)
		{
			if (!ModelState.IsValid)
				return BadRequest(new { message = "Invalid carrier configuration data", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });

			try
			{
				var carrierConfiguration = _mapper.Map<CarrierConfiguration>(model);
				await _carrierConfigurationService.InsertCarrierConfigurationAsync(carrierConfiguration);
				return Ok(new { message = "Carrier configuration created successfully" });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "An error occurred while creating the carrier configuration", details = ex.Message });
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(CarrierConfigurationModel model)
		{
			if (!ModelState.IsValid)
				return BadRequest(new { message = "Invalid carrier configuration data", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });

			try
			{
				var carrierConfiguration = await _carrierConfigurationService.GetCarrierConfigurationByIdAsync(model.Id);
				if (carrierConfiguration == null)
					return NotFound(new { message = "Carrier configuration not found" });

				_mapper.Map(model, carrierConfiguration);
				await _carrierConfigurationService.UpdateCarrierConfigurationAsync(carrierConfiguration);
				return Ok(new { message = "Carrier configuration updated successfully" });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "An error occurred while updating the carrier configuration", details = ex.Message });
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var carrierConfiguration = await _carrierConfigurationService.GetCarrierConfigurationByIdAsync(id);
				if (carrierConfiguration == null)
					return NotFound(new { message = "Carrier configuration not found" });

				bool isDeleted = await _carrierConfigurationService.DeleteCarrierConfigurationAsync(carrierConfiguration);
				if (!isDeleted)
					return BadRequest(new { message = "Carrier configuration could not be deleted" });

				return Ok(new { message = "Carrier configuration deleted successfully" });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "An error occurred while deleting the carrier configuration", details = ex.Message });
			}
		}

		#endregion
	}
}
