using Entities.BaseEntities;
using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public class ShopCard: IFinderEntity
    {
        public ShopCard()
        {
            this.CardDetails = new List<CardDetail>();
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }

        //reference navigations
        public string UserId { get; set; }
        public User User { get; set; }

        //collection navigations
        public IList<CardDetail> CardDetails { get; set; }
    }
}
