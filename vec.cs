using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using static MoonEngine3d.MatrizExtensions;
using static MoonEngine3d.OperatorsHelper;
namespace MoonEngine3d
{
    public struct vec
    {
        public float x { get; init; }
        public float y { get; init; }
        public float z { get; init; }
        public float w { get; init; }
        public vec(float x_, float y_, float z_, float w_ = 1)
        {
            x=x_; y=y_; z=z_; w=w_;
        }

        public void Deconstruct(out float x_,out float y_,out float z_,out float w_)
        {
            x_ = x;
            y_ = y;
            z_ = z;
            w_ = w;
        }
        public float this[int pos] {
            get => pos switch
            {
                0 => x,
                1 => y,
                2 => z,
                3 => w,
                _ => 0
            };
        }

        public static vec? Create(params float[] data)
        {
            if(data.Length<4)
                return null;
            return new vec(data[0], data[1], data[2], data[3]);            
        }

        public static vec Zero => new vec(0, 0,0);


        public static vec operator +(vec a,vec b) => new(a.x + b.x, a.y + b.y, a.z + b.z);

        public static vec operator -(vec a, vec b) => new(a.x - b.x, a.y - b.y, a.z - b.z);

        public static vec operator -(vec b) => new(- b.x,- b.y, -b.z);

        public static vec operator *(vec a, vec b) => new(a.x * b.x, a.y * b.y, a.z * b.z);

        public static vec operator *(float f,vec v)=> new(f*v.x,f*v.y,f*v.z);

        public static vec operator /(vec a, vec b) => new(a.x / b.x, a.y / b.y, a.z / b.z);


        public static vec operator /(vec a, float f) => new(a.x / f, a.y / f, a.z / f);

        public override string ToString()
        {
            return $"{x} , {y} , {z} , {w}";
        }
    }

    public static class vecExtensions
    {
        public static float Lenght(this vec a) => MathF.Sqrt(a[0] * a[0] + a[1] * a[1] + a[2] * a[2]);
        public static vec Normalize(this vec v) => v/Lenght(v); 
    }
}


