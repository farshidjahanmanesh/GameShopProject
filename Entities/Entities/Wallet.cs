using Entities.BaseEntities;
using System.Collections.Generic;

namespace Entities.Entities
{
    public class Wallet: IFinderEntity
    {
        public Wallet()
        {
            this.WalletSummeries = new List<WalletSummery>();
        }
        public int Id { get; set; }
        public float Money { get; set; }
        public bool IsBan { get; set; }
        //reference navigations
        public string UserId { get; set; }
        public User User { get; set; }

        //collection navigations
        public IList<WalletSummery> WalletSummeries { get; set; }
    }
}
