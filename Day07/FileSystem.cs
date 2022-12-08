using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day07;

public class FileSystem
{
    public File RootNode { get; set; } = new();

    public FileSystem()
    {
        RootNode = new File()
        {
            Name = "/",
            Size = 0,
            Type = FileType.Directory
        };
    }

    public File? FindDirectory(string target)
    {
        File? file = null;
        file = SearchDirectories(RootNode, target);
        return file;
    }

    private File? SearchDirectories(File curr, string target)
    {
        if (curr.Name == target) return curr;

        File? file = null;
        foreach (File item in curr.Files)
        {
            if (item.Type == FileType.Directory && file is null)
                file = SearchDirectories(item, target);
        }

        return file;
    }

    public List<int> ListAllDirectorySizes()
    {
        List<int> dirSizes = new();
        dirSizes = AddDirectorySizesToList(RootNode);
        return dirSizes;
    }

    private List<int> AddDirectorySizesToList(File curr)
    {
        List<int> dirSizes = new();
        foreach (var item in curr.Files)
        {
            if (item.Type == FileType.Directory)
            {
                if (item.Size > 0) dirSizes.Add(item.Size);
                dirSizes.AddRange(AddDirectorySizesToList(item));
            }
        }
        return dirSizes;
    }
}