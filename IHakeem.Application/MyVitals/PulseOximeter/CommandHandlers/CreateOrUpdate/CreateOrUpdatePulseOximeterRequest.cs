using iHakeem.Application.MyVitals.PulseOximeter.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Application.MyVitals.PulseOximeter.CommandHandlers.CreateOrUpdate
{
    public class CreateOrUpdatePulseOximeterRequestDTO : IRequest<PulseOximeterResponseDTO>
    {
        public long Id { get; set; }
        public float BloodOxygen { get; set; }
        public float PulseRate { get; set; }
        public DateTime PulseOximeterDateAndTime { get; set; }
    }
}
