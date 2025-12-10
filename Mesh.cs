using static MoonEngine3d.TrisHelper;
using static MoonEngine3d.MatrizExtensions;
namespace MoonEngine3d

{
    public class Mesh
    {
        public List<Tri> tris;
        public IEnumerable<vec> Points => tris.SelectMany(TrisHelper.vecs);

        public event EventHandler<EventArgs> Changed;

        private float rotx;
        public float RotX
        {
            get => rotx;
            set
            {
                rotx = value;
                Changed?.Invoke(this, EventArgs.Empty);
                Transformada = mRotX(value) * Transformada;
            }
        }
        private float rotY;
        public float RotY
        {
            get => rotY;
            set
            {
                rotY = value;
                Changed?.Invoke(this, EventArgs.Empty);
                Transformada = mRotY(value) * Transformada;
            }
        }
        private float rotZ;
        public float RotZ
        {
            get => rotZ;
            set
            {
                rotZ = value;
                Changed?.Invoke(this, EventArgs.Empty);
                Transformada = mRotZ(value) * Transformada;
            }
        }

        public Matriz Transformada { get;private set; }
        public static Mesh Create(params IEnumerable<Tri> tris)
        {
            var mesh = new Mesh();
            mesh.tris = new List<Tri>(tris);
            mesh.Transformada = Matriz.I;
            return mesh;
        }

    }
}
