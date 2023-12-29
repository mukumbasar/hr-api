using AutoMapper;
using FluentValidation;
using HrApp.Application.Interfaces;
using HrApp.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.Advance.Commands.Handlers
{
    public class UpdateAdvanceCommandHandler : IRequestHandler<UpdateAdvanceCommand, ServiceResponse<decimal>>
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        private readonly UserManager<Domain.Entities.AppUser> _userManager;
        private readonly IValidator<UpdateAdvanceCommand> validator;

        public UpdateAdvanceCommandHandler(IMapper mapper, IUow uow, UserManager<Domain.Entities.AppUser> userManager, IValidator<UpdateAdvanceCommand> validator)
        {
            _mapper = mapper;
            _uow = uow;
            _userManager = userManager;
            this.validator = validator;
        }

        public async Task<ServiceResponse<decimal>> Handle(UpdateAdvanceCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return new ServiceResponse<decimal>(0) { Message = string.Join(" ", validationResult.Errors), IsSuccess = false };
            }
            var user = await _userManager.FindByIdAsync(request.AppUserId);

            var entity = _uow.GetAdvanceRepository().GetAsync(true, x => x.Id == request.Id).Result;
            var oldAdvance = entity.Amount;
            entity = _mapper.Map<HrApp.Domain.Entities.Advance>(request);
            var newAdvance = entity.Amount;
            var totalAdvance = newAdvance - oldAdvance;
            if (user.YearlyAdvanceAmountLeft < totalAdvance)
            {
                return new ServiceResponse<decimal>(user.YearlyAdvanceAmountLeft) { Message = $"The advance has not been updated: You only have {user.YearlyAdvanceAmountLeft}", IsSuccess = false };
            }
            user.YearlyAdvanceAmountLeft -= newAdvance - oldAdvance;
            await _userManager.UpdateAsync(user);
            await _uow.GetAdvanceRepository().UpdateAsync(entity);

            await _uow.CommitAsync();

            return new ServiceResponse<decimal>(user.YearlyAdvanceAmountLeft) { Message = $"The advance has been updated: You have {user.YearlyAdvanceAmountLeft}", IsSuccess = true };
        }
    }
}
