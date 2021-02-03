using Entities.BaseEntities;

namespace Entities.Entities
{
    public class CardDetail: IFinderEntity
    {
        public int Id { get; set; }

        public int Count { get; set; }

        //reference navigations
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
