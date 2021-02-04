using Entities.BaseEntities;

namespace Entities.Entities
{
    public class ProductCategory : IFinderEntity
    {
        public int Id { get; set; }
        //reference navigations
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Categoryid { get; set; }
        public Category Category { get; set; }
    }
}
