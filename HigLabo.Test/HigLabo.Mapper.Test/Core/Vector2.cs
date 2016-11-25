using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Mapper.Test
{
    public struct Vector2
    {
        public Int32 X { get; private set; }
        public Int32 Y { get; private set; }

        public Vector2(Int32 x, Int32 y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
