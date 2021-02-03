using Entities.BaseEntities;
using System.Collections.Generic;

namespace Entities.Entities
{
    public class Product: IFinderEntity
    {
        
        public Product()
        {
            Comments = new List<ProductComment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public float Price { get; set; }
        public int Discount { get; set; }
        public string Picture { get; set; }
        public bool IsActive { get; set; }

        //collection navigations
        public IList<ProductComment> Comments { get; set; }
    }
}
