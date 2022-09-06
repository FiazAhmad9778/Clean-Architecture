using FluentValidation;
using iHakeem.Application.EMR.MyPhysicians.Contracts;
using MediatR;
using System;

namespace iHakeem.Application.EMR.MyPhysicians.CommandHandlers.Edit
{
    public class EditMyPhysiciansRequestDTO : IRequest<MyPhysiciansResponseDTO>
    {
        public long Id { get; set; }
        public string PhysicianName { get; set; }
        public string PhysicianLocation { get; set; }
        public string Hospital { get; set; }
        public string PhysicianPhoneNo { get; set; }
        public long? PhysicianSpecialityId { get; set; }
        public string PhysicianNotes { get; set; }

        public class EditMyPhysiciansRequestDTOValidator : AbstractValidator<EditMyPhysiciansRequestDTO>
        {
            public EditMyPhysiciansRequestDTOValidator()
            {
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.PhysicianName).NotEmpty();
            }
        }
    }

}
