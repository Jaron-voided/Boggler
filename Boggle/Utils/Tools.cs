namespace Boggle.Utils;

public class Tools
{
    internal static char QuToQ(string letters)
    {
        char letter;
        if (letters.Equals("QU", StringComparison.CurrentCultureIgnoreCase))
            letter = 'Q';
        else
            letter = letters.ToUpper()[0];
        
        return letter;
    }

    internal static void AddLettersToWord(char[] letters, char letter)
    {
        if (letter.Equals('Q'))
        {
            letters.Append('Q');
            letters.Append('U');
        }
        else
            letters.Append(letter);
        
    }
}