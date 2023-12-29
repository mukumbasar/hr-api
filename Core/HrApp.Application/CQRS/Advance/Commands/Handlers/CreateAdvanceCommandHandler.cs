using AutoMapper;
using FluentValidation;
using HrApp.Application.Interfaces;
using HrApp.Application.Validators;
using HrApp.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.Advance.Commands.Handlers
{
    public class CreateAdvanceCommandHandler : IRequestHandler<CreateAdvanceCommand, ServiceResponse<decimal>>
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        private readonly UserManager<Domain.Entities.AppUser> _userManager;
        private readonly IValidator<CreateAdvanceCommand> validator;

        public CreateAdvanceCommandHandler(IMapper mapper, IUow uow, UserManager<Domain.Entities.AppUser> userManager, IValidator<CreateAdvanceCommand> validator)
        {
            _mapper = mapper;
            _uow = uow;

            _userManager = userManager;
            this.validator = validator;
        }

        public async Task<ServiceResponse<decimal>> Handle(CreateAdvanceCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return new ServiceResponse<decimal>(0) { Message = string.Join(" ", validationResult.Errors), IsSuccess = false };
            }
            var entity = _mapper.Map<HrApp.Domain.Entities.Advance>(request);

            var user = await _userManager.FindByIdAsync(request.AppUserId);

            await _uow.GetAdvanceRepository().AddAsync(entity);
            var tempList = await _uow.GetAdvanceRepository().GetAllAsync(true, x => x.AppUserId == request.AppUserId);
            var userLeft = user.YearlyAdvanceAmountLeft;
            if (request.Amount > userLeft)
            {
                return new ServiceResponse<decimal>() { Message = $"You have exceeded your yearly advance amount. Current amount left: {user.YearlyAdvanceAmountLeft}", IsSuccess = false };
            }

            user.YearlyAdvanceAmountLeft -= request.Amount;

            await _userManager.UpdateAsync(user);

            await _uow.CommitAsync();

            return new ServiceResponse<decimal>() { Message = $"An advance has been added. Current Amount left: {user.YearlyAdvanceAmountLeft}", IsSuccess = true };

        }
    }
}
