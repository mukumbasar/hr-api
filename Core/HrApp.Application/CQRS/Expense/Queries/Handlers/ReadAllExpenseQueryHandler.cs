using AutoMapper;
using HrApp.Application.CQRS.Advance.Queries;
using HrApp.Application.Dtos;
using HrApp.Application.Interfaces;
using HrApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.Expense.Queries.Handlers
{
    public class ReadAllExpenseQueryHandler : IRequestHandler<ReadAllExpenseQuery, ServiceResponse<List<ExpenseDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public ReadAllExpenseQueryHandler(IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<ServiceResponse<List<ExpenseDto>>> Handle(ReadAllExpenseQuery request, CancellationToken cancellationToken)
        {
            var entities = await _uow.GetExpenseRepository().GetAllAsync(true, null, x => x.Currency, x => x.ExpenseType, x => x.ApprovalStatus, x => x.AppUser);


            var dtos = new List<ExpenseDto>();
            if (request.companyId != null)
            {
                entities = entities.Where(x => x.AppUser.CompanyId == request.companyId).ToList();
            }

            foreach (var entity in entities)
            {
                var mappedEntity = _mapper.Map<ExpenseDto>(entity);

                mappedEntity.ApprovalStatus = entity.ApprovalStatus.Name;
                mappedEntity.Currency = entity.Currency.Name;
                mappedEntity.ExpenseTypeName = entity.ExpenseType.Name;
                mappedEntity.Name = entity.AppUser.Name;
                mappedEntity.SecondName = entity.AppUser.SecondName;
                mappedEntity.Surname = entity.AppUser.Surname;
                mappedEntity.SecondName = entity.AppUser.SecondName;

                dtos.Add(mappedEntity);
            }

            return new ServiceResponse<List<ExpenseDto>>(dtos) { Message = "", IsSuccess = true };
        }
    }
}
