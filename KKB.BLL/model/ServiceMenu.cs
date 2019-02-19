using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.BLL.model
{
    class ServiceMenu
    {
        public void MainMenu(User user)
        {
            Console.WriteLine("Приветствую вас {0}", user.fullname);

            Console.WriteLine("1. Вывод баланса");
            Console.WriteLine("2. Пополнение баланса");
            Console.WriteLine("3. Снять деньги со счета");
            Console.WriteLine("4. Выход");
        }
    }
}
