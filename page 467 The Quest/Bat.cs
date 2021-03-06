﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace page_467_The_Quest
{
    class Bat : Enemy
    {
        public Bat(Game game, Point location)
            : base(game, location, 6)
        { }

        public override void Move(Random random)
        {
            if (HitPoints > 0)
            {
                int willEnemyGoToPlayer = random.Next(2);
                if (willEnemyGoToPlayer == 0)
                {
                    location = Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
                }
                else
                {
                    Direction randomDirection = (Direction)random.Next(4);
                    location = Move(randomDirection, game.Boundaries);
                }
                if (NearPlayer())
                {
                    game.HitPlayer(2, random);
                }
            }
        }
    }
}
