namespace _Root.Scripts
{
    public partial struct Vector
    {
        public float x;
        public float y;

        public Vector(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static explicit operator Vector(float x) => new Vector(x, x);
        public static implicit operator float(Vector x) => x.x;

        public static Vector operator +(Vector v1, Vector v2)
        {
            Vector res = new Vector
            {
                x = v1.x + v2.x,
                y = v1.y + v2.y
            };
            return res;
        }
        
        public static Vector operator -(Vector v1, Vector v2)
        {
            Vector res = new Vector
            {
                x = v1.x - v2.x,
                y = v1.y - v2.y
            };
            return res;
        }
    }
}