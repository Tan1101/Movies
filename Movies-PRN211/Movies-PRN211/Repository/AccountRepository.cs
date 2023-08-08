using Movies_PRN211.Interfaces;
using Movies_PRN211.Models;
using System.Security.Principal;

namespace Movies_PRN211.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MoviesContext _context;

        public AccountRepository(MoviesContext context)
        {
            _context = context;
        }

        public Account AddAccount(Account account)
        {
            var _account = new Account
            {
                Gmail = account.Gmail,
                Password = account.Password,
                Name = account.Name,
                Role = "user",
                Gender = account.Gender,
                AccStatus = account.AccStatus,
            };
            _context.Accounts.Add(_account);
            _context.SaveChanges();
            return new Account
            {
                Gmail = account.Gmail,
                Password = account.Password,
                Name = account.Name,
                Role = "user",
                Gender = account.Gender,
                AccStatus = account.AccStatus,
            };

        }

        public Account isExitsAccount(Account accountModel)
        {
            var isExitsAcc = _context.Accounts.FirstOrDefault(a => a.Gmail == accountModel.Gmail && a.Password == accountModel.Password);
            if (isExitsAcc != null)
            {
                return new Account
                {
                    Gmail = isExitsAcc.Gmail,
                    Password = isExitsAcc.Password,
                    Name = isExitsAcc.Name,
                    Role = isExitsAcc.Role,
                    Gender = isExitsAcc.Gender,
                    AccStatus = isExitsAcc.AccStatus,
                };
            }
            else
            {
                return null;
            }
        }

        public bool isExits(string gmail)
        {
            var isExitsEmail = _context.Accounts.FirstOrDefault(a => a.Gmail == gmail);
            if (isExitsEmail != null)
            {
                return true;
            }
            return false;
        }

        

        Account IAccountRepository.getAccountByAccID(string id)
        {
            throw new NotImplementedException();
        }
    }
}
