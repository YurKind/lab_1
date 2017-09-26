using System;

namespace lab1.Properties
{
    public static class Program
    {
        public static void Start()
        {
            while (true)
            {
                String commandLine = Console.ReadLine();

                string[] command = commandLine.Split(' ');

                switch (command[0])
                {
                    case Commands.test:
                        try
                        {
                            Console.WriteLine("Итераций: " + Comparator.Iterations +
                                          ", Размер массива: " + Comparator.Sequence.Length);
                            Console.WriteLine("Bubble sort: " + Comparator.Test(Sort.BubbleSort, Comparator.Sequence) +
                                              " микро секунд");
                            Console.WriteLine("Shell sort: " + Comparator.Test(Sort.ShellSort, Comparator.Sequence) +
                                              " микро секунд");
                            Console.WriteLine("Quick sort: " + Comparator.Test(Sort.QuickSort, Comparator.Sequence) + 
                                              " микросекунд");
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine(
                                "Для начала теста требуется задать последовательность");
                        }
                        break;

                    case Commands.help:
                        FileReader.readFile(@"..\..\Resources\help.txt");
                        break;

                    case Commands.sequence:
                        Comparator.Sequence = new long[command.Length - 1];

                        try
                        {
                            for (int i = 0; i < command.Length - 1; i++)
                            {
                                Comparator.Sequence[i] = Convert.ToInt32(command[i + 1]);
                            }
                            Console.WriteLine("Последовательность установлена");
                        }
                        catch (FormatException)
                        {
                            Comparator.Sequence = null;
                            Console.WriteLine("Числа последовательности требуется вводить через пробел");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Вы ввели недопустимо малое или недопустимо большое число");
                        }

                        break;

                    case Commands.iterations:
                        try
                        {
                            Comparator.Iterations = Convert.ToInt32(command[1]);
                            Console.WriteLine("Количество итераций: " + command[1]);
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Вы ввели недопустимо малое или недопустимо большое число");
                        }
                        break;

                    case Commands.random:
                        try
                        {
                            long arrayLength = Convert.ToInt32(command[1]);
                            Random random = new Random();
                            Comparator.Sequence = new long[arrayLength];

                            for (int i = 0; i < arrayLength; i++)
                            {
                                Comparator.Sequence[i] = random.Next(-100, 100);
                            }
                            Console.WriteLine("Задана случайная последовательность длинной " + arrayLength);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Длина последовательности указана неверно");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Укажите длину последовательности");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Вы ввели недопустимо малое или недопустимо большое число");
                        }

                        break;

                    case Commands.exit:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Вы ввели несуществующую команду");
                        break;
                }
            }
        }
    }
}