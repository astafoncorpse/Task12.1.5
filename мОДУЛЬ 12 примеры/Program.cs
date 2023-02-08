using Microsoft.SqlServer.Management.Smo;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Threading;
using static Program;

public class Program
{
    

    public delegate bool EligableToPremium(User UserToPremium);
    static void Main(string[] args)
    {
        User us1 = new User()
        {
            Login = 123,
            Name = "Роман",
            IsPremium = true,
            
        };
        User us2 = new User()
        {
            Login = 525,
            Name = "Иван",
            IsPremium = false,
            
        };
        User us3 = new User()
        {
            Login = 631,
            Name = "Наталья",
            IsPremium = true,
            
        };
        User us4 = new User()
        {
            Login = 137,
            Name = "Евгений",
            IsPremium = false,
            
        };
        List<User> listUsers = new List<User>();
        listUsers.Add(us1);
        listUsers.Add(us2);
        listUsers.Add(us3);
        listUsers.Add(us4);

        EligableToPremium eligableToPremium = Premium;
        User.PremiumUser(listUsers, eligableToPremium);
        Console.ReadKey();

    }
    public static bool Premium(User user)
    {
        if (user.IsPremium == true )
            
        {
            Console.WriteLine("User {0} Premium", user.Name);
            Console.WriteLine("Спасибо за Premium подписку");
            return true;
        }

        else
        {
            Console.WriteLine("User {0} Premium", user.Name);

            Console.WriteLine("Если у Вас нет подписки Premium, то просмотрите рекламу!");

            Console.WriteLine("Посетите наш новый сайт с бесплатными играми free.games.for.a.fool.com");
            // Остановка на 1 с
            Thread.Sleep(1000);

            Console.WriteLine("Купите подписку на МыКомбо и слушайте музыку везде и всегда.");
            // Остановка на 2 с
            Thread.Sleep(2000);

            Console.WriteLine("Оформите премиум-подписку на наш сервис, чтобы не видеть рекламу.");
            // Остановка на 3 с
            Thread.Sleep(3000);
            return false;
        }

        
    }
}	
    
public class User
{
    public int Login { get; set; }
    public string Name { get; set; }

    public bool IsPremium { get; set; }

    public static void PremiumUser(List<User> listUsers,EligableToPremium IsUserEligable)
    {
        foreach(User user in listUsers)
        {
            if(IsUserEligable(user)) 
            {
                Console.WriteLine("User {0} Premium",user.Name);
            }
        }
    }
}

