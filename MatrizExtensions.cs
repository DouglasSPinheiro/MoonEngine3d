using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonEngine3d
{
    static class MatrizExtensions
    {

        public static float asRad(this float f) => f * 3.14f / 180;

        public static void Foreach<T>(this IEnumerable<T> items, Action<T> act)
        {
            foreach (var item in items)
            {
                act(item);
            }
        }
        public static Matriz mRotZ(float angle)
        {
            var cos = MathF.Cos(angle);
            var sen = MathF.Sin(angle);

            return Matriz.Create(new[]{
                cos,sen,0,0,
                -sen,cos,0,0,
                0,0,1,0,
                0,0,0,1
            });
        }

        public static Matriz mRotX(float angle)
        {
            var cos = MathF.Cos(angle);
            var sen = MathF.Sin(angle);

            return Matriz.Create(new[]{
                1,0,0,0,
                0,cos,sen,0,
                0,-sen,cos,0,                
                0,0,0,1
            });
        }

        public static Matriz mRotY(float angle)
        {
            var cos = MathF.Cos(angle);
            var sen = MathF.Sin(angle);

            return Matriz.Create(new[]{
                cos,0,sen,0,
                0,1,0,0,
                -sen,0,cos,0,0,                
                0,0,0,1
            });
        }
    }
}
