using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_04
{
    public class File : IEnumerable<File>
    {
        private string name;
        private string path;
        private long size;
        private string extension;
        private string firstletter;
        private string type;
        public string Name { get => name; set => name = value; }
        public string Path { get => path; set => path = value; }
        public long Size { get => size; set => size = value; }
        public string Extension { get => extension; set => extension = value; }
        public string Firstletter { get => firstletter; set => firstletter = value; }
        public string Type { get => type; set => type = value; }

        public File(string name, string path, long size, string extension, string firstletter, string type)
        {
            this.name = name;
            this.path = path;
            this.size = size;
            this.extension = extension;
            this.firstletter = firstletter;
            this.type = type;
        }
        public File()
        {

        }

        public virtual void Print(string prefix)
        {

        }

        public static DirectoryInfo folder = new DirectoryInfo("C://programowanie");
        public static List<File> thisfolderfiles = new List<File>();
        public static FileInfo[] allFiles = folder.GetFiles();
        private static List<File> files = new List<File>();
        public void Allfiles()
        {
            foreach (FileInfo file in allFiles)
            {
                thisfolderfiles.Add(new File() { Name = file.Name, Path = file.FullName, Size = file.Length / 1024, Extension = file.Extension, Firstletter = file.Name.Substring(0, 1), Type = "" });
            }
            List<File> subfiles = new List<File>();
            DirectoryInfo[] subFolders = folder.GetDirectories();
            foreach (DirectoryInfo dir in subFolders)
            {
                FileInfo[] thisfolder = dir.GetFiles();
                foreach (FileInfo file in thisfolder)
                {
                    subfiles.Add(new File() { Name = file.Name, Path = file.FullName, Size = file.Length / 1024, Extension = file.Extension, Firstletter = file.Name.Substring(0, 1), Type = "" });
                }
            }
            files.AddRange(thisfolderfiles);
            files.AddRange(subfiles);
        }
        public static List<File> Files
        {
            get { return files; }
        }
        public IEnumerator<File> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}