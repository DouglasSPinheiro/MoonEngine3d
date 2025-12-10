using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MoonEngine3d
{
    internal class GameObject
    {
        public virtual IEnumerable<Mesh> GetMeshes()
        {
            yield break;
        }
        public virtual void OnUpdate(TimeSpan t, out bool update)
        {
            update = false;
        }
    }
}
