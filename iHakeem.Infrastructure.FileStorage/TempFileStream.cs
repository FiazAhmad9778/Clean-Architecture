using System.IO;

namespace iHakeem.Infrastructure.FileStorage.FileSystem
{
    public class TempFileStream : Stream
    {
        private readonly string _fileName;
        private readonly FileStream _fileStream;

        public TempFileStream()
        {
            _fileName = Path.GetTempFileName();
            _fileStream = File.Open(_fileName, FileMode.Open, FileAccess.ReadWrite);
        }

        public override bool CanRead => _fileStream.CanRead;

        public override bool CanSeek => _fileStream.CanSeek;

        public override bool CanWrite => _fileStream.CanWrite;

        public override long Length => _fileStream.Length;

        public override long Position
        {
            get => _fileStream.Position;
            set => _fileStream.Position = value;
        }

        public override void Flush()
        {
            _fileStream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _fileStream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _fileStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _fileStream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _fileStream.Write(buffer, offset, count);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _fileStream.Dispose();
                File.Delete(_fileName);
            }
        }
    }
}
