using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Bankomat

    {

        Account[] accounts;

        public void Menu()
        {

            int ch=0;
            do
            {
                Console.WriteLine("1.Get Balance\n2.Get Sum\n3.Add Sum\n4.Exit");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        accounts[0].GetBalance();
                        break;
                    case 2:
                        accounts[0].GetSum();
                        break;
                    case 3:
                        accounts[0].AddSum();
                        break;
                    case 4:
                    //аналог функции Exit(0);
                    default:
                        break;
                }
            } while (true);
           

        }

        public void OpenAccount()

        {

            Array.Resize(ref accounts, 1);
            int t_PIN, t_num;
            Console.Write("Enter your number: ");
            t_num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Enter your PIN: ");
            t_PIN = Convert.ToInt32(Console.ReadLine());

            Account acc = new Account(t_num, t_PIN);

            accounts[accounts.Length - 1] = acc;

        }



        public void EnterAccount()
        {
            if(accounts.Length>0)
            { 
          
                int wrPassword = 0;
                do
                {
                            int t_PIN, t_num;
                        Console.Write("Enter your number: ");
                        t_num = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        Console.Write("Enter your PIN: ");
                        t_PIN = Convert.ToInt32(Console.ReadLine());
               
            
          
                        if (t_num == accounts[0].NumAccount && t_PIN == accounts[0].PIN)
                        {
                            Console.WriteLine("Hello");
                            Menu();
                        }
                        else
                        {
                            Console.WriteLine("try again");
                            wrPassword++;

                        }
                        if (wrPassword == 3)
                        {
                            Console.WriteLine("Ваша карта заблокирована");
                            //аналог функции Exit(0);

                        }
                
                 } while (true);
            }else
            {
                OpenAccount();
            }



        }



    class Client
    {

        Bankomat bank;
        public Client()
        {
            bank = new Bankomat();
        }

        public void Menu()
        {



            int ch ;
            do
            {
                
                Console.WriteLine("1.Enter in your account\n2.Open new one");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                       bank.EnterAccount();
                        break;
                    case 2:
                        bank.OpenAccount();
                        break;
                    default:
                        break;
                }
            } while (true);

        }


    }



    class Account

    {

        int Balance = 0;

        public int NumAccount { get; set; }

        public int PIN { get; private set; }



        public Account(int num, int pin)

        {

            NumAccount = num;

            PIN = pin;

        }



        public void AddSum()
        {
            int sum;
            Console.WriteLine("Enter sum u wanna add");
            sum = Convert.ToInt32(Console.ReadLine());
            Balance += sum;

        }



        public void GetSum()
        {
            int sum;
            Console.WriteLine("Enter sum u need");
            sum = Convert.ToInt32(Console.ReadLine());
            if (sum < Balance)

            {

                Balance -= sum;

            }

            else

            {

                Console.WriteLine("Не достаточно средств!");

                Console.Read();

            }

        }



        public int GetBalance()

        {
            Console.WriteLine(Balance);
            return Balance;

        }



    }
}
