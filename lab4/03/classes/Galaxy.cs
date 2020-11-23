using System;
using System.Collections.Generic;
using System.Text;

namespace _03.classes
{
    public class Galaxy
    {
        private readonly int rows;
        private readonly int cols;

        private Position jediPosition;
        private Position forcePosition;

        public Star[,] Stars { get; }

        public Galaxy(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            Stars = new Star[rows, cols];

            Initialize();
        }

        protected void Initialize()
        {
            for (int i = 0; i < rows; ++i)
                for (int j = 0; j < cols; ++j)
                    Stars[i, j] = new Star(i * rows + j);
        }

        public void PlaceJedi(int starX, int starY)
            => jediPosition = new Position(starX, starY);

        public void PlaceForce(int starX, int starY)
            => forcePosition = new Position(starX, starY);

        public int CollectStars()
        {
            if (jediPosition == null || forcePosition == null)
                throw new Exception("Either Jedi or Force is not in the galaxy");

            ActivateForce();

            int sum = 0;
            var (x, y) = jediPosition.Deconstruct();

            while (x >= 0)
            {
                if (x < rows && y >= 0 && y < cols)
                {
                    var star = Stars[x, y];
                    if (!star.IsDestroyed)
                        sum += star.Value;
                }
                --x;
                ++y;
            }

            return sum;
        }

        protected void ActivateForce()
        {
            var (x, y) = forcePosition.Deconstruct();

            while (x >= 0 && y >= 0)
            {
                if (x < rows && y < cols)
                    Stars[x, y].IsDestroyed = true;
                --x;
                --y;
            }
        }
    }
}
