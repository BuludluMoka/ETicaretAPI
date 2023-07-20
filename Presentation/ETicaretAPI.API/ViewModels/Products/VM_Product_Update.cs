using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.ViewModels.Products
{
    public class VM_Product_Update
    {
        public string Id{ get; set; }
        public string Name{ get; set; }
        public int Stock { get; set; }
        public float Price{ get; set; }
    }
}
