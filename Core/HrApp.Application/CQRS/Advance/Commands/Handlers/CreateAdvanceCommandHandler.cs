using AutoMapper;
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

        public CreateAdvanceCommandHandler(IMapper mapper, IUow uow, UserManager<Domain.Entities.AppUser> userManager)
        {
            _mapper = mapper;
            _uow = uow;

            _userManager = userManager;
        }

        public async Task<ServiceResponse<decimal>> Handle(CreateAdvanceCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<HrApp.Domain.Entities.Advance>(request);

            var user = await _userManager.FindByIdAsync(request.AppUserId);

            await _uow.GetAdvanceRepository().AddAsync(entity);

            user.YearlyAdvanceAmountLeft -= request.Amount;

            await _userManager.UpdateAsync(user);

            await _uow.CommitAsync();

            return new ServiceResponse<decimal>() { Message = $"An advance has been added. Current Amount left: {user.YearlyAdvanceAmountLeft}", IsSuccess = true };
            
        }
    }
}
