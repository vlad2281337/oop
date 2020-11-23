using System;
using System.Collections.Generic;
using System.Text;

namespace _06.classes
{
    public class Enemy
    {
        public Position Position { get; set; }

        public Direction Direction { get; private set; }

        public Enemy(int x, int y, Direction direction)
        {
            Position = new Position(x, y);
            Direction = direction;
        }

        public void SwitchDirection()
        {
            Direction = (Direction == Direction.Left)
                        ? Direction.Right
                        : Direction.Left;
        }

        public void Move()
        {
            Position.X = Direction switch
            {
                Direction.Left => Position.X - 1,
                Direction.Right => Position.X + 1,
                _ => Position.X
            };
        }
    }
}
