using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAlgoritmHearthstone
{
    // FEL?
    public enum MyStatusEffect { Attackable, Taunt, Dead, OnHand };
    public enum AttackStatus { CannotAttack, HasAttacked, CanAttack };
    public class Friendly
    {
        public bool playerFace;
        public int manaCost { get; }
        public int life;
        public int damage;
        public string name;
        public int cardScore;
        public MyStatusEffect status;
        public AttackStatus attackStatus;
        public Friendly(MyStatusEffect myStatusEffect, bool playerFace, string name, int life = 1, int dmg = 1)
        {
            this.manaCost = (life + dmg) % 2 == 0 ? (life + dmg) / 2 : Convert.ToInt32((life + dmg) / 2);
            this.cardScore = (dmg * 2) + life;
            this.status = myStatusEffect;
            this.playerFace = playerFace;
            this.life = life;
            this.damage = dmg;
            this.name = name;
        }


        //METHODS FOR WHAT IT CAN DO! SO ATTACK TARGET ( TAKES IN TARGET). DIE REMOVE FROM LIST??
    }
}
