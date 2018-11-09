using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace heroesFabric
{
    class Program
    {
        public static void Main()
        {
            int Choose = 0;
            string[] values = { "Jouer", "Quitter"};
            string[] Inputs = { "1", "2"};

            while (Inputs.Contains(Choose.ToString()) == false)
            {
                Console.WriteLine("\n\n\n Menu:\n\n");
                Console.WriteLine("1: Jouer seul");
                //Console.WriteLine("1: Jouer à deux");
                Console.WriteLine("2: Quitter");
                Choose = Int32.Parse(Console.ReadLine());
            }

            if (Choose == 2)
            {
                Console.WriteLine("\n\n\n Merci d'avoir joué");
                System.Threading.Thread.Sleep(2000);
                Environment.Exit(0);
            }

            if (Choose == 1)
            {
                play(new Character("User"), new Character("Bot"));
            }
        }
        public static int[] ComputeDamage(string action1, string action2, Character Player1, Character Player2)
        {
            int damage1 = 0;
            int damage2 = 0;

            int HEAL = 5;

            switch (action1)
            {
                case "attack":
                    if(action2 == "defense")
                    {
                        damage1 += Player1.attack(Player2.Defense, Player2.Dodge);
                    }
                    else
                    {
                        damage1 += Player1.attack(0, Player2.Dodge);
                    }
                    break;
                case "heal":
                    damage2 += HEAL;
                    break;
                case "nothing":
                    damage1 = 0;
                    break;
                default:
                    break;
            }
            switch (action2)
            {
                case "attack":
                    if (action1 == "defense")
                    {
                        damage2 += Player2.attack(Player1.Defense, Player1.Dodge);
                    }
                    else
                    {
                        damage2 += Player2.attack(0, Player1.Dodge);
                    }
                    break;
                case "heal":
                    damage1 += HEAL;
                    break;
                default:
                    break;
            }
            int[] damages = { damage1, damage2 };
            return damages;
        }

        public static void play(Character Player1, Character Player2)
        {
            string result_message = "";
            //players
            int MaxHealthP1 = 20;
            int MaxHealthP2 = 20;

            Console.WriteLine("Début du combat.");
            Console.WriteLine("\n");
            Console.WriteLine("Tu as: " + Player1.HealthPoint + " PV");
            Console.WriteLine("Ton adversaire a: " + Player2.HealthPoint + " PV");

            // dies
            while (true)
            {
                if (Player1.HealthPoint <= 0 && Player2.HealthPoint > 0)
                {
                    result_message = "Vous avez PERDU...";
                    System.Threading.Thread.Sleep(5000);
                    break;
                }

                else if (Player2.HealthPoint <= 0 && Player1.HealthPoint > 0)
                {
                    result_message = "Vous avez GAGNER !!!";
                    System.Threading.Thread.Sleep(5000);
                    break;
                }
                else if (Player2.HealthPoint <= 0 && Player1.HealthPoint <= 0)
                {
                    result_message = "EGALITE !!!";
                    System.Threading.Thread.Sleep(5000);
                    break;
                }
                else
                {
                    Random rand = new Random();
                    int Input1 = 0;
                    int Input2 = rand.Next(1, 4);
                    int TimePlay = 10000;
                    
                    string[] values = { "attack", "defense", "heal", "nothing" };
                    string[] Inputs = { "1", "2", "3", "9" };

                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    
                    while (!Inputs.Contains(Input1.ToString()))
                    {
                            Console.WriteLine("Sélectionner une action:");
                            Console.WriteLine("1 : Attaquer");
                            Console.WriteLine("2 : Défense");
                            Console.WriteLine("3 : Soin");
                            //read
                            Input1 = Int32.Parse(Console.ReadLine());
                    }
                        
                    if (sw.ElapsedMilliseconds > TimePlay)
                    {
                        Console.WriteLine(sw.ElapsedMilliseconds);
                        
                        Input1 = 9;

                    }
                    sw.Stop();

                    int[] applyDamages;

                    if (Input1 == 9)    
                    {
                        applyDamages = ComputeDamage(values[3], values[Input2 - 1], Player1, Player2);
                    }
                    else
                    {
                        applyDamages = ComputeDamage(values[Input1 - 1], values[Input2 - 1], Player1, Player2);
                    }

                    Player1.HealthPoint += applyDamages[1];
                    Player2.HealthPoint += applyDamages[0];

                    if (Input2 == 1)
                    {
                        Console.WriteLine("Ton adversaire attaque.");
                    }
                    else if (Input2 == 2)
                    {
                        Console.WriteLine("Ton adversaire se défend.");
                    }
                    else if (Input2 == 3)
                    {
                        Console.WriteLine("Ton adversaire se soigne.");
                    }

                    if (Input1 == 1)
                    {
                        Console.WriteLine("Tu attaques.");
                    }
                    else if (Input1 == 2)
                    {
                        Console.WriteLine("Tu te défends.");
                    }
                    else if (Input1 == 3)
                    {
                        Console.WriteLine("Tu te soignes.");
                    }
                    else if (Input1 == 9)
                    {
                        Console.WriteLine("Hé ho ? Ya quelqu'un?");
                    }
                    System.Threading.Thread.Sleep(1000);

                    //Max Health
                    if (Player1.HealthPoint > MaxHealthP1)
                    {
                        Player1.HealthPoint = MaxHealthP1;
                    }
                    if (Player2.HealthPoint > MaxHealthP2)
                    {
                        Player2.HealthPoint = MaxHealthP2;
                    }

                    Console.Clear();
                    if(Player1.HealthPoint <= MaxHealthP1/4){
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    else if(Player1.HealthPoint <= MaxHealthP1 / 2){
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                    else{
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    Console.WriteLine("Tu as: " + Player1.HealthPoint + " PV");

                    if(Player2.HealthPoint <= MaxHealthP2/4){
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    else if(Player2.HealthPoint <= MaxHealthP2 / 2){
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                    else{
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.WriteLine("Ton adversaire a: " + Player2.HealthPoint + " PV");
                    
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.WriteLine(result_message);
            Main();
        }

    }
}
