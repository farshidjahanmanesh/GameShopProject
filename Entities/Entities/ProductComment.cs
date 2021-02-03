using Entities.BaseEntities;
using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public class ProductComment: IFinderEntity
    {
        public ProductComment()
        {
            this.ChildComments = new List<ProductComment>();
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
        //reference navigations
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ParentCommentId { get; set; }
        public ProductComment ParentComment { get; set; }

        //collection navigations
        public IList<ProductComment> ChildComments { get; set; }
    }
}
