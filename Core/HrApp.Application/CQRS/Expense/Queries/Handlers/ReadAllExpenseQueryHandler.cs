﻿using AutoMapper;
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
        private readonly IExpenseRepository _expenseRepository;

        public ReadAllExpenseQueryHandler(IMapper mapper, IExpenseRepository expenseRepository)
        {
            _mapper = mapper;
            _expenseRepository = expenseRepository;
        }

        public async Task<ServiceResponse<List<ExpenseDto>>> Handle(ReadAllExpenseQuery request, CancellationToken cancellationToken)
        {
            var entities = await _expenseRepository.GetAllAsync(true, null, x => x.Currency, x => x.ExpenseType, x => x.ApprovalStatus);

            if (entities.Count() > 0)
            {
                var dtos = new List<ExpenseDto>();

                foreach (var entity in entities)
                {
                    var mappedEntity = _mapper.Map<ExpenseDto>(entity);

                    mappedEntity.ApprovalStatus = entity.ApprovalStatus.Name;
                    mappedEntity.Currency = entity.Currency.Name;
                    mappedEntity.ExpenseTypeName = entity.ExpenseType.Name;

                    dtos.Add(mappedEntity);
                }

                return new ServiceResponse<List<ExpenseDto>>(dtos) { Success = true };
            }

            return new ServiceResponse<List<ExpenseDto>>() { Message = "Expense acquirement error!", Success = false };
        }
    }
}
