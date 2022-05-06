using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
namespace lab_04;
public class Program
{
    public static void Main()
    {
        IDictionary<string, List<long>> nodes = new Dictionary<string, List<long>>();
        List<long> directoryproperties = new List<long> { 0, 0 };
        List<long> fileproperties = new List<long> { 0, 0 };
        long thisfilesSize = 0;
        foreach (FileInfo file in File.allFiles)
        {
            File.thisfolderfiles.Add(new File() { Name = file.Name, Path = file.FullName, Size = file.Length / 1024, Extension = file.Extension, Firstletter = file.Name.Substring(0, 1), Type = "" });
            thisfilesSize = thisfilesSize + file.Length;
        }
        List<File> subfiles = new List<File>();
        DirectoryInfo[] subFolders = File.folder.GetDirectories();

        foreach (DirectoryInfo dir in subFolders)
        {
            FileInfo[] thisfolder = dir.GetFiles();
            foreach (FileInfo file in thisfolder)
            {
                subfiles.Add(new File() { Name = file.Name, Path = file.FullName, Size = file.Length / 1024, Extension = file.Extension, Firstletter = file.Name.Substring(0, 1), Type = "" });
                directoryproperties[1] = directoryproperties[1] + file.Length / 1024;
            }
        }
        File.Files.AddRange(File.thisfolderfiles);
        File.Files.AddRange(subfiles);
        directoryproperties[0] = Directory.GetDirectories(@"c:\programowanie\").Length;
        long filesSize = 0;
        int filesCount = 0;
        foreach (File file in File.Files)
        {
            fileproperties[0]++;
            fileproperties[1] = fileproperties[1] + file.Size;
            filesSize = filesSize + file.Size;
            filesCount++;
        }
        nodes.Add("directories", directoryproperties);
        nodes.Add("files", fileproperties);
        Console.WriteLine("Nodes:");
        Console.WriteLine(String.Format("{0,-26}{1,-13}{2,-16}", " ", "[count]", "[total size]"));
        foreach (KeyValuePair<string, List<long>> pair in nodes)
        Console.WriteLine(String.Format("{0,-8}{1,-19}{2,-13}{3,-16}", " ", pair.Key, pair.Value[0], pair.Value[1] + " KB"));
        Console.WriteLine("Files:");
        By_types.Print();
        By_extensions.Print();
        By_sizes.Print();
        Count_by_first_letter.Print();
        Ordered_by_name.Print();
        Ordered_by_sizes.Print();
    }
}