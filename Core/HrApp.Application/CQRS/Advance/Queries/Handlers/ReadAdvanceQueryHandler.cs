using AutoMapper;
using HrApp.Application.Dtos;
using HrApp.Application.Interfaces;
using HrApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.Advance.Queries.Handlers
{
    public class ReadAdvanceQueryHandler : IRequestHandler<ReadAdvanceQuery, ServiceResponse<AdvanceDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public ReadAdvanceQueryHandler(IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<ServiceResponse<AdvanceDto>> Handle(ReadAdvanceQuery request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetAdvanceRepository().GetAsync(true, x => x.Id == request.Id, x => x.Currency, x => x.AdvanceType, x => x.ApprovalStatus);

            if(entity != null)
            {
                var dto = _mapper.Map<AdvanceDto>(entity);

                dto.ApprovalStatus = entity.ApprovalStatus.Name;
                dto.Currency = entity.Currency.Name;
                dto.AdvanceTypeName = entity.AdvanceType.Name;

                return new ServiceResponse<AdvanceDto>(dto) { IsSuccess = true , Message = $"Acquirement of {dto.Id} has been successful." } ;
            }

            return new ServiceResponse<AdvanceDto>() { IsSuccess = false, Message = $"Acquirement of {request.Id} has not been successful." };
        }
    }
}
