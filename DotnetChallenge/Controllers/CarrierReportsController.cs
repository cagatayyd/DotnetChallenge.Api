using DotnetChallenge.Application.Abstractions.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetChallenge.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarrierReportsController : ControllerBase
	{
		#region Fields
		private readonly ICarrierReportService _carrierReportService;
		#endregion

		#region Ctor
		public CarrierReportsController(ICarrierReportService carrierReportService)
		{
			_carrierReportService = carrierReportService;
		}
		#endregion

		#region Methods
		[HttpPost("generate")]
		public async Task<IActionResult> GenerateReport()
		{
			await _carrierReportService.GenerateCarrierReportAsync();
			return Ok(new { message = "Carrier report generated successfully" });
		}
		#endregion
	}
}
