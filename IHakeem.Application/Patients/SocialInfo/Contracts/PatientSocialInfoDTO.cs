using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Application.Patients.SocialInfo.Contracts
{
    public class PatientSocialInfoDTO
    {
        public long PatientId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
