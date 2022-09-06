using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Application.Users.CodeVerfication.CommandHandler.Generate
{
    public class GenerateCodeRequestDTO : IRequest<Unit>
    {
        public long UserId { get; set; }
    }
}
