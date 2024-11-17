using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetChallenge.Application.Abstractions.Services
{
	public interface ICarrierReportService
	{
		Task GenerateCarrierReportAsync();
	}
}
