using AutoMapper;
using HrApp.Application.CQRS.Currency.Queries;
using HrApp.Application.Dtos;
using HrApp.Application.Interfaces;
using HrApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.ExpenseType.Queries.Handlers
{
    public class ReadAllExpenseTypeQueryHandler : IRequestHandler<ReadAllExpenseTypeQuery, ServiceResponse<List<ExpenseTypeDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public ReadAllExpenseTypeQueryHandler(IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<ServiceResponse<List<ExpenseTypeDto>>> Handle(ReadAllExpenseTypeQuery request, CancellationToken cancellationToken)
        {
            var entities = await _uow.GetExpenseTypeRepository().GetAllAsync(true);

            if (entities.Count() > 0)
            {
                var dtos = new List<ExpenseTypeDto>();

                foreach (var entity in entities)
                {
                    var mappedEntity = _mapper.Map<ExpenseTypeDto>(entity);

                    dtos.Add(mappedEntity);
                }

                return new ServiceResponse<List<ExpenseTypeDto>>(dtos) { IsSuccess = true, Message = "" };
            }

            return new ServiceResponse<List<ExpenseTypeDto>>() { IsSuccess = false, Message = "Expense types acquirement error!" };
        }
    }
}
