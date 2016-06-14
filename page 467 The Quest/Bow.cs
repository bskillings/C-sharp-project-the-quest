using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace page_467_The_Quest
{
    class Bow : Weapon
    {
        public Bow(Game game, Point location)
            : base(game, location)
        { }

        public override string Name
        {
            get
            {
                return "Bow";
            }
        }

        const int bowRange = 75;
        const int bowDamage = 1;

        public override void Attack(Direction direction, Random random)
        {
            bool didIHitAnything;
            switch (direction)
            {
                case Direction.Up:
                    didIHitAnything = DamageEnemy(Direction.Up, bowRange, bowDamage, random);
                    break;
                case Direction.Right:
                    didIHitAnything = DamageEnemy(Direction.Right, bowRange, bowDamage, random);
                    break;
                case Direction.Down:
                    didIHitAnything = DamageEnemy(Direction.Down, bowRange, bowDamage, random);
                    break;
                case Direction.Left:
                    didIHitAnything = DamageEnemy(Direction.Left, bowRange, bowDamage, random);
                    break;


            }
        }
    }
}
