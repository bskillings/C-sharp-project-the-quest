using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace page_467_The_Quest
{
    class BluePotion : Weapon, IPotion
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

        public BluePotion(Game game, Point location)
            : base(game, location)
        {
            Used = false;
        }

        private const int damageHealedMax = 5;

        public override string Name
        {
            get
            {
                return "Blue Potion";
            }
        }

        public override void Attack(Direction direction, Random random)
        {
            int beforeHitPoints = game.PlayerHitPoints;
            game.IncreasePlayerHealth(damageHealedMax, random);
            Used = true;
        }
    }
}
