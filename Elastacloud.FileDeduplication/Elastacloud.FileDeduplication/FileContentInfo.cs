using System.Diagnostics;

namespace Elastacloud.FileDeduplication
{
    [DebuggerDisplay("{Hash} of {Path}")]
    internal class FileContentInfo
    {
        public string Hash { get; set; }
        public string Path { get; set; }
    }
}