using iHakeem.Application.EMR.DetailPregnancies.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Application.EMR.DetailPregnancies.CommandHandlers.CreateOrUpdate
{
    public class CreateOrUpdateDetailPregnanciesRequestDTO : IRequest<DetailPregnanciesResponseDTO>
    {
        public long Id { get; set; }
        public DateTime DeliveryDate { get; set; }
        public long DeliveryTypeId { get; set; }
        public long GenderId { get; set; }
        public string NumberOfPregnancies { get; set; }
        public string NumberOfLivingChildrens { get; set; }
        public string NumberOfAbortions { get; set; }
        public string NumberOfMiscarriages { get; set; }
        public string Notes { get; set; }
    }
}
