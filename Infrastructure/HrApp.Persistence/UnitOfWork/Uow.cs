using HrApp.Application.Interfaces;
using HrApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Persistence.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly HrAppDbContext _context;

        public Uow(HrAppDbContext context
           )
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
