using iHakeem.SharedKernal.BaseDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace iHakeem.Domain.Models
{
    public class PatientSocialInfo
    {
        public long PatientId { get; set; }
        public int SocialInformationId { get; set; }
        public Patient Patient { get; set; }
        public SocialInfo SocialInformation { get; set; }

        public bool IsDeleted { get; set; }

    }
}
