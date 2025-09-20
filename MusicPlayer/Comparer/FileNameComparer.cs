using System;
using System.Text.RegularExpressions;
using System.IO;

namespace MusicPlayer.Comparer;

public class FileNameComparer : IComparer<string>
{
    public int Compare(string? filePath1, string? filePath2)
    {
        var name1 = Path.GetFileName(filePath1 ?? string.Empty);
        var name2 = Path.GetFileName(filePath2 ?? string.Empty);

        var regex = new Regex("^(\\d+)");
        var m1 = regex.Match(name1);
        var m2 = regex.Match(name2);

        var hasNum1 = m1.Success;
        var hasNum2 = m2.Success;

        if (hasNum1 && hasNum2)
        {
            if (int.TryParse(m1.Groups[1].Value, out var n1) && int.TryParse(m2.Groups[1].Value, out var n2))
            {
                var cmp = n1.CompareTo(n2);
                if (cmp != 0) return cmp; // ascendierend
            }

            return string.Compare(name1, name2, StringComparison.Ordinal);
        }

        if (hasNum1 && !hasNum2) return -1;
        if (!hasNum1 && hasNum2) return 1;

        return string.Compare(name1, name2, StringComparison.Ordinal);
    }
}