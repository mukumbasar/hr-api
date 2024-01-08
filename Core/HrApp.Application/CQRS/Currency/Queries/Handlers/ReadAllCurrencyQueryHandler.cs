using AutoMapper;
using HrApp.Application.CQRS.AdvanceType.Queries;
using HrApp.Application.Dtos;
using HrApp.Application.Interfaces;
using HrApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.CQRS.Currency.Queries.Handlers
{
    public class ReadAllCurrencyQueryHandler : IRequestHandler<ReadAllCurrencyQuery, ServiceResponse<List<CurrencyDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public ReadAllCurrencyQueryHandler(IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<ServiceResponse<List<CurrencyDto>>> Handle(ReadAllCurrencyQuery request, CancellationToken cancellationToken)
        {
            var entities = await _uow.GetCurrencyRepository().GetAllAsync(true);

            var dtos = new List<CurrencyDto>();

            foreach (var entity in entities)
            {
                var mappedEntity = _mapper.Map<CurrencyDto>(entity);

                dtos.Add(mappedEntity);
            }

            return new ServiceResponse<List<CurrencyDto>>(dtos) { IsSuccess = true, Message = "" };
        }
    }
}
