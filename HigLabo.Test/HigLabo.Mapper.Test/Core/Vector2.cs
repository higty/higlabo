using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Mapper.Test
{
    public struct Vector2
    {
        public Decimal X { get; private set; }
        public Decimal Y { get; private set; }

        public Vector2(Decimal x, Decimal y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
