using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Flowchart
{
    public class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var enc1251 = Encoding.GetEncoding(1251);

            System.Console.OutputEncoding = System.Text.Encoding.UTF8;
            System.Console.InputEncoding = enc1251;

            List<User> users = new List<User>
            {
                new User { Login = "Misha", Name = "Миша", IsPremium = true },
                new User { Login = "Sasha", Name = "Саша", IsPremium = false },
                new User { Login = "Gosha", Name = "Гоша", IsPremium = true }
            };
            bool userFound = false;

            while (!userFound)
            {

                Console.Write("Введите логин: ");
                string login = Console.ReadLine();

                Console.Write("Введите имя: ");
                string name = Console.ReadLine();

                userFound = CheckUser(users, login, name);
            }
        }

        static bool CheckUser(List<User> users, string login, string name)
        {
            User user = null;
            foreach (var u in users)
            {
                if (u.Login == login && u.Name == name)
                {
                    user = u;
                    break;
                }
            }

            if (user != null)
            {
                Console.WriteLine($"Здравствуй, {user.Name}!");
                if (!user.IsPremium)
                {
                    ShowAds();
                }
                return true;
                
            }
            Console.WriteLine("Пользователь не найден.");
            return false;
        }
        static void ShowAds()
        {
            Console.WriteLine("Посетите наш новый сайт с бесплатными играми!");
            Thread.Sleep(1000);

            Console.WriteLine("Купите подписку и слушайте музыку везде и всегда!");
            Thread.Sleep(2000);

            Console.WriteLine("Оформите премиум-подписку на наш сервис, чтобы не видеть рекламу!");
            Thread.Sleep(3000);
        }
    }
}
