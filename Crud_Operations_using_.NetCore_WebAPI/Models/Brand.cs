using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Crud_Operations_using_.NetCore_WebAPI.Models
{
    public class Brand
    {
        
        public int ID { get; set; }
        public string? Name { get; set; }

        public string? Category { get; set; }

        public int IsActive {  get; set; }
    }
}
