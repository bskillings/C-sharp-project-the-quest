using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace page_467_The_Quest
{
    class Ghoul : Enemy
    {
        public Ghoul(Game game, Point location)
            : base(game, location, 10)
        { }

        public override void Move(Random random)
        {
            if (HitPoints > 0)
            {
                int willEnemyGoToPlayer = random.Next(3);
                if (willEnemyGoToPlayer < 2)
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
                    game.HitPlayer(4, random);
                }
            }
        }
    }
}
