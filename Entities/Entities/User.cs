using Microsoft.AspNetCore.Identity;
using System.Text;

namespace Entities.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public bool IsUserBan { get; set; }
        //reference navigations
        public int? WalletId { get; set; }
        public Wallet Wallet { get; set; }
        public int CardId { get; set; }
        public ShopCard Card { get; set; }
    }
}
