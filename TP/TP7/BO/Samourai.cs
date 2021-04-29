using System.Collections.Generic;
using System.ComponentModel;

namespace BO
{
    public class Samourai
    {
        public int Id { get; set; }
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }

        [DisplayName("Arts martiaux maitrisés")]
        public virtual List<ArtMartial> ArtsMartiaux { get; set; }
        public int Potentiel { get { return (Force + (Arme != null ? Arme.Degats : 0)) * (ArtsMartiaux != null ? ArtsMartiaux.Count : 0 + 1) ; } }
    }
}
