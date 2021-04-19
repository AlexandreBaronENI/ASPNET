namespace TP1
{
    abstract class Forme
    {
        public abstract double Aire { get; }
        public abstract double Perimetre { get; }
        public override string ToString()
        {
            return $"Aire = {Aire}\nPérimètre = {Perimetre}\n";
        }
    }
}
