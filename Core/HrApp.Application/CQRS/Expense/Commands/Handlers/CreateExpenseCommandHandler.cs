﻿using AutoMapper;
using FluentValidation;
using HrApp.Application.CQRS.Advance.Commands;
using HrApp.Application.Helpers;
using HrApp.Application.Interfaces;
using HrApp.Application.Validators;
using HrApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.Expense.Commands.Handlers
{
    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, ServiceResponse<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<CreateExpenseCommand> validator;

        public CreateExpenseCommandHandler(IMapper mapper, IUow uow, CreateExpenseValidator validator)
        {
            _mapper = mapper;
            _uow = uow;
            this.validator = validator;
        }

        public async Task<ServiceResponse<int>> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                return new ServiceResponse<int>(0) { Message = string.Join(" ", validationResult.Errors), IsSuccess = false };

            var entity = _mapper.Map<HrApp.Domain.Entities.Expense>(request);

            //entity.Document = await ImageConversions.ConvertToByteArrayAsync(request.File);

            await _uow.GetExpenseRepository().AddAsync(entity);

            await _uow.CommitAsync();

            return new ServiceResponse<int>() { Message = "An expense has been added.", IsSuccess = true };

        }
    }
}
