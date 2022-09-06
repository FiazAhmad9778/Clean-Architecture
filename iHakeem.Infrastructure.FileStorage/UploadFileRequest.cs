using System;
using System.IO;

namespace iHakeem.Infrastructure.FileStorage
{
    public class UploadFileRequest : ISaveFileInfo
    {
        public string ContentType { get; set; }

        public int SizeBytes { get; set; }

        public string FileName { get; set; }

        public Stream GetStream { get; set; }
    }
}
