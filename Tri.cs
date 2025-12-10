namespace MoonEngine3d
{
    public record struct Tri(vec v1, vec v2, vec v3);

    public static class TrisHelper{
        public static IEnumerable<vec> vecs(this Tri t)
       {
            yield return t.v1;
            yield return t.v2;
            yield return t.v3;
        }

        
        public static Tri Map(this Tri t,Func<vec,vec> map)=> new Tri(map(t.v1),map(t.v2),map(t.v3));
    }
}
