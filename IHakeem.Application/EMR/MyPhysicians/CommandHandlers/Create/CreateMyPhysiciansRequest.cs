using FluentValidation;
using iHakeem.Application.EMR.MyPhysicians.Contracts;
using MediatR;
using System;

namespace iHakeem.Application.EMR.MyPhysicians.CommandHandlers.Create
{
    public class CreateMyPhysiciansRequestDTO : IRequest<MyPhysiciansResponseDTO>
    {
        public string PhysicianName { get; set; }
        public string PhysicianLocation { get; set; }
        public string Hospital { get; set; }
        public string PhysicianPhoneNo { get; set; }
        public long? PhysicianSpecialityId { get; set; }
        public string PhysicianNotes { get; set; }


        public class CreateMyPhysiciansRequestDTOValidator : AbstractValidator<CreateMyPhysiciansRequestDTO>
        {
            public CreateMyPhysiciansRequestDTOValidator()
            {
                RuleFor(x => x.PhysicianName).NotEmpty();
            }
        }
    }

}
