using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Application.Common.Contracts.Common
{
    public abstract class BaseRequest<TData> : IRequest
    {
        protected BaseRequest()
        {
        }

        protected BaseRequest(TData data)
        {
            Data = data;
        }

        public TData Data { get; set; }
    }

    public abstract class BaseRequest<TData, TResponse> : IRequest<TResponse>
    {
        protected BaseRequest()
        {
        }

        protected BaseRequest(TData data)
        {
            Data = data;
        }

        public TData Data { get; set; }
    }
}
