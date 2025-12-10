using System.Runtime.Intrinsics.X86;
using static MoonEngine3d.DrawHelper;
using static MoonEngine3d.MatrizExtensions;
using Timer = System.Timers.Timer;
namespace MoonEngine3d
{
    public partial class MainPage : ContentPage, IDrawable
    {
        int count = 0;
        Timer timer;
        TimeSpan anterior, atual,dt;
        List<GameObject> objects;
        Queue<Mesh> toDraw;
        bool updateRequested;
        public MainPage()
        {
            InitializeComponent();
            canva.Invalidate();
            timer = new(100);
            timer.Elapsed += Timer_Elapsed;
            objects= new List<GameObject>();
            toDraw = new Queue<Mesh>();
            anterior = atual = TimeSpan.Zero;
            updateRequested = false;
            RotatingTriangle t = new();
            objects.Add(t);
            timer.Start();
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
        
           atual = DateTime.Now.TimeOfDay;
           dt = anterior == TimeSpan.Zero ? TimeSpan.Zero : atual - anterior;
            foreach (var item in objects)
            {
                updateRequested = false;
                item.OnUpdate(dt, out updateRequested);
                if (updateRequested)
                    foreach (Mesh m in item.GetMeshes())
                       toDraw.Enqueue(m);
            }
           if(updateRequested)
                canva.Invalidate();   
        }


        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeColor = Colors.Red;
            canvas.StrokeSize = 3;
            while (toDraw.TryDequeue(out Mesh m))
                canvas.DrawMesh(m,dirtyRect);
        }
        

        
    }
     
}
