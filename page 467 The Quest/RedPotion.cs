using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace page_467_The_Quest
{
    class RedPotion : Weapon, IPotion
    {

        private bool used;
        public bool Used
        {
            get
            {
                return used;
            }
            set
            {
                used = value;
            }
        }

        public RedPotion(Game game, Point location)
            : base(game, location)
        {
            Used = false;
        }

        private const int DamageHealedMax = 10;
        
        public override string Name
        {
            get
            {
                return "Red Potion";
            }
        }

        public override void Attack(Direction direction, Random random)
        {
            int beforeHitPoints = game.PlayerHitPoints;
            game.IncreasePlayerHealth(DamageHealedMax, random);
            Used = true;
            
           
        }
    }
}
