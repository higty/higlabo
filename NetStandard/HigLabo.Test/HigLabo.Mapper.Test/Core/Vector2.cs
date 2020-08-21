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
        public override string ToString()
        {
            return String.Format("X={0}, Y={1}", this.X, this.Y);
        }
    }
    public class VectorInfo
    {
        public List<Vector2> Vectors { get; set; }
        public List<Vector2?> NullableVectors { get; set; }
        public List<Vector2> ReadonlyVectors { get; private set; }

        public VectorInfo()
        {
            this.Vectors = new List<Vector2>();
            this.NullableVectors = new List<Vector2?>();
            this.ReadonlyVectors = new List<Vector2>();
        }
    }
    public class VectorInfo1
    {
        public List<Vector2?> Vectors { get; set; }
        public List<Vector2?> NullableVectors { get; set; }
        public List<Vector2> ReadonlyVectors { get; private set; }

        public VectorInfo1()
        {
            this.Vectors = new List<Vector2?>();
            this.NullableVectors = new List<Vector2?>();
            this.ReadonlyVectors = new List<Vector2>();
        }
    }
}
