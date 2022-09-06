using iHakeem.Application.Common.Contracts.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace iHakeem.Api.Controllers
{

    public abstract class ApiControllerBase : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiController"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        protected ApiControllerBase(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Gets the mediator.
        /// </summary>
        /// <value>
        /// The mediator.
        /// </value>
        protected IMediator Mediator => _serviceProvider.GetRequiredService<IMediator>();

        public IActionResult HandleResponse<T>(T response)
        {

            return Ok(new ResponseDto<T>() { Data = response, Status = 1 });
        }
    }
}