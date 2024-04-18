using System;
using System.Linq;
using System.Text;

class Program
{
    static char[] vowels = { 'a', 'i', 'u', 'e', 'o' };

    static void Main()
    {
        bool showMenu = true;
        while (showMenu)
        {
            showMenu = MainMenu();
        }
    }

    static bool MainMenu()
    {
        Console.WriteLine("\n--- Main Menu ---");
        Console.WriteLine("1. Sort Character");
        Console.WriteLine("2. PSBB (Pembatasan Sosial Berskala Besar)");
        Console.WriteLine("3. Exit");
        Console.Write("Choose an option: ");
        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                SortCharacter();
                break;
            case "2":
                PSBB();
                break;
            case "3":
                Console.WriteLine("Exiting program.");
                return false;
            default:
                Console.WriteLine("Invalid option, please try again.");
                break;
        }
        return true;
    }

    static void SortCharacter()
    {
        Console.Write("Input one line of words: ");
        string input = Console.ReadLine().ToLower().Replace(" ", "");

        string vowelsString = SortCharacters(input, true);
        string consonantsString = SortCharacters(input, false);

        Console.WriteLine($"Vowel Characters: {vowelsString}");
        Console.WriteLine($"Consonant Characters: {consonantsString}");
    }

    static string SortCharacters(string input, bool isVowel)
    {
        StringBuilder sortedChars = new StringBuilder();
        foreach (char c in input)
        {
            if ((isVowel && vowels.Contains(c)) || (!isVowel && !vowels.Contains(c)))
            {
                sortedChars.Append(c);
            }
        }
        return new string(sortedChars.ToString().ToCharArray().OrderBy(c => input.IndexOf(c)).ToArray());
    }

    static void PSBB()
    {
        Console.Write("Input the number of families: ");
        int familiesCount = int.Parse(Console.ReadLine());
        Console.Write("Input the number of members in the family (separated by a space): ");
        int[] familyMembers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        if (familiesCount != familyMembers.Length)
        {
            Console.WriteLine("Input must be equal with count of family.");
            return;
        }

        int busesNeeded = CalculateBuses(familyMembers);
        Console.WriteLine($"Minimum bus required is: {busesNeeded}");
    }

    static int CalculateBuses(int[] familyMembers)
    {
        int busesNeeded = 0;
        Array.Sort(familyMembers, (a, b) => b.CompareTo(a));

        int i = 0;
        int j = familyMembers.Length - 1;
        while (i <= j)
        {
            if (familyMembers[i] + familyMembers[j] <= 4 && i != j)
            {
                i++;
                j--;
            }
            else
            {
                i++;
            }
            busesNeeded++;
        }
        return busesNeeded;
    }
}

