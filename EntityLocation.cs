using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerScienceUtilities
{
    public class EntityLocation : Location
    {

        private Entity entity;
        private Direction currentDirection;
        private Vector physicsX = new Vector(Axis.X);
        private Vector physicsY = new Vector(Axis.Y);

        public EntityLocation(World w, int x, int y, Entity e) : base(w, x, y)
        {
            this.entity = e;
        }

        public Entity getEntity() {
            return entity;
        }

        public Direction getDirection() {
            return currentDirection;
        }

        public Vector getVectorX()
        {
            return physicsX;
        }

        public Vector getVectorY() {
            return physicsY;
        }

        public void setVectorX(Vector v) {
            physicsX = v;
        }

        public void setVectorY(Vector v)
        {
            physicsY = v;
        }

    }
}
