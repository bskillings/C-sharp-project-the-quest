using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace page_467_The_Quest
{
    class Player : Mover
    {
        private Weapon equippedWeapon;

        public int HitPoints { get; private set; }

        private List<Weapon> inventory = new List<Weapon>();

        public IEnumerable<string> Weapons
        {
            get
            {
                List<string> names = new List<string>();
                foreach (Weapon weapon in inventory)
                {
                    names.Add(weapon.Name);
                }
                return names;
            }
        }

        public Player(Game game, Point location)
            : base(game, location)
        {
            HitPoints = 1000;
        }

        public void Hit(int maxDamage, Random random)
        {
            HitPoints -= random.Next(1, maxDamage);
        }

        public void IncreaseHealth(int health, Random random)
        {
            HitPoints += random.Next(1, health);
        }

        public void Equip(string weaponName)
        {
            foreach (Weapon weapon in inventory)
            {
                if (weapon.Name == weaponName)
                {
                    equippedWeapon = weapon;
                }
            }
        }

        public void Move(Direction direction)
        {
            base.location = Move(direction, game.Boundaries);
            if (!game.WeaponInRoom.PickedUp)
            {
                if (Nearby(location, game.WeaponInRoom.Location, 25))
                {
                    game.WeaponInRoom.PickUpWeapon();
                    inventory.Add(game.WeaponInRoom);
                    if (inventory.Count == 1)
                    {
                        Equip(game.WeaponInRoom.Name);
                    }
                                }
                //see of the weapon is nearby, and possible pick it up.
                //Check and see if the weapon is near the player (within a single unit of distance).  If so, pick up the weapon and add it to the player's inventory
                //If the weapon is the only one that the player has, go ahead and equip it immediately
            }
        }

        public void Attack(Direction direction, Random random)
        {
            if (inventory.Count > 0)
            {

                if (equippedWeapon is IPotion)
                {
                    IPotion potion = equippedWeapon as IPotion;
                    if (potion.Used == false)
                    {
                        equippedWeapon.Attack(direction, random);
                    }
                    inventory.Remove(equippedWeapon);
                }
                else
                {
                    equippedWeapon.Attack(direction, random);
                }
            }
            else
            {
                return;
            }
            //code goes here
            //if the player doesn't have an equipped weapon, this method won't do anything. 
            //if the player does have an equipped weapon, this will call the weapon's Attack() method.
            //potions are a special case.  See p. 477  maybe put something here that if it's used, remove it from inventory** shouldn't have to because it's in the poption class
        }
    }
}
