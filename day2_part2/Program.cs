using System;
using System.IO;
using System.Collections.Generic;


namespace day2_part2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var result = ReadInput(@"/home/codespace/workspace/day2/input.txt");
            Console.WriteLine(result.Count);
            foreach(var p in result)
                Console.WriteLine(p);
        }

        public static List<string> ReadInput(string path)
        {
            var passwords = new List<string>();
            using var reader = new StreamReader(path);
            var value = reader.ReadLine();
            while(value != null)
            {
                var passwordPolicy = PasswordPolicy.CreatePassword(value);
                if(passwordPolicy.isValid())
                    passwords.Add(passwordPolicy.Policy);
                value = reader.ReadLine();
            }

            return passwords;
        }
    }

    class PasswordPolicy
    {
        public char Letter { get; set; }

        public NbLetterPolicy LetterPolicy { get; set; }

        public string Password { get; set; }

        public string Policy { get; set; }

        public static PasswordPolicy CreatePassword(string policy)
        {
            var tab = policy.Split(" ");
            var letterPolicy = NbLetterPolicy.CreateNbLetterPolicy(tab[0]);

            return new PasswordPolicy
            {
                LetterPolicy = letterPolicy,
                Letter = tab[1][0],
                Password = tab[2],
                Policy =  policy
            };
        }

        public bool isValid()
        {
            return Password[LetterPolicy.Index_1 -1] == Letter ^
                    Password[LetterPolicy.Index_2 -1] == Letter;
        }
    }

    class NbLetterPolicy
    {
        public int Index_1 { get; set; }

        public int Index_2 { get; set; }
        public static NbLetterPolicy CreateNbLetterPolicy(string nbPolicyString)
        {
            var tab = nbPolicyString.Split("-");
            return new NbLetterPolicy
            { 
                Index_1 = Convert.ToInt32(tab[0]),
                Index_2 = Convert.ToInt32(tab[1])
            };
        }
    }
}
