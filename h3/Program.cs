using System.Xml.Linq;

Stack stack = new Stack();
string com;
do
{
    Console.WriteLine("Введите команду:");
    com = Console.ReadLine();

    switch (com)
    {
        case "push":
            int n = Convert.ToInt32(Console.ReadLine());
            stack.Push(n);
            break;
        case "pop":
            Console.WriteLine(stack.Pop());
            break;
        case "back":
            stack.Back();
            break;
        case "size":
            stack.Size();
            break;
        case "clear":
            stack.Clear();
            break;
        case "exit":
            Console.WriteLine("bye");
            break;
        default:
            Console.WriteLine("Error. Попробуйте еще раз.");
            break;

    }
} while (com != "Exit");


public class Stack
{
    private int[] elements;
    private int top;
    public Stack()
    {
        elements = new int[100];
        top = -1;
    }

    public void Push(int n)
    {
        elements[++top] = n;
        Console.WriteLine("ok");
    }

    public int Pop()
    { 
        int k = elements[top];
        elements[top] = 0;
        top--;
        return k;
    }

    public void Back()
    {
        Console.WriteLine(elements[top]);
    }

    public void Size()
    {
        Console.WriteLine(top + 1);
    }

    public void Clear()
    {
        Array.Clear(elements, 0, elements.Length);
        top = -1;
        Console.WriteLine("ok");
    }
}