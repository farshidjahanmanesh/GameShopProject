using Entities.BaseEntities;
using System;

namespace Entities.Entities
{
    public class WalletSummery: IFinderEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Change { get; set; }
        public string Detail { get; set; }

        //reference navigations
        public int? WalletId { get; set; }
        public Wallet Wallet { get; set; }
    }
}
