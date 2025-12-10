using System.Collections;
using static MoonEngine3d.OperatorsHelper;
namespace MoonEngine3d
{
    public record struct Matriz:IEnumerable<float>,IEnumerable<vec>
    {
        private float[] values;
        public IEnumerable<float> Values => values;
        public Matriz()
        {
            values = new float[16];
            for (int i = 0; i < values.Length; i++)
                values[i] = 0;
        }

        public static Matriz Create(float[] values) => new Matriz() with { values = values };

        public  Matriz Map(Func<float, float> map)
        {
            float[] novo = new float[16];
            for (int i = 0; i < novo.Length; i++)
            {
                novo[i] = map(values[i]);
            }
            return Create(novo);
        }
        public  Matriz Map(Func<int, int, float, float> map)
        {
            float[] novo = new float[16];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    novo[4*i+j] = map(i, j, this[i, j]);
            return Create(novo);
        }

        public IEnumerator<float> GetEnumerator()
        {
            return Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Values).GetEnumerator();
        }

        IEnumerator<vec> IEnumerable<vec>.GetEnumerator()=>Lines.GetEnumerator();

        private IEnumerable<vec> Lines => values.Chunk(4)
                                                .Select(x =>
                                                {
                                                    var a = x.ToArray();
                                                    return new vec(a[0], a[1], a[2], a[3]);
                                                });
        private vec Collumn(int pos) => new vec(this[0, pos], this[1, pos], this[2, pos], this[3, pos]);
        private IEnumerable<vec> Collumns => Enumerable.Range(0, 4).Select(Collumn);

        public static Matriz Zero { get => new Matriz().Map(x => 0); }
        public static Matriz I { get => new Matriz().Map((x, y, v) => x == y ? 1 : 0);}

        public float this[int i, int j]
        {
            get => (i, j) switch
            {
                (>=0,>=0) when i<4 && j<4 => values[i*4+j],
                _=>0
            };
            set
            {
                if (i < 0 || i > 3 || j < 0 || j > 3)
                    return;
                values[i*4+j] = value;
            }
        }       

        public static vec operator *(Matriz m, vec v)
        {
            float[] values = { 0, 0, 0,0 };

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    values[i] += m[i, j] * v[i];
            return vec.Create(values)??new(0,0,0) ;
        }

        public static Matriz operator *(Matriz m1, Matriz m2)
        {
            int pos = 0;
            Matriz result = new Matriz();
            for(int i = 0; i < 4; i++)
                for(int j = 0; j < 4; j++)
                    for(int k = 0; k < 4; k++)
                       result[i, j] += m1[i, k] * m2[k, j];
                   
            return result;             
        }

        public override string ToString()
        {
            return values.Chunk(4)
                         .Select(a => a.Aggregate(string.Empty, (a, b) => string.Join(" ", a, b)))
                         .Aggregate(string.Empty, (l1, l2) => string.Join(" | ", l1, l2));
        }
    }

}
