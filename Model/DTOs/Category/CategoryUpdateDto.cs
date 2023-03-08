using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs.Category
{
    public class CategoryUpdateDto
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public DateTime ModifiedDate = DateTime.Now;

       

    }
}
