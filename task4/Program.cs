using System;

using System;

    public class DoublyNode<T>
    {
        public DoublyNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public DoublyNode<T> Previous { get; set; }
        public DoublyNode<T> Next { get; set; }
    }

    public class Deque<T>
    {
        private DoublyNode<T> head;
        private DoublyNode<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            if (Count == 0)
            {
                head = node;
                tail = node;
            }
            else
            {
                node.Next = head;
                head.Previous = node;
                head = node;
            }
            Count++;
        }

        public void AddLast(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            if (Count == 0)
            {
                head = node;
                tail = node;
            }
            else
            {
                node.Previous = tail;
                tail.Next = node;
                tail = node;
            }
            Count++;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Дек пуст");
            }
            T data = head.Data;
            if (Count == 1)
            {
                head = null;
                tail = null;
            }
            else
            {
                head = head.Next;
                head.Previous = null;
            }
            Count--;
            return data;
        }

        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Дек пуст");
            }
            T data = tail.Data;
            if (Count == 1)
            {
                head = null;
                tail = null;
            }
            else
            {
                tail = tail.Previous;
                tail.Next = null;
            }
            Count--;
            return data;
        }

        public int[] Find(T data)
        {
            int[] indexes = new int[Count];
            int i = 0;
            int k = 0;
            DoublyNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    indexes[k] = i;
                    k++;
                }
                i++;
                current = current.Next;
            }
            if (k == 0)
            {
                return null;
            }
            else
            {
                Array.Resize(ref indexes, k);
                return indexes;
            }
        }
        public void Print()
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Deque<int> deque = new Deque<int>();
            Console.WriteLine("Выберите одну из следующих операций:");
            Console.WriteLine("1 - добавить элемент в начало дека");
            Console.WriteLine("2 - добавить элемент в конец дека");
            Console.WriteLine("3 - удалить элемент из начала дека");
            Console.WriteLine("4 - удалить элемент из конца дека");
            Console.WriteLine("5 - найти элемент в деке");
            Console.WriteLine("6 - печать элементов дека");
            Console.WriteLine("0 - выход из программы");
            Console.WriteLine();

            bool exit = false;
            while (!exit)
            {
                Console.Write("Введите номер операции: ");
                string input = Console.ReadLine();
                int choice;
                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Введите значение элемента: ");
                            input = Console.ReadLine();
                            int data;
                            if (int.TryParse(input, out data))
                            {
                                deque.AddFirst(data);
                                Console.WriteLine("Элемент добавлен в начало дека");
                            }
                            else
                            {
                                Console.WriteLine("Неверный формат ввода");
                            }
                            break;
                        case 2:
                            Console.Write("Введите значение элемента: ");
                            input = Console.ReadLine();
                            if (int.TryParse(input, out data))
                            {
                                deque.AddLast(data);
                                Console.WriteLine("Элемент добавлен в конец дека");
                            }
                            else
                            {
                                Console.WriteLine("Неверный формат ввода");
                            }
                            break;
                        case 3:
                            try
                            {
                                data = deque.RemoveFirst();
                                Console.WriteLine("Элемент {0} удален из начала дека", data);
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        case 4:
                            try
                            {
                                data = deque.RemoveLast();
                                Console.WriteLine("Элемент {0} удален из конца дека", data);
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        case 5:
                            Console.Write("Введите значение элемента: ");
                            input = Console.ReadLine();
                            if (int.TryParse(input, out data))
                            {
                                int[] indexes = deque.Find(data);
                                if (indexes == null)
                                {
                                    Console.WriteLine("Элемент не найден в деке");
                                }
                                else
                                {
                                    Console.WriteLine("Элемент найден в деке на следующих позициях:");
                                    foreach (int index in indexes)
                                    {
                                        Console.Write(index + " ");
                                    }
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Неверный формат ввода");
                            }
                            break;
                        case 6:
                            Console.WriteLine("Элементы дека:");
                            deque.Print();
                            break;
                        case 0:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Неверный номер операции");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Неверный формат ввода");
                }
                Console.WriteLine();
            }
        }
    }
