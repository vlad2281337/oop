using System;
using System.Collections.Generic;
using _06.classes;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            var roomRows = new List<string>();

            int rowCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < rowCount; ++i)
                roomRows.Add(Console.ReadLine());

            var room = new Room(roomRows.ToArray());

            string directionsLine = Console.ReadLine();

            Console.WriteLine();

            try
            {
                foreach (var dirChar in directionsLine)
                {
                    var direction = dirChar switch
                    {
                        'U' => Direction.Up,
                        'D' => Direction.Down,
                        'L' => Direction.Left,
                        'R' => Direction.Right,
                        _ => Direction.Wait
                    };

                    room.TakeTurn(direction);
                    //PrintRoom(room);
                    //Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                PrintRoom(room);
            }

            Console.ReadKey();
        }

        static void PrintRoom(Room room)
        {
            foreach (var row in room.Fields)
            {
                foreach (var field in row)
                    Console.Write(field);
                Console.WriteLine();
            }
        }
    }

}
