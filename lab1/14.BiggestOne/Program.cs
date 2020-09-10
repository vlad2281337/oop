using System;
 class Program
    {
        static void Main(string[] args)
        {

        int a, b, c;

        a = int.Parse(Console.ReadLine());
        b = int.Parse(Console.ReadLine());
        c = int.Parse(Console.ReadLine());

        if (b < a && a > c)
        {
            Console.WriteLine(a);
        }
        else
        {
            if(b>a&&b>c){
                Console.WriteLine(b);
            }
            else
            {
                if (c > a && c > b)
                {
                    Console.WriteLine(c);
                }
                else
                {
                    Console.WriteLine("Err");
                }
            }
        }
        Console.ReadKey();
    }
    }

