using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SearchAlgoritmHearthstone
{

    public class SortingAlgoritm
    {
        private Queue<Actions> AttacksToMake = new Queue<Actions>();
        private Queue<Actions> CardsToPlay = new Queue<Actions>();
        private List<Friendly> ManaSortedHand = new List<Friendly>();
        private List<Friendly> ScoreSortedHand = new List<Friendly>();



        public Queue<Actions> CalculateAttack(Enum gamestate, int CurrentMana, List<Enemy> enemies, List<Friendly> FriendlysOnBoard, List<Friendly> FriendysOnHand)
        {


            //ActionsToTake.Enqueue();

            return AttacksToMake;
            //return Queue<Actions>;

        }

        public Queue<Actions> CalculateCardsToPlay(List<Friendly> CardsOnHand, List<Friendly> CardsOnBoard, ref int CurrentMana)
        {
            ManaSortedHand.Clear();
            //ScoreSortedHand.Clear();
            CardsOnHand.Sort((x, y) => y.cardScore.CompareTo(x.cardScore));
            CardsOnHand.ForEach(friendly => ManaSortedHand.Add(friendly));
            ManaSortedHand.Sort((x, y) => x.manaCost.CompareTo(y.manaCost));
            //CardsOnHand.ForEach(friendly => ScoreSortedHand.Add(friendly));
           
                   
            for (int i = 0; i < CardsOnHand.Count; i++)
            {
                
                if (ManaSortedHand[0].manaCost < CurrentMana && CardsOnHand.Count >= 0)
                {
                    if (CardsOnBoard.Count >= 11)
                    {
                        break;
                    }
                    else
                    {
                        Actions cardToPlay = new Actions(CardsOnHand[i]);
                        CardsToPlay.Enqueue(cardToPlay);
                        CurrentMana -= CardsOnHand[i].manaCost;
                        CardsOnHand.RemoveAt(i);          
                        continue;
                    }
                }
                else
                {
                    
                }
            }


            //while (ManaSortedHand[0].manaCost < CurrentMana && ScoreSortedHand.Count != 0)
            //{
            //    int i = 1;
            //    if (CardsOnBoard.Count >= 11)
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        Actions cardToPlay = new Actions(ScoreSortedHand[i]);
            //        CardsToPlay.Enqueue(cardToPlay);
            //        continue;
            //    }

            //    i++;

            //}

            return CardsToPlay;
        }


    }
}
