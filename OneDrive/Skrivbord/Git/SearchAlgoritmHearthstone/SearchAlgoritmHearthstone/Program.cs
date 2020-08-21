using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Data;

namespace SearchAlgoritmHearthstone
{
    class Program
    {
        public static List<Enemy> EnemiesOnBoard = new List<Enemy>();
        public static List<Friendly> FriendlysOnBoard = new List<Friendly>();
        public static List<Friendly> FriendlysOnHand = new List<Friendly>();
        public Queue<Actions> CardsToPlay = new Queue<Actions>();
        public Score CurrentScore;


        int mana;
        int roundCounter = 2;
        //int maxMana = 10;
        int maxCardsOnHand = 10;
        int cardsOnHand = 0;

       public enum GameSequence { PlayCards = 0, Attack = 1, EndTurn  = 2}

        enum GameState { EnemyTurn, YourTurn, GameOver };

        static void Main(string[] args)
        {
            SortingAlgoritm sort = new SortingAlgoritm();
            Program Main = new Program();

            GameState gameState = GameState.YourTurn;
            GameSequence gameSequence = GameSequence.PlayCards;


            Random RngGen = new Random();

            EnemiesOnBoard.Add(new Enemy(StatusEffect.Attackable, true, 10, 0, 0, "Hero"));
            EnemiesOnBoard.Add(new Enemy(StatusEffect.Attackable, false, 2, 3, 1, "Raptor"));
            FriendlysOnBoard.Add(new Friendly(MyStatusEffect.Attackable, true, "Hero", 10, 0));
            FriendlysOnBoard.Add(new Friendly(MyStatusEffect.Attackable, false, "Tiger", 2, 3));
            FriendlysOnBoard.Add(new Friendly(MyStatusEffect.Attackable, false, "Gnome", 5, 7));




            while (!Main.GameIsOver())
            {
                Console.Clear();
                FriendlysOnBoard.ForEach(friendly => friendly.attackStatus = AttackStatus.CanAttack);
                Main.roundCounter++;
                Main.mana = Main.roundCounter <= 10 ? Main.roundCounter : 10;
                Main.ClearDeadEnemiesFromBoard(EnemiesOnBoard, FriendlysOnBoard);
                if (gameState == GameState.YourTurn)
                {
                    if (Main.cardsOnHand < Main.maxCardsOnHand)
                    {
                        FriendlysOnHand.Add(new Friendly(MyStatusEffect.OnHand, false, "Generic Card", RngGen.Next(1, 5), RngGen.Next(1, 5)));
                        Main.cardsOnHand = FriendlysOnHand.Count;
                    }
                    // = sort.CalculateAttack(GameState.YourTurn, Main.mana, EnemiesOnBoard, FriendlysOnBoard, FriendlysOnHand);
                    Console.WriteLine("Enemy Board State:");
                    Console.WriteLine($"Enemy hero Has {EnemiesOnBoard[0].life} life");
                    foreach (Enemy enemy in EnemiesOnBoard)
                    {
                        if (enemy.playerFace == false)
                        {
                            Console.WriteLine($"{enemy.name}, has {enemy.damage} damage and {enemy.life} life");


                        }
                    }
                    Console.WriteLine("\n\n\n");
                    Console.WriteLine("Your Board State:");
                    Console.WriteLine($"Your hero Has {FriendlysOnBoard[0].life} life");
                    foreach (Friendly friendly in FriendlysOnBoard)
                    {
                        if (friendly.playerFace == false)
                        {
                            Console.WriteLine($"{friendly.name}, costs: {friendly.manaCost} mana, has {friendly.damage} damage and {friendly.life} life");


                        }
                    }

                    Console.WriteLine("\n");

                    Console.WriteLine("Cards on hand:");
                    foreach (Friendly friendly in FriendlysOnHand)
                    {
                        Console.WriteLine($"{friendly.name}, costs: {friendly.manaCost} mana, has {friendly.damage} damage and {friendly.life} life and a score of {friendly.cardScore}");
                    }
                 

                    Main.CardsToPlay = new Queue<Actions>(sort.CalculateCardsToPlay(FriendlysOnHand, FriendlysOnBoard, ref Main.mana));
                

                    foreach (var item in Main.CardsToPlay)
                    {
                        Console.WriteLine(item.cardToPlay);
                        Console.WriteLine(Main.mana);
                    }

                    //switch (gameSequence)
                    //{
                    //    case GameSequence.PlayCards:

                    //      sort.

                    //        break;
                    //    case GameSequence.Attack:
                    //        break;
                    //    case GameSequence.EndTurn:
                    //        break;
                    //    default:
                    //        break;
                    //}

                    //int damageToTaget;

                    //int.TryParse(Console.ReadLine(), out damageToTaget);

                    //if (EnemiesOnBoard.Count > 1)
                    //{
                    //    EnemiesOnBoard[1].life -= damageToTaget;

                    //}


                    Main.CurrentScore = new Score(EnemiesOnBoard, FriendlysOnBoard);

                    Console.WriteLine($"Your Score: {Main.CurrentScore.YourScore}");
                    Console.WriteLine($"Enemy Score: {Main.CurrentScore.EnemyScore}");

                    Console.ReadKey();
                }

                Main.GameIsOver();
            }


        }

        private void ClearDeadEnemiesFromBoard(List<Enemy> EnemiesOnBoard, List<Friendly> friendliesOnBoard)
        {
            for (int i = 0; i < friendliesOnBoard.Count; i++)
            {
                if (friendliesOnBoard[i].life <= 0)
                {
                    friendliesOnBoard.RemoveAt(i);
                }
            }
            for (int i = 0; i < EnemiesOnBoard.Count; i++)
            {
                if (EnemiesOnBoard[i].life <= 0)
                {
                    EnemiesOnBoard.RemoveAt(i);
                }
            }
        }

        private bool GameIsOver()
        {
            if (FriendlysOnBoard[0].life <= 0 || EnemiesOnBoard[0].life <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
