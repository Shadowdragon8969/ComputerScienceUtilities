using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerScienceUtilities
{
    public class Vector
    {

        private Axis x;
        private int forceX = 0;
        private int forceY = 0;
        private int speedX = 0;
        private int speedY = 0;

        public Vector(Axis ax) {
            this.x = ax;
        }

        public void setForce(int amt) {
            if (x == Axis.X) {
                forceX = amt;
            }
            if (x == Axis.Y) {
                forceY = amt;
            }
        }

        public void setSpeed(int amt) {
            if (x == Axis.X) {
                speedX = amt;
            }
            if (x == Axis.Y) {
                speedY = amt;
            }
        }

        public void setSpeed(Direction dir, int amt) {
            if (dir == Direction.LEFT) amt = amt * -1;
            if (dir == Direction.RIGHT) amt = amt * 1;
            speedX = amt;
        }

        public int getSpeed() {
            if (x == Axis.X) return speedX;
            if (x == Axis.Y) return speedY;
            return 0;
        }

        public int getForce() {
            if (x == Axis.X) return forceX;
            if (x == Axis.Y) return forceY;
            return 0;
        }

    }
}
