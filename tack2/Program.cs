Queue queue = new Queue();
string com;
do
{
    Console.WriteLine("Введите команду:");
    com = Console.ReadLine();

    switch (com)
    {
        case "push":
            int n = Convert.ToInt32(Console.ReadLine());
            queue.Push(n);
            break;
        case "pop":
            Console.WriteLine(queue.Pop());
            break;
        case "front":
            queue.Front();
            break;
        case "size":
            queue.Size();
            break;
        case "clear":
            queue.Clear();
            break;
        case "exit":
            Console.WriteLine("bye");
            break;
        default:
            Console.WriteLine("Error. Попробуйте еще раз.");
            break;

    }
} while (com != "Exit");


public class Queue
{
    private int[] elements;
    private int top;
    public Queue()
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
        int k = 0;
        if (top != -1)
        {
            k = elements[0];
            for (int i = 0; i < top; i++)
            {
                elements[i] = elements[i + 1];
            }
            top--;
        }
        else
        {
            Console.WriteLine("Ошибка");
        }
        return k;
    }

    public void Front()
    {
        if (top != -1)
        {
            Console.WriteLine(elements[0]);
        }
        else
        {
            Console.WriteLine("Ошибка");
        }
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