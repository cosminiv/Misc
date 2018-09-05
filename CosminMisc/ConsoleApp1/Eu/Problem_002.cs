﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Eu
{
    public class Problem_002
    {
        public static int Solve()
        {
            int i1 = 1;
            int i2 = 2;
            int max = 4000000;
            int sum = 0;

            while (i2 < max)
            {
                if (i2 % 2 == 0)
                    sum += i2;

                int i3 = i1 + i2;
                i1 = i2;
                i2 = i3;
            }

            return sum;
        }
    }
}
