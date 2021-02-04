using Entities.BaseEntities;
using System.Collections.Generic;

namespace Entities.Entities
{
    public class Tag:IFinderEntity
    {
        public Tag()
        {
            ProductTags = new List<ProductTag>();
        }
        public int Id { get; set; }
        public string TagName { get; set; }

        //collection navigations
        public IList<ProductTag> ProductTags { get; set; }
    }
}
