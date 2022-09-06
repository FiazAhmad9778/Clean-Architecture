
using System.Collections.Generic;

namespace iHakeem.Domain.Models
{
    public class LocalizationSet
    {
        public int Id { get; set; }

        public virtual ICollection<Localization> Localizations { get; set; }
    }
}