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

namespace HrApp.Application.CQRS.AdvanceType.Queries.Handlers
{
    public class ReadAllAdvanceTypeQueryHandler : IRequestHandler<ReadAllAdvanceTypeQuery, ServiceResponse<List<AdvanceTypeDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public ReadAllAdvanceTypeQueryHandler(IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<ServiceResponse<List<AdvanceTypeDto>>> Handle(ReadAllAdvanceTypeQuery request, CancellationToken cancellationToken)
        {
            var entities = await _uow.GetAdvanceTypeRepository().GetAllAsync(true);

            if (entities.Count() > 0)
            {
                var dtos = new List<AdvanceTypeDto>();

                foreach (var entity in entities)
                {
                    var mappedEntity = _mapper.Map<AdvanceTypeDto>(entity);

                    dtos.Add(mappedEntity);
                }

                return new ServiceResponse<List<AdvanceTypeDto>>(dtos) { IsSuccess = true, Message = "Advance types acquirement successful!" };
            }

            return new ServiceResponse<List<AdvanceTypeDto>>() { IsSuccess = false, Message = "Advance types acquirement error!" };
        }
    }
}
