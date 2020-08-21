using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SearchAlgoritmHearthstone
{
    public class Actions 
    {
        public Enemy Target;
        public Friendly WhatUnitToAttackWith;
        public int AttackDamage;
        public bool endTurn;
        public int MaxCardsOnBoard = 10;

        Actions(Enemy Target, Friendly WhatUnitToAttackWith)
        {
            AttackDamage = WhatUnitToAttackWith.damage;
            this.Target = Target;
        }

        Actions(List<Friendly> cardsOnHand, List<Friendly> cardsOnBoard)
        {
            if (cardsOnBoard.Count < MaxCardsOnBoard)
            {
                
            }
        }

        Actions(bool EndTurn) 
        {

        }
     
    }
    //OVerload constructor of actions, one for each scenario possible?

    struct AttackTarget
    {

        public Enemy Target;
        public Friendly WhatUnitToAttackWith;
        public int AttackDamage;
        public AttackTarget(Friendly WhatUnitToAttackWith, Enemy TargetToAttack, int AttackDamage)
        {
            this.Target = TargetToAttack;
            this.WhatUnitToAttackWith = WhatUnitToAttackWith;
            this.AttackDamage = AttackDamage;
        } 
    }

     class Score
    {
        public int YourScore { get; set; } = 0;
        public int EnemyScore { get; set; } = 0;
        public Score(List<Enemy> enemiesOnBoard, List<Friendly> friendlysOnBoard)
        {
            foreach (Enemy enemy in enemiesOnBoard)
            {
                EnemyScore += enemy.cardScore;
            }

            foreach (Friendly friendly in friendlysOnBoard)
            {
                YourScore += friendly.cardScore;
            }
        }
    }
}
