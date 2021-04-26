using BO;
using System.Web.Mvc;

namespace Dojo.Models.ViewModel
{
    public class SamouraiViewModel
    {
        public Samourai Samourai{ get; set; }
        public SelectList Armes { get; set; }
        public int? ArmeIdSelected { get; set; }
    }
}