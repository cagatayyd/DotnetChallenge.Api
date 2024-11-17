using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotnetChallenge.Application.Abstractions.Services;
using DotnetChallenge.Application.Repositories;
using DotnetChallenge.Domain.Entities;
using DotnetChallenge.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DotnetChallenge.Persistence.Services
{
	public class CarrierReportService : ICarrierReportService 
	{
		#region Fields
		private readonly IOrderReadRepository _orderReadRepository;
		private readonly DotnetChallengeDbContext _context;
		#endregion

		#region Ctor
		public CarrierReportService(IOrderReadRepository orderRepository, DotnetChallengeDbContext context)
		{
			_orderReadRepository = orderRepository;
			_context = context;
		}
		#endregion

		#region Methods
		public async Task GenerateCarrierReportAsync()
		{
			var groupedOrders = await _orderReadRepository.GetAll()
				.GroupBy(o => new { o.CarrierId, ReportDate = o.OrderDate.Date })
				.Select(g => new
				{
					Id = g.Key.CarrierId,
					Date = g.Key.ReportDate,
					TotalCost = g.Sum(o => o.OrderCarrierCost)
				})
				.ToListAsync();

			foreach (var group in groupedOrders)
			{
				var report = new CarrierReport
				{
					CarrierId = group.Id,
					CarrierReportDate = group.Date,
					CarrierCost = group.TotalCost

				};
				report.CreatedDate = DateTime.Now;
				await _context.AddAsync(report);
			}

			await _context.SaveChangesAsync();
		}

		#endregion

	}
}
