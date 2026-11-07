using System;
using System.Collections.Generic;
using System.Text;

namespace ZMS
{
    internal interface ISwimmable
    {
        double MaxDiveDepth { get; set; }
        string Swim();
    }
}
