using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace page_467_The_Quest
{
    class Sword : Weapon
    {
        public Sword(Game game, Point location)
            : base(game, location)
        { }

        public override string Name
        {
            get
            {
                return "Sword";
            }
        }

        private int weaponRange = 25;

        private int weaponDamage = 3;

        public override void Attack(Direction direction, Random random)
        {
            bool didIHitAnything = false;
            Direction directionAttacking = direction;
            switch (directionAttacking)
            {
                case Direction.Up:
                    didIHitAnything = DamageEnemy(Direction.Up, weaponRange, weaponDamage, random);
                    if (!didIHitAnything)
                    {
                        didIHitAnything = DamageEnemy(Direction.Right, weaponRange, weaponDamage, random);
                        if (!didIHitAnything)
                        {
                            didIHitAnything = DamageEnemy(Direction.Left, weaponRange, weaponDamage, random);
                        }
                    }
                    break;
                case Direction.Right:
                    didIHitAnything = DamageEnemy(Direction.Right, weaponRange, weaponDamage, random);
                    if (!didIHitAnything)
                    {
                        didIHitAnything = DamageEnemy(Direction.Down, weaponRange, weaponDamage, random);
                        if (!didIHitAnything)
                        {
                            didIHitAnything = DamageEnemy(Direction.Up, weaponRange, weaponDamage, random);
                        }
                    }
                    break;
                case Direction.Down:
                    didIHitAnything = DamageEnemy(Direction.Down, weaponRange, weaponDamage, random);
                    if (!didIHitAnything)
                    {
                        didIHitAnything = DamageEnemy(Direction.Left, weaponRange, weaponDamage, random);
                        if (!didIHitAnything)
                        {
                            didIHitAnything = DamageEnemy(Direction.Right, weaponRange, weaponDamage, random);
                        }
                    }
                    break;
                case Direction.Left:
                    didIHitAnything = DamageEnemy(Direction.Left, weaponRange, weaponDamage, random);
                    if (!didIHitAnything)
                    {
                        didIHitAnything = DamageEnemy(Direction.Up, weaponRange, weaponDamage, random);
                        if (!didIHitAnything)
                        {
                            didIHitAnything = DamageEnemy(Direction.Down, weaponRange, weaponDamage, random);
                        }
                    }
                    break;
            }
        }
    }
}
