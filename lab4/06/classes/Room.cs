using System;
using System.Collections.Generic;
using System.Text;

namespace _06.classes
{
    public class Room
    {
        private Position playerPosition;
        private Position targetPosition;
        private readonly List<Enemy> enemies;

        public char[][] Fields { get; }

        public Room(string[] roomRows)
        {
            enemies = new List<Enemy>();

            Fields = new char[roomRows.Length][];
            for (int i = 0; i < Fields.Length; ++i)
                Fields[i] = roomRows[i].ToCharArray();

            LocatePositions();
        }

        private void LocatePositions()
        {
            for (int i = 0; i < Fields.Length; ++i)
                for (int j = 0; j < Fields[i].Length; ++j)
                    switch (Fields[i][j])
                    {
                        case 'S':
                            {
                                playerPosition = new Position(j, i);
                                break;
                            }
                        case 'N':
                            {
                                targetPosition = new Position(j, i);
                                break;
                            }
                        case 'b':
                            {
                                enemies.Add(new Enemy(j, i, Direction.Right));
                                break;
                            }
                        case 'd':
                            {
                                enemies.Add(new Enemy(j, i, Direction.Left));
                                break;
                            }
                    }
        }

        private void MoveEnemies()
        {
            var (x, y) = playerPosition.Deconstruct();

            foreach (var enemy in enemies)
            {
                var (ex, ey) = enemy.Position.Deconstruct();

                bool samKilled = (ey == y &&
                                    (enemy.Direction == Direction.Right && ex < x ||
                                    enemy.Direction == Direction.Left && ex > x));
                if (samKilled)
                {
                    Fields[y][x] = 'X';
                    throw new Exception($"Sam died at {y}, {x}");
                }

                int leftBound = 0,
                    rightBound = Fields[ey].Length - 1;

                (bool canMove, int step) = (enemy.Direction == Direction.Right)
                                            ? (ex < rightBound, 1)
                                            : (ex > leftBound, -1);
                if (canMove)
                {
                    (Fields[ey][ex], Fields[ey][ex + step]) = (Fields[ey][ex + step], Fields[ey][ex]);
                    enemy.Move();
                }

                if (enemy.Direction == Direction.Right && ex >= rightBound)
                {
                    enemy.SwitchDirection();
                    Fields[ey][rightBound] = 'd';
                }
                else if (enemy.Direction == Direction.Left && ex <= leftBound)
                {
                    enemy.SwitchDirection();
                    Fields[ey][leftBound] = 'b';
                }
            }
        }

        private void MovePlayer(Direction direction)
        {
            var (x, y) = playerPosition.Deconstruct();

            if (direction == Direction.Wait)
                return;

            (bool canMove, int step) = direction switch
            {
                Direction.Up => (y != 0, -1),
                Direction.Down => (y != Fields.Length - 1, 1),
                Direction.Left => (x != 0, -1),
                Direction.Right => (x != Fields[y].Length - 1, 1),
                _ => (false, 0)
            };

            if (canMove)
                switch (direction)
                {
                    case Direction.Up:
                    case Direction.Down:
                        {
                            var enemy = enemies.Find(en => en.Position.X == x && en.Position.Y == y + step);

                            if (enemy != null)
                            {
                                enemies.Remove(enemy);
                                Fields[y + step][x] = '.';
                            }

                            (Fields[y][x], Fields[y + step][x]) = (Fields[y + step][x], Fields[y][x]);
                            playerPosition.Y += step;
                            break;
                        }
                    case Direction.Left:
                    case Direction.Right:
                        {
                            (Fields[y][x], Fields[y][x + step]) = (Fields[y][x + step], Fields[y][x]);
                            playerPosition.X += step;
                            break;
                        }
                }

            if (playerPosition.Y == targetPosition.Y)
            {
                var (tx, ty) = targetPosition.Deconstruct();
                Fields[ty][tx] = 'X';
                throw new Exception("Nikoladze killed!");
            }
        }

        public void TakeTurn(Direction playerDirection)
        {
            MoveEnemies();
            MovePlayer(playerDirection);
        }
    }
}
