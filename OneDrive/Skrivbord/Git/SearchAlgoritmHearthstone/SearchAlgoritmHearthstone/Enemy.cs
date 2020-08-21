using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SearchAlgoritmHearthstone
{
    public enum StatusEffect { Attackable, Taunt, Immune, Dead };


    public class Enemy
    {
        public bool playerFace;
        public int life;
        public int damage;
        public int position;
        public string name;
        public int cardScore;

        //public int CardScore { get { return cardScore; } set { cardScore = (damage * 2) + life; } }
        public StatusEffect status;
        public Enemy(StatusEffect statusEffect, bool playerFace, int life, int dmg, int position, string name)
        {
            this.cardScore = (dmg * 2) + life;
            this.status = statusEffect;
            this.playerFace = playerFace;
            this.life = life;
            this.damage = dmg;
            this.position = position;
            this.name = name;
        }


        //METHODS FOR WHAT IT CAN DO! SO ATTACK TARGET ( TAKES IN TARGET). DIE REMOVE FROM LIST??
    }
}
