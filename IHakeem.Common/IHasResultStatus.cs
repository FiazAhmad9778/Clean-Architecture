using System.Collections.Generic;

namespace iHakeem.SharedKernal
{
    public interface IHasResultStatus
    {
        bool Succeeded { get; }

        IReadOnlyCollection<string> Errors { get; set; }
    }
}
