using AutoMapper;
using iHakeem.Application.Blogs.Categories.Contracts;
using Cat=iHakeem.Domain.Models.Categories;
using iHakeem.Domain.Blogs.Categories.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using iHakeem.Infrastructure.Common;
using System.Security.Claims;

namespace iHakeem.Application.Blogs.Categories.CommandHandlers.CreateOrUpdate
{
    public class CreateOrUpdateCategoriesRequestHandler : IRequestHandler<CreateOrUpdateCategoriesRequestDTO, CategoriesResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly ICategoriesRepository _CategoriesRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CreateOrUpdateCategoriesRequestHandler(ICategoriesRepository CategoriesRepository,
            IMapper mapper, IHttpContextAccessor httpContextAccessor,
            IDateTimeProvider dateTimeProvider,
            IUnitOfWork unitOfWork)
        {
            _CategoriesRepository = CategoriesRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<CategoriesResponseDTO> Handle(CreateOrUpdateCategoriesRequestDTO request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                var res = await _CategoriesRepository.GetSingle(request.Id);
                var user = _mapper.Map<Cat>(res);
                var mapResponse = _mapper.Map<CreateOrUpdateCategoriesRequestDTO, Cat>(request, user);
                mapResponse.UpdatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
                mapResponse.UpdatedDate = _dateTimeProvider.PlatformSpecificNow;
                var updatedResponse = _CategoriesRepository.Update(mapResponse);
                await _unitOfWork.SaveChangesAsync();
                return _mapper.Map<CategoriesResponseDTO>(updatedResponse);
            }
            var mapped = _mapper.Map<Cat>(request);
            mapped.CreatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            mapped.CreatedDate = _dateTimeProvider.PlatformSpecificNow;
            var response = await _CategoriesRepository.Add(mapped);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CategoriesResponseDTO>(response);
        }
    }
}
