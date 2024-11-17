using DotnetChallenge.Application.Abstractions.Services;
using DotnetChallenge.Application.Repositories;
using DotnetChallenge.Persistence.Contexts;
using DotnetChallenge.Persistence.Repositories;
using DotnetChallenge.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetChallenge.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistenceServices(this IServiceCollection services)
		{
			services.AddScoped<IOrderReadRepository, OrderReadRepository>();
			services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
			services.AddScoped<IOrderService, OrderService>();

			services.AddScoped<ICarrierReadRepository, CarrierReadRepository>();
			services.AddScoped<ICarrierWriteRepository, CarrierWriteRepository>();
			services.AddScoped<ICarrierService, CarrierService>();

			services.AddScoped<ICarrierConfigurationReadRepository, CarrierConfigurationReadRepository>();
			services.AddScoped<ICarrierConfigurationWriteRepository, CarrierConfigurationWriteRepository>();
			services.AddScoped<ICarrierConfigurationService, CarrierConfigurationService>();

			services.AddScoped<ICarrierReportService, CarrierReportService>();
		}

	}
}
