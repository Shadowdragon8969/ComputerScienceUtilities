using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerScienceUtilities
{
    public class Entity
    {
        private static List<Entity> registeredEntities = new List<Entity>();
        private static HashMap playerWorld = new HashMap();

        private String uuid;
        private bool moveable = true;
        private bool gravity = true;
        private PictureBox box;
        private EntityLocation el;
        private bool dead = false;
        private bool spawned = false;
        private bool textured = false;
        private String texturePath;
        private World world;

        public Entity(PictureBox box) {
            this.box = box;
            
        }

        public void setTexture(String path) {
            Bitmap bm = new Bitmap(path);
            box.Image = bm;
            this.texturePath = path;
            box.Size = bm.Size;
            textured = true;
            box.BackColor = Color.Transparent;
        }

        public Boolean hasTexture()
        {
            return textured;
        }

        public void setMovable() {
            moveable = true;
        }

        public void spawnAtLocation(Location l) {
            box.Location = new Point(l.getX(), l.getY());
            playerWorld.put(this, l.getWorld());
            el = new EntityLocation(l.getWorld(), l.getX(), l.getY(), this);
            spawned = true;
            world = l.getWorld();
            dead = false;
            registeredEntities.Add(this);
        }

        public void remove() {
            box.Visible = false;
            dead = true;
            moveable = false;
        }

        public static List<Entity> getRegisteredEntities() {
            return registeredEntities;
        }

        public bool isDead() {
            return dead;
        }

        public EntityLocation getLocation() {
            if (spawned == true)
            {
                return el;
            }
            else {
                return null;
            }
        }

        public bool isOnGround() {
            if (!spawned) return true;
            if (box.Location.Y + box.Size.Height >= world.getDepth()) return true;
            return false;
        }

        public int distance(Entity e)
        {
            int factor = getLocation().getX() - e.getLocation().getX();
            if (factor < 0) factor = factor * -1;
            return factor;
        }

        public PictureBox getBox()
        {
            return box;
        }

        public void applyVectors() {
            if (!moveable) return;
            if (el.getVectorY().getForce() == 0 && isOnGround()) el.getVectorY().setSpeed(0);
            if (el.getVectorX().getForce() == 0) el.getVectorX().setSpeed(0);
            if (el.getVectorY().getForce() > 0) el.getVectorY().setForce(el.getVectorY().getForce() - 1);
            if (el.getVectorX().getForce() > 0) el.getVectorX().setForce(el.getVectorX().getForce() - 1);
            if (!isOnGround() && el.getVectorY().getForce() <= 0) el.getVectorY().setSpeed(world.getGravity());
            box.Location = new Point(box.Location.X + el.getVectorX().getSpeed(), box.Location.Y + el.getVectorY().getSpeed());
            el = new EntityLocation(world, box.Location.X, box.Location.Y, this);
        }

    }
}
