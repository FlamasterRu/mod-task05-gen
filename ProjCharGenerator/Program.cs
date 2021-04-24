using System;
using System.Collections.Generic;
using System.IO;

namespace generator
{
    public class Task1 
    {
        private int[,] arr;
        private Random random = new Random();
        private int sum;
        private string syms = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";

        public Task1(string fileName)
        {
            sum = 0;
            arr = new int[31, 31];
            using (StreamReader sr = new StreamReader(fileName))
            {
                for (int i = 0; i < 31; ++i)
                {
                    string line = sr.ReadLine();
                    string[] temp = line.Split(new Char[] { ' ' });
                    for (int j = 0; j < 31; ++j)
                    {
                        arr[i, j] = Int32.Parse(temp[j]);
                        sum += arr[i, j];
                    }
                }
            }
        }
        public void genText(int num)
        {
            using (StreamWriter sw = new StreamWriter("task1.txt"))
            {
                for (int k = 0; k < num; ++k)
                {
                    int r = random.Next(0, sum);
                    int tempSum = 0;
                    bool flag = true;
                    for (int i = 0; i < 31; ++i)
                    {
                        if (!flag)
                        {
                            break;
                        }
                        for (int j = 0; j < 31; ++j)
                        {
                            if (!flag)
                            {
                                break;
                            }
                            tempSum += arr[i, j];
                            if ((tempSum >= r) && (arr[i, j] != 0))
                            {
                                sw.Write(syms[i]);
                                sw.Write(syms[j]);
                                sw.Write(" ");
                                flag = false;
                            }
                        }
                    }
                }
            }
        }
    }
    public class Task2
    {
        private int[] arr;
        private string[] words;
        private Random random = new Random();
        private int sum;
        public Task2(string fileName)
        {
            sum = 0;
            arr = new int[100];
            words = new string[100];
            using (StreamReader sr = new StreamReader(fileName))
            {
                for (int i = 0; i < 100; ++i)
                {
                    string line = sr.ReadLine();
                    string[] temp = line.Split(new Char[] { ' ' });
                    words[i] = temp[0];
                    arr[i] = Int32.Parse(temp[1]);
                    sum += arr[i];
                }
            }
        }
        public void genText(int num)
        {
            using (StreamWriter sw = new StreamWriter("task2.txt"))
            {
                for (int k = 0; k < num; ++k)
                {
                    int r = random.Next(0, sum);
                    int tempSum = 0;
                    for (int i = 0; i < 100; ++i)
                    {
                        tempSum += arr[i];
                        if (tempSum >= r)
                        {
                            sw.Write(words[i]);
                            sw.Write(" ");
                            break;
                        }
                    }
                }
            }
        }
    }
    public class Task3
    {
        private int[] arr;
        private string[] dwords;
        private Random random = new Random();
        private int sum;
        public Task3(string fileName)
        {
            sum = 0;
            arr = new int[100];
            dwords = new string[100];
            using (StreamReader sr = new StreamReader(fileName))
            {
                for (int i = 0; i < 100; ++i)
                {
                    string line = sr.ReadLine();
                    string[] temp = line.Split(new Char[] { '\t' });
                    dwords[i] = temp[0];
                    arr[i] = Int32.Parse(temp[2]);
                    sum += arr[i];
                }
            }
        }
        public void genText(int num)
        {
            using (StreamWriter sw = new StreamWriter("task3.txt"))
            {
                for (int k = 0; k < num; ++k)
                {
                    int r = random.Next(0, sum);
                    int tempSum = 0;
                    for (int i = 0; i < 100; ++i)
                    {
                        tempSum += arr[i];
                        if (tempSum >= r)
                        {
                            sw.Write(dwords[i]);
                            sw.Write(" ");
                            break;
                        }
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Task1 gen1 = new Task1("bigram.txt");
            gen1.genText(1000);

            Task2 gen2 = new Task2("words.txt");
            gen2.genText(1000);

            Task3 gen3 = new Task3("dwords.txt");
            gen3.genText(1000);
        }
    }
}

