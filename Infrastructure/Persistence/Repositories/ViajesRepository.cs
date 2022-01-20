using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class ViajesRepository : GenericRepositoryAsync<tbViajes>, IViajeRepositoryAsync
    {
        public ViajesRepository(dbContext dbContext) : base(dbContext)
        {
        }
    }
}
