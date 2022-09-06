using System.Collections.Generic;
using iHakeem.SharedKernal.BaseDomain;

namespace iHakeem.Domain.Models
{
    public class MedicalDepartment : EntityBase<long>
    {
        public string Code { get; set; }
        public string Logo { get; set; }
        public int NameId { get; set; }

        public int DescriptionId { get; set; }
        public virtual LocalizationSet Name { get; set; }
        public virtual LocalizationSet Description { get; set; }
    }


}
