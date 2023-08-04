using OnionArchitecture.Application.Utilities.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.DTOs.Product
{
    public class CreateProductDto : IMapTo<Domain.Entities.Product>
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
    }
}
