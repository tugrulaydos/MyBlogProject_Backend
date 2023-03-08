using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs.Category
{
    public class CategoryGetDto
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }

        public bool IsDeleted { get; set; }

    }
}
