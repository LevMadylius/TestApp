using System;

namespace TestApp.Model
{

    public class InfoContainer
    {
        public int Dev { get; set; }
        public int Mode { get; set; }
        public int Nlink { get; set; }
        public int Uid { get; set; }
        public int Gid { get; set; }
        public int Rdev { get; set; }
        public int Blksize { get; set; }
        public int Ino { get; set; }
        public int Size { get; set; }
        public int Blocks { get; set; }
        public double AtimeMs { get; set; }
        public long MtimeMs { get; set; }
        public double CtimeMs { get; set; }
        public double BirthtimeMs { get; set; }
        public DateTime Atime { get; set; }
        public DateTime Mtime { get; set; }
        public DateTime Ctime { get; set; }
        public DateTime Birthtime { get; set; }
        public string Path { get; set; }
        public bool Isdir { get; set; }
    }
}
