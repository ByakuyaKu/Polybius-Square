using System;
using System.Collections.Generic;
using System.IO;

namespace PolybiusSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            string alph = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ-.?!0123456789";

            Char[,] PolybiusMatrix = new Char[9, 9];

            for (int i = 0, c = 0; i < 9; i++)
                for (int j = 0; j < 9; j++, c++) 
                    PolybiusMatrix[i, j] = alph[c];

            string path = @"D:\GERASKIN\PolybiusSquare\text.txt";
            string InputText = "";

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    InputText = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Text:");
            Console.WriteLine(InputText);

            string res = Encryption(InputText, PolybiusMatrix);
            Console.WriteLine("Result of encryption:");
            Console.WriteLine(res);


            string res1 = Decryption(res, PolybiusMatrix);
            Console.WriteLine("Result of decryption:");
            Console.WriteLine(res1);

            Console.ReadKey();
        }

        static string Encryption(string s, Char[,] m)
        {
            string result = "";
            for (int i = 0; i < s.Length; i++)
                for (int j = 0; j < 9; j++)
                    for (int c = 0; c < 9; c++)
                        if (s[i] == m[j, c])
                        {
                            result += j.ToString() + c.ToString();
                            break;
                        }

            return result;
        }

        static string Decryption(string s, Char[,] m)
        {
            string result = "";

            for (int i = 0; i < s.Length; i += 2)
                result += m[Convert.ToInt32(s[i].ToString()), Convert.ToInt32(s[i+1].ToString())];

            return result;
        }
    }
}
