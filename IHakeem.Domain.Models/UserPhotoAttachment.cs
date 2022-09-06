using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Domain.Models
{
    public class UserPhotoAttachment
    {
        public long FileId { get; set; }

        public virtual File File { get; set; }

        public long UserId { get; set; }
    }
}
