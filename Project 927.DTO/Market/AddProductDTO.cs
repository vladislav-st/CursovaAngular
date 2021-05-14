using System;
using System.Collections.Generic;
using System.Text;

namespace Project_927.DTO.Market
{
    public class AddProductDTO
    {
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Img_URL { get; set; }
        public float Price { get; set; }
    }
}
