using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MoonEngine3d.DrawHelper;
namespace MoonEngine3d
{
    internal class RotatingTriangle:GameObject
    {
        Mesh m = Mesh.Create(new Tri(new vec(100, 100, 0),
            new vec(200, 200, 0),
            new vec(150, 300, 0)
            ));
        public override IEnumerable<Mesh> GetMeshes()
        {
            yield return m;
        }
        public override void OnUpdate(TimeSpan t,out bool update)
        {
            m.RotZ += 0.5f.asRad();
            update = true;
        }
    }
}
