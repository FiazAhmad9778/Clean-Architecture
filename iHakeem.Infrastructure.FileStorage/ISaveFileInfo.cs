using System;
using System.IO;

namespace iHakeem.Infrastructure.FileStorage
{
    public interface ISaveFileInfo
    {
        string ContentType { get; }

        Stream GetStream { get; }
    }
}
