﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopCalculator
{
    public class Arithmetics
    {
        public int Calculate(int num1, int num2, string action)
        {
            int result = 0;
            switch (action)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    result = (double)num1 / (double)num2;
                    break;
            }
            return result;
        }
    }
}