using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.Interfaces
{
    public interface IUow
    {
        Task CommitAsync();
        IAdvanceRepository GetAdvanceRepository();
        IExpenseRepository GetExpenseRepository();
        ILeaveRepository GetLeaveRepository();
    }
}
