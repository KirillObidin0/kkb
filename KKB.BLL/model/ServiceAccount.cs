using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.BLL.model
{
    public class ServiceAccount
    {
        List<Account> accounts = new List<Account>();
        public List<Account> GetAccounts(int UserId)
        {
            using (LiteDatabase db =new LiteDatabase("KKB.db"))
            {
                var accounts = db.GetCollection<Account>("Account").FindAll();
                return accounts.Where(w => w.UserId == UserId).ToList();
            }
        }
        private Random rnd = new Random();
        public Account CreateAccount(int UserId,Currency currency)
        {
            Account a = new Account();
            a.Currency = currency;
            a.UserId = UserId;
            a.Balance = 0;
            a.AccountNumber = string.Format("{0}{1}", currency, rnd.Next());
            return a;
        }
        public bool CreateAccountDb(Account acc,out string message)
        {
            try
            {
                using(LiteDatabase db = new LiteDatabase("KKB.db"))
                {
                    var accounts = db.GetCollection<Account>("Account");
                    accounts.Insert(acc);
                    message = "Account successfully created!";
                    return true;
                }
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }

        public bool MoneyAppend(int AccId,double money,out string message)
        {
            try
            {
                using (LiteDatabase db = new LiteDatabase("KKB.db"))
                {
                    var accounts = db.GetCollection<Account>("Account");
                    var account = accounts.FindById(AccId);

                    account.Balance += money;
                    accounts.Update(account);
                    message = "Money added";
                    return true;
                }
            }
            catch(Exception e)
            {
                message = e.Message;
                return false;
            }
        }
    }
}
