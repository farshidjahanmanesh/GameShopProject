using Entities.BaseEntities;

namespace Entities.Entities
{
    public class ProductTag:IFinderEntity
    {
        public int Id { get; set; }
        //reference navigations
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Tagid { get; set; }
        public Tag Tag { get; set; }
    }
}
