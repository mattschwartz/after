using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Utility
{
    public class Pair<T, U>
    {
        public T First;
        public U Second;

        public Pair(T first, U second)
        {
            First = first;
            Second = second;
        }

        public static Pair<T, U> MakePair(T first, U second)
        {
            return new Pair<T, U>(first, second);
        }
    }
}
