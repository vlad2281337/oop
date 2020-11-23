using System;
using System.Collections.Generic;
using System.Text;

namespace _03.classes
{
    public class Star
    {
        public int Value { get; set; }

        public bool IsDestroyed { get; set; }

        public Star(int value) => Value = value;
    }
}
