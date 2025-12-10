namespace MoonEngine3d
{
    public static class CanvasExtensions{
        public static void DrawLine(this ICanvas canvas, vec v1, vec v2,RectF rect)
    {
        (var x, var y) = rect.Center;
        (float x1, float y1, _, _) = v1;
        (float x2, float y2, _, _) = v2;
        canvas.DrawLine(x1 +x, y1+y, x2+x, y2+y);
    }

    public static void DrawTri(this ICanvas canvas, Tri t,RectF rect)
    {       
        DrawLine(canvas, t.v1, t.v2,rect);
        DrawLine(canvas, t.v2, t.v3, rect);
        DrawLine(canvas, t.v3, t.v1, rect);
    }

     public static void DrawMesh(this ICanvas canvas, Mesh m, RectF dirtyRect)
     {
           foreach (var t in  m.tris.Select(t=>t.Map(v=>m.Transformada*v)))
                DrawTri(canvas, t,dirtyRect);
     }
}
     
}
