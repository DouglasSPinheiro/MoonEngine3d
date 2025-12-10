namespace MoonEngine3d
{
    public static class DrawHelper
    {
        public static Mesh Piramide()
        {
            vec v1 = vec.Zero;
            vec v2 = new(100, 0, 100);
            vec v3 = new(200, 0, 200);
            vec v4 = new(150, 200, 150);
            return Mesh.Create(new Tri(v1, v2, v3),
                                new Tri(v1, v2, v4),
                                new Tri(v2, v3, v4),
                                new Tri(v3, v1, v4)
                                );
        }

    }
}


