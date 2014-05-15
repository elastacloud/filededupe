using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace Elastacloud.FileDeduplication
{
    internal class FileContentInfoBuilder
    {
        public IEnumerable<FileContentInfo> Parse(string[] files)
        {
            List<FileContentInfo> infos = new List<FileContentInfo>();

            MD5 hasher = new MD5CryptoServiceProvider();
            files.AsParallel().ForAll((file) =>
            {
                var hashBytes = hasher.ComputeHash(File.ReadAllBytes(file));
                infos.Add(new FileContentInfo() {Path = file, Hash = Convert.ToBase64String(hashBytes)});
            });

            return infos;
        }
    }
}