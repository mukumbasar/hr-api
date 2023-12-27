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
    public class ReadAllAdvanceQueryHandler : IRequestHandler<ReadAllAdvanceQuery, ServiceResponse<List<AdvanceDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public ReadAllAdvanceQueryHandler(IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<ServiceResponse<List<AdvanceDto>>> Handle(ReadAllAdvanceQuery request, CancellationToken cancellationToken)
        {
            var entities = await _uow.GetAdvanceRepository().GetAllAsync(true, null, x => x.Currency, x => x.AdvanceType, x => x.ApprovalStatus);

            if(entities.Count() > 0)
            {
                var dtos = new List<AdvanceDto>();

                foreach(var entity in entities) 
                { 
                    var mappedEntity = _mapper.Map<AdvanceDto>(entity);

                    mappedEntity.ApprovalStatus = entity.ApprovalStatus.Name;
                    mappedEntity.Currency = entity.Currency.Name;
                    mappedEntity.AdvanceTypeName = entity.AdvanceType.Name;

                    dtos.Add(mappedEntity);
                }

                return new ServiceResponse<List<AdvanceDto>>(dtos) { IsSuccess = true, Message = "Advance acquirement successful!" };
            }

            return new ServiceResponse<List<AdvanceDto>>() { IsSuccess = false, Message = "Advance acquirement error!" };
        }
    }
}
