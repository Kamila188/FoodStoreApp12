using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodStoreApp.Models
{
    public class Manufacturers
    {
        public int Id { get; set; }
        [DisplayName(" Производитель")]
        public string Name { get; set; }
        [DisplayName(" Страна")]
        public string Country { get; set; }
    }
}

