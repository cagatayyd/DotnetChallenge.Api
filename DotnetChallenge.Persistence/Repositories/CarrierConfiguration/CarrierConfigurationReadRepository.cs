﻿using DotnetChallenge.Application.Repositories;
using DotnetChallenge.Domain.Entities;
using DotnetChallenge.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetChallenge.Persistence.Repositories
{
	public class CarrierConfigurationReadRepository : ReadRepository<CarrierConfiguration>, ICarrierConfigurationReadRepository
	{
		public CarrierConfigurationReadRepository(DotnetChallengeDbContext context) : base(context)
		{
		}
	}
}