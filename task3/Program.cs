using System;

public class BracketChecker
{
    public static void Main()
    {
        Console.WriteLine("Введите текст:");
        string input = Console.ReadLine();

        bool balance = check(input);

        if (balance)
        {
            Console.WriteLine("Скобки расставлены правильно.");
        }
        else
        {
            Console.WriteLine("Скобки расставлены неправильно.");

            int count = countLeft(input);
            if (count > 0)
            {
                Console.WriteLine($"Лишние левые скобки. Количество: {count}");
            }
            else
            {
                int indexRight = fintRight(input);
                Console.WriteLine($"Лишние правые скобки. Позиция первой скобки: {indexRight}");
            }
        }
    }

    public static bool check(string text)
    {
        int count = 0;
        foreach (char ch in text)
        {
            if (ch == '(')
            {
                count++;
            }
            else if (ch == ')')
            {
                count--;
                if (count < 0)
                {
                    return false;
                }
            }
        }
        return count == 0;
    }

    public static int countLeft(string text)
    {
        int count = 0;
        foreach (char ch in text)
        {
            if (ch == '(')
            {
                count++;
            }
            else if (ch == ')')
            {
                count--;
                if (count < 0)
                {
                    return 0;
                }
            }
        }
        return count;
    }

    public static int fintRight(string text)
    {
        int count = 0;
        for (int i = 0; i < text.Length; i++)
        {
            char ch = text[i];
            if (ch == '(')
            {
                count++;
            }
            else if (ch == ')')
            {
                count--;
                if (count < 0)
                {
                    return i;
                }
            }
        }
        return -1;
    }
}