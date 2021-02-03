using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Dtos.ProductDtos
{
    public class RemoveProductDto
    {
        public int Id { get; set; }
    }
    public class GetAllProductDto:Product
    {

    }
    public class UpdateProductDto:Product
    {
        public new IList<ProductComment> Comments { get;private set; }
    }

    public class InsertProductDto : Product
    {
        public new int Id { get;private set; }
        public new bool IsActive { get; private set; }
        public new IList<ProductComment> Comments { get; private set; }
        
    }
}
