using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace page_467_The_Quest
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private Game game;
        private Random random = new Random();


        private void Form1_Load(object sender, EventArgs e)
        {
            game = new Game(new Rectangle(85, 57, 500, 200));
            game.NewLevel(random);
            UpdateCharacters();
        }


        public void UpdateCharacters()
        {
            player.Location = game.PlayerLocation;
            playerHitPointsLabel.Text = game.PlayerHitPoints.ToString();
            gameLevelLabel.Text = "Level " + game.Level;

            bool showBat = false;
            bool showGhost = false;
            bool showGhoul = false;
            int enemiesShown = 0;
            bat.Visible = showBat;
            ghost.Visible = showGhost;
            ghoul.Visible = showGhoul;

            //more code here
            foreach (Enemy enemy in game.Enemies)
            {
                if (enemy is Bat)
                {
                    bat.Location = enemy.Location;
                    batHitPointsLabel.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showBat = true;
                        enemiesShown++;
                    }
                }
                if (enemy is Ghost)
                {
                    ghost.Location = enemy.Location;
                    ghostHitPointsLabel.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhost = true;
                        enemiesShown++;
                    }
                }
                if (enemy is Ghoul)
                {
                    ghoul.Location = enemy.Location;
                    ghoulHitPointsLabel.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhoul = true;
                        enemiesShown++;
                    }
                }


                batHitPointsLabel.Visible = showBat;
                batLabel.Visible = showBat;
                bat.Visible = showBat;
                ghostHitPointsLabel.Visible = showGhost;
                ghostLabel.Visible = showGhost;
                ghost.Visible = showGhost;
                             ghoulHitPointsLabel.Visible = showGhoul;
                ghoulLabel.Visible = showGhoul;
                ghoul.Visible = showGhoul;

                
               
                sword.Visible = false;
                bow.Visible = false;
                redPotion.Visible = false;
                bluePotion.Visible = false;
                mace.Visible = false;
                Control weaponControl = null;
                switch (game.WeaponInRoom.Name)
                {
                    case "Sword":
                        weaponControl = sword;
                        break;
                    case "Bow":
                        weaponControl = bow;
                        break;
                    case "Mace":
                        weaponControl = mace;
                        break;
                    case "Blue Potion":
                        weaponControl = bluePotion;
                        break;
                    case "Red Potion":
                        weaponControl = redPotion;
                        break;

                }
                weaponControl.Visible = true;

                   inventorySword.Visible = game.CheckPlayerInventory("Sword");
                   inventoryBow.Visible = game.CheckPlayerInventory("Bow");
                   inventoryMace.Visible = game.CheckPlayerInventory("Mace");
                   inventoryRedPotion.Visible = game.CheckPlayerInventory("Red Potion");
                   inventoryBluePotion.Visible = game.CheckPlayerInventory("Blue Potion");
              

                weaponControl.Location = game.WeaponInRoom.Location;
                if (game.WeaponInRoom.PickedUp)
                {
                    weaponControl.Visible = false;
                }
                else
                {
                    weaponControl.Visible = true;
                }

                if (game.PlayerHitPoints <= 0)
                {
                    MessageBox.Show("You died");
                    Application.Exit();
                }

                if (enemiesShown < 1)
                {
                    MessageBox.Show("You have defeated the enemies on this level");
                    game.NewLevel(random);
                    UpdateCharacters();
                }

            }
        }

        private void moveLeftButton_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Left, random);
            UpdateCharacters();
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Up, random);
            UpdateCharacters();
        }

        private void moveRightButton_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Right, random);
            UpdateCharacters();
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Down, random);
            UpdateCharacters();
        }

        //attacking isn't working and I don't know why.  I think it's because I have to attack in a direction and the enemy doesn't.  THe rest of the game is okay I think.

        private void atttackUpButton_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Up, random);
            UpdateCharacters();
        }

        private void attackRightButtom_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Right, random);
            UpdateCharacters();
        }

        private void attackDownButton_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Down, random);
            UpdateCharacters();
        }

        private void attackLeftButton_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Left, random);
            UpdateCharacters();
        }

        private void inventorySword_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Sword"))
            {
                game.Equip("Sword");
                inventorySword.BorderStyle = BorderStyle.FixedSingle;
                inventoryBow.BorderStyle = BorderStyle.None;
                inventoryMace.BorderStyle = BorderStyle.None;
                inventoryBluePotion.BorderStyle = BorderStyle.None;
                inventoryRedPotion.BorderStyle = BorderStyle.None;
            }
                   }

        private void inventoryBow_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Bow"))
            {
                game.Equip("Bow");
                inventorySword.BorderStyle = BorderStyle.None;
                inventoryBow.BorderStyle = BorderStyle.FixedSingle;
                inventoryMace.BorderStyle = BorderStyle.None;
                inventoryBluePotion.BorderStyle = BorderStyle.None;
                inventoryRedPotion.BorderStyle = BorderStyle.None;
            }
           }

        private void inventoryMace_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Mace"))
            {
                game.Equip("Mace");
                inventorySword.BorderStyle = BorderStyle.None;
                inventoryBow.BorderStyle = BorderStyle.None;
                inventoryMace.BorderStyle = BorderStyle.FixedSingle;
                inventoryBluePotion.BorderStyle = BorderStyle.None;
                inventoryRedPotion.BorderStyle = BorderStyle.None;
            }
           }

        private void inventoryRedPotion_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Red Potion"))
            {
                game.Equip("Red Potion");
                inventorySword.BorderStyle = BorderStyle.None;
                inventoryBow.BorderStyle = BorderStyle.None;
                inventoryMace.BorderStyle = BorderStyle.None;
                inventoryBluePotion.BorderStyle = BorderStyle.None;
                inventoryRedPotion.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void inventoryBluePotion_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Blue Potion"))
            {
                game.Equip("Blue Potion");
                inventorySword.BorderStyle = BorderStyle.None;
                inventoryBow.BorderStyle = BorderStyle.None;
                inventoryMace.BorderStyle = BorderStyle.None;
                inventoryBluePotion.BorderStyle = BorderStyle.FixedSingle;
                inventoryRedPotion.BorderStyle = BorderStyle.None;
            }
        }
    }
}
