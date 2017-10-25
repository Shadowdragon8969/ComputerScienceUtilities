using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerScienceUtilities
{
    public class Location
    {

        private World world;
        private Point scrnPnt;

        public Location(World w, int x, int y) {
            this.world = w;
            this.scrnPnt = new Point(x, y);
        }

        public World getWorld() {
            return world;
        }

        public int getX() {
            return scrnPnt.X;
        }

        public int getY() {
            return scrnPnt.Y;
        }

    }
}
