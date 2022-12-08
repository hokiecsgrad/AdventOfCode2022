using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day07;

public class File
{
    public string Name { get; set; } = String.Empty;
    public FileType Type { get; set; }
    public int Size { get; set; } = 0;
    public File? parent { get; set; } = null;
    public List<File> Files { get; set; } = new();
}