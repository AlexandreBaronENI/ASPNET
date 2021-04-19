using System;
using System.Text;

namespace TP1
{
    class Cercle : Forme
    {
        public int Rayon { get; set; }

        public override double Aire => Math.PI* Math.Pow(Rayon, 2);

        public override double Perimetre => 2 * Math.PI * Rayon;

        public override string ToString() {
            return $"\nCercle de rayon {Rayon}\n" + base.ToString();
        }
    }
}
