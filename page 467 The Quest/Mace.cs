using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace page_467_The_Quest
{
    class Mace: Weapon
    {
        public Mace(Game game, Point location)
            : base(game, location)
        { }

        public override string Name
        {
            get
            {
                return "Mace";
            }
        }

        const int maceRange = 50;
        const int maceDamage = 6;

        public override void Attack(Direction direction, Random random)
        {
            bool didIHitAnything = false;
            Direction directionAttacking = direction;
            switch (directionAttacking)
            {
                case Direction.Up:
                    didIHitAnything = DamageEnemy(Direction.Up, maceRange, maceDamage, random);
                    if (!didIHitAnything)
                    {
                        didIHitAnything = DamageEnemy(Direction.Right, maceRange, maceDamage, random);
                        if (!didIHitAnything)
                        {
                            didIHitAnything = DamageEnemy(Direction.Down, maceRange, maceDamage, random);
                            if (!didIHitAnything)
                            {
                                didIHitAnything = DamageEnemy(Direction.Left, maceRange, maceDamage, random);
                            }
                        }
                    }
                    break;
                case Direction.Right:
                    didIHitAnything = DamageEnemy(Direction.Right, maceRange, maceDamage, random);
                    if (!didIHitAnything)
                    {
                        didIHitAnything = DamageEnemy(Direction.Down, maceRange, maceDamage, random);
                        if (!didIHitAnything)
                        {
                            didIHitAnything = DamageEnemy(Direction.Left, maceRange, maceDamage, random); 
                            if (!didIHitAnything)
                            {
                                didIHitAnything = DamageEnemy(Direction.Up, maceRange, maceDamage, random);
                            }
                        }
                    }
                    break;
                case Direction.Down:
                    didIHitAnything = DamageEnemy(Direction.Down, maceRange, maceDamage, random);
                    if (!didIHitAnything)
                    {
                        didIHitAnything = DamageEnemy(Direction.Left, maceRange, maceDamage, random);
                        if (!didIHitAnything)
                        {
                            didIHitAnything = DamageEnemy(Direction.Up, maceRange, maceDamage, random);
                            if (!didIHitAnything)
                            {
                                didIHitAnything = DamageEnemy(Direction.Right, maceRange, maceDamage, random);
                            }
                        }
                    }
                    break;
                case Direction.Left:
                    didIHitAnything = DamageEnemy(Direction.Left, maceRange, maceDamage, random);
                    if (!didIHitAnything)
                    {
                        didIHitAnything = DamageEnemy(Direction.Up, maceRange, maceDamage, random);
                        if (!didIHitAnything)
                        {
                            didIHitAnything = DamageEnemy(Direction.Right, maceRange, maceDamage, random);
                            if (!didIHitAnything)
                            {
                                didIHitAnything = DamageEnemy(Direction.Down, maceRange, maceDamage, random);
                            }
                        }
                    }
                    break;
            }
        }
    }
}
