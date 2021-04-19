using System.Text;

namespace TP1
{
    class Rectangle : Forme
    {
        public int Largeur { get; set; }
        public int Longueur { get; set; }

        public override double Aire => Longueur * Largeur;

        public override double Perimetre => Largeur * 2 + Longueur * 2;

        public override string ToString()
        {
            return $"\nRectangle de longueur = {Longueur} et de largeur = {Largeur}\n" + base.ToString();
        }
    }
}
