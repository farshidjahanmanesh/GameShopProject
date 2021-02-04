using Entities.BaseEntities;
using System.Collections.Generic;

namespace Entities.Entities
{
    public class Category:IFinderEntity
    {
        public Category()
        {
            this.ProductCategorys = new List<ProductCategory>();
        }
        public int Id { get; set; }
        public string CategoryName { get; set; }

        //collection navigations
        public IList<ProductCategory> ProductCategorys { get; set; }
    }
}
