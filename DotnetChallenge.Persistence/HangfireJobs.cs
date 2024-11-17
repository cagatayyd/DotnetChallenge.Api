using DotnetChallenge.Application.Abstractions.Services;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetChallenge.Persistence
{
	public static class HangfireJobs
	{
		public static void ConfigureHangfireJobs(IRecurringJobManager recurringJobManager, IServiceProvider serviceProvider)
		{
			recurringJobManager.AddOrUpdate(
				"GenerateCarrierReport",
				() => serviceProvider.GetService<ICarrierReportService>()!.GenerateCarrierReportAsync(),
				Cron.Hourly);
		}
	}
}
