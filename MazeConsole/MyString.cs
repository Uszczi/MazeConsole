﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeConsole;
public static class MyString
{
    public static string Multiply(this string source, int multiplier)
    {
        StringBuilder sb = new StringBuilder(multiplier * source.Length);
        for (int i = 0; i < multiplier; i++)
        {
            sb.Append(source);
        }

        return sb.ToString();

    }
}