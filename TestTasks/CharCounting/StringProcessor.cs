using System;
using System.Collections.Generic;
using System.Linq;

namespace TestTasks.VowelCounting;

public class StringProcessor
{
    public (char symbol, int count)[] GetCharCount(string veryLongString, char[] countedChars)
    {
        if (veryLongString == null || countedChars == null)
            throw new ArgumentNullException();
            
        if (countedChars.Length == 0)
            throw new ArgumentException("Array is empty.");

        var charCount = new Dictionary<char, int>();

        foreach (var ch in countedChars)
        {
            charCount[char.ToLower(ch)] = 0;
        }

        foreach (var ch in veryLongString.ToLower().Where(ch => charCount.ContainsKey(ch)))
        {
            charCount[ch]++;
        }

        return charCount.Select(kvp => (kvp.Key, kvp.Value)).ToArray();
    }
}