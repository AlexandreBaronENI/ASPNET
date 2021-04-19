using System;

namespace TP1
{
    class Triangle : Forme
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        public override double Aire =>  Math.Sqrt((Perimetre/2) * ((Perimetre / 2) - A) * ((Perimetre / 2) - B) * ((Perimetre / 2) - C));

        public override double Perimetre => A + B + C;

        public override string ToString()
        {
            return $"Triangle de côté A = {A}, B = {B} et C = {C}\n" + base.ToString();
        }
    }
}
