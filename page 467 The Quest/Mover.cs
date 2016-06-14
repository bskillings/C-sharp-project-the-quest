using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace page_467_The_Quest
{
    abstract class Mover
    {
        private const int MoveInterval = 10;
        protected Point location;
        public Point Location { get { return location; } }
        protected Game game;

        public Mover(Game game, Point location)
        {
            this.game = game;
            this.location = location;
        }

        public bool Nearby(Point locationToCheck, int distance) // overload as per page 480
        {
            return Nearby(location, locationToCheck, distance);
        }

        public bool Nearby(Point myLocation, Point target, int distance)
        {
            if (Math.Abs(myLocation.X - target.X) < distance && (Math.Abs(myLocation.Y - target.Y) < distance))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Point Move(Direction direction, Rectangle boundaries) // overload  as per page 480
        {
            return Move(direction, location, boundaries);

        }

        public Point Move(Direction direction, Point currentLocation, Rectangle boundaries) // overload  as per page 480
        {
            Point newLocation = currentLocation;
            switch (direction)
            {

                case Direction.Up:
                    if (currentLocation.Y - MoveInterval >= boundaries.Top)
                    {
                        newLocation.Y -= MoveInterval;
                    }
                    break;
                case Direction.Down:
                    if (currentLocation.Y + MoveInterval <= boundaries.Bottom)
                    {
                        newLocation.Y += MoveInterval;
                    }
                    break;
                case Direction.Left:
                    if (currentLocation.X - MoveInterval >= boundaries.Left)
                    {
                        newLocation.X -= MoveInterval;
                    }
                    break;
                case Direction.Right:
                    if (currentLocation.X + MoveInterval <= boundaries.Right)
                    {
                        newLocation.X += MoveInterval;
                    }
                    break;
                default: break;
            }
            return newLocation;
        }
    }
}
