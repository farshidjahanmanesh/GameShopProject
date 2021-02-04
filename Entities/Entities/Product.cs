using Entities.BaseEntities;
using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public class Product: IFinderEntity
    {
        public Product()
        {
            Comments = new List<ProductComment>();
            ProductCategorys = new List<ProductCategory>();
            ProductTags = new List<ProductTag>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public float Price { get; set; }
        public int Discount { get; set; }
        public string Picture { get; set; }
        public bool IsActive { get; set; }
        public string Slug { get; set; }
        public string Summery { get; set; }
        public int Classification { get; set; }
        public DateTime PublicationDate { get; set; }

        //collection navigations
        public IList<ProductComment> Comments { get; set; }
        public IList<ProductCategory> ProductCategorys { get; set; }
        public IList<ProductTag> ProductTags { get; set; }
    }
}
