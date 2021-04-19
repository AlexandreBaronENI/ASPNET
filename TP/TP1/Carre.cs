using System;

namespace TP1
{
    class Carre : Forme
    {
        public int Longueur { get; set; }

        public override double Aire => Math.Pow(Longueur, 2);

        public override double Perimetre => Longueur * 4;

        public override string ToString()
        {
            return $"\nCarré de côté = {Longueur}\n" + base.ToString();
        }
    }
}
