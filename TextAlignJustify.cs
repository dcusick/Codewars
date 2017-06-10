using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution 
{
  public class Kata
  {
    public static string Justify(string str, int len)
    {  
      int curPosition = 0;
      var lines = new List<string>();
      var EOF = false;
      
      if (string.IsNullOrEmpty(str)) return "";
      
      while (curPosition < str.Length)
      {
        if (curPosition+len > str.Length)
        {
          len =  str.Length - curPosition -1 ;
          EOF = true;
        }
        //var lwp = curPosition+len;
        var lwp = EOF ? str.Length - curPosition : str.Substring(curPosition, len+1).LastIndexOf(" ");
        
        Console.Error.WriteLine(str.Substring(curPosition, len));
        Console.Error.WriteLine(curPosition);
        
        //var lwp = str.Substring(curPosition, len+1).LastIndexOf(" ");
         
        Console.Error.WriteLine(string.Format("lwp: {0}, len: {1}, curPos: {2}", lwp, len, curPosition));
        if (lwp == -1) lwp = len;

        var spacesToFill = len - lwp; // - curPosition;
        var words = str.Substring(curPosition, lwp).Split(' ').ToList();
        int wordCount = words.Count();
        
        Console.Error.WriteLine("WordCount: "+wordCount);
        Console.Error.WriteLine(wordCount==1); // ? "Y" : "N");
        var spacesPer = wordCount == 1 ? 1 : (spacesToFill / (wordCount-1));
        var spacesLeft = wordCount == 1 ? spacesToFill : spacesToFill % (wordCount-1);
        
        var newStr = string.Join(" ", words.Select(w => w + new string(' ', spacesPer + (words.FindIndex(ww => ww == w) < spacesLeft ? 1 : 0))));
 
        Console.Error.WriteLine(string.Format("lwp: {0}, spToFill: {1}, spPer: {2}, spLeft: {3}, wordCount: {4}", lwp, spacesToFill, spacesPer, spacesLeft, words.Count()));
        
        lines.Add(newStr.Trim());
        Console.Error.WriteLine(newStr);

        curPosition += lwp+1; // lastWord;
      }
      
      return string.Join("\n", lines);
    }
  }
}