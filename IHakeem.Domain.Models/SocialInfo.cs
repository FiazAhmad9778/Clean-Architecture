using iHakeem.SharedKernal.BaseDomain;

namespace iHakeem.Domain.Models
{
    public class SocialInfo : EntityBase<int>
    {
        public string Name { get; set; }
        public string Url { get; set; }

    }
}
