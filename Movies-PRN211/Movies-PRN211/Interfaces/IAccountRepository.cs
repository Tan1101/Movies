using Movies_PRN211.Models;

namespace Movies_PRN211.Interfaces
{
    public interface IAccountRepository
    {
        public Account isExitsAccount(Account accountModel);
        public Boolean isExits(string id);
        public Account AddAccount(Account account);
        public Account getAccountByAccID(string id);

    }
}
