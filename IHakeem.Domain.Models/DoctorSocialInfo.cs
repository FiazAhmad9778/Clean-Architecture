using iHakeem.SharedKernal.BaseDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Domain.Models
{
    public class DoctorSocialInfo
    {
        public long DoctorId { get; set; }
        public int SocialInformationId { get; set; }
        public Doctor Doctor { get; set; }
        public SocialInfo SocialInformation { get; set; }

        public bool IsDeleted { get; set; }

    }
}
