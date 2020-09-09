using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StreamReader
{
    class Program
    {
        static int a = 0;
        static int e = 0;
        static int i = 0;
        static int o = 0;
        static int u = 0;

        public static string SetType(Stream stream, char firstChar)
        {
            if (stream.Consoants.Contains(firstChar.ToString().ToUpper()))
            {
                return "C";
            }

            if (stream.Vogals.Contains(firstChar.ToString().ToUpper()))
            {
                return "V";
            }

            return string.Empty;
        }

        public static int GetCharIndex(Stream stream, KeyValuePair<char,int> item)
        {
            var result = int.MinValue;
            var resultAuxU = stream.Characters.IndexOf(item.Key.ToString().ToUpper());
            var resultAuxL = stream.Characters.IndexOf(item.Key.ToString().ToLower());

            if (resultAuxU == -1 || resultAuxL == -1)
            {
                if (resultAuxU == -1)
                {
                    result = resultAuxL;
                }
                else
                {
                    result = resultAuxU;
                }
            }
            else
            {
                if (resultAuxL > resultAuxU)
                {
                    if (result > resultAuxU)
                    {
                        result = resultAuxU;
                    }
                }
                else
                {
                    if (result > resultAuxL)
                    {
                        result = resultAuxL;
                    }
                }
            }

            return result;
        }

        public static void ProcessResult(Stream stream, List<KeyValuePair<char, int>> list)
        {
            var result = 0;
            foreach (var item in list)
            {
                if (result == 0)
                {
                    result = GetCharIndex(stream, item);
                }
                else
                {
                    result = GetCharIndex(stream, item);
                }
            }

            Console.WriteLine(stream.Characters[result]);
            Console.ReadLine();
        }

        public static void ProcessTypeC(Stream stream)
        {
            //obter a primeira vogal q nao se repete
            while (stream.HasNext())
            {
                var nextChar = stream.GetNext();
                var type = SetType(stream, nextChar);

                if (type == "V")
                {
                    switch (nextChar)
                    {
                        case 'A':
                        case 'a':
                            a++;
                            break;
                        case 'E':
                        case 'e':
                            e++;
                            break;
                        case 'I':
                        case 'i':
                            i++;
                            break;
                        case 'O':
                        case 'o':
                            o++;
                            break;
                        case 'U':
                        case 'u':
                            u++;
                            break;
                    }

                    if (!stream.HasNext())
                    {
                        break;
                    }
                }
            }

            var dic = new Dictionary<char, int>();
            dic.Add('A', a);
            dic.Add('E', e);
            dic.Add('I', i);
            dic.Add('O', o);
            dic.Add('U', u);

            var list = dic.Where(x => x.Value == 1).ToList();

            if (list.Count == 0)
            {
                Console.WriteLine("Nenhuma regra foi atendida no processamento");
                Console.ReadLine();
                return;
            }

            ProcessResult(stream, list);
        }

        static void Main(string[] args)
        {
            var stream = new Stream();
            Console.WriteLine("Insira a cadeia de caracteres para validação.");
            stream.Characters = Console.ReadLine();
            stream.Lenght = stream.Characters.Length;

            var firstChar = FirstChar(stream);
            var type = SetType(stream, firstChar);

            if (firstChar != char.MinValue)
            {
                if (type == "V")
                {
                    var nextChar = char.MinValue;
                    while (type == "V" && stream.HasNext())
                    {
                        nextChar = stream.GetNext();
                        type = SetType(stream, nextChar);
                    }

                    if (type == "C")
                    {
                        ProcessTypeC(stream);
                    }
                    else
                    {
                        Console.WriteLine("Nenhuma regra foi atendida no processamento");
                        Console.ReadLine();
                    }
                }
                else if (type == "C")
                {
                    ProcessTypeC(stream);
                }
                else
                {
                    Console.WriteLine("Favor informar apenas letras.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Input está vazio.");
                Console.ReadLine();
            }
        }

        public static char FirstChar(Stream input)
        {
            if (input.Characters != null && input.Lenght > 0)
            {
                input.Iteration = 1;
                return input.Characters[0];
            }

            return char.MinValue;
        }

    }
}
