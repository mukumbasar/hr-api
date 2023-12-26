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
        private readonly IAdvanceRepository _advanceRepository;

        public ReadAdvanceQueryHandler(IMapper mapper, IAdvanceRepository advanceRepository)
        {
            _mapper = mapper;
            _advanceRepository = advanceRepository;
        }

        public async Task<ServiceResponse<AdvanceDto>> Handle(ReadAdvanceQuery request, CancellationToken cancellationToken)
        {
            var entity = await _advanceRepository.GetAsync(true, x => x.Id == request.Id, x => x.Currency, x => x.AdvanceType, x => x.ApprovalStatus);

            if(entity != null)
            {
                var dto = _mapper.Map<AdvanceDto>(entity);

                dto.ApprovalStatus = entity.ApprovalStatus.Name;
                dto.Currency = entity.Currency.Name;
                dto.AdvanceTypeName = entity.AdvanceType.Name;

                return new ServiceResponse<AdvanceDto>(dto) { Success = true } ;
            }

            return new ServiceResponse<AdvanceDto>() { Message = "Advance acquirement error!", Success = false };
        }
    }
}
