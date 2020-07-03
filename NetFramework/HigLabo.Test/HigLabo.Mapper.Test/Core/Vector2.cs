using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Mapper.Test
{
    public struct Vector2
    {
        public Int32 X { get; set; }
        public Int32 Y { get; set; }

        public Vector2(Int32 x, Int32 y)
        {
            this.X = x;
            this.Y = y;
        }
    }
    public class VectorList
    {
        public List<Vector2> Vectors { get; set; }
        public List<Vector2?> NullableVectors { get; set; }
        public List<Vector2> ReadonlyVectors { get; private set; }

        public VectorList()
        {
            this.Vectors = new List<Vector2>();
            this.NullableVectors = new List<Vector2?>();
            this.ReadonlyVectors = new List<Vector2>();
        }
    }
}
