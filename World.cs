using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerScienceUtilities
{
    public class World
    {

        private String texturePath;
        private PictureBox worldBox;
        private int depth;
        private int gravity;
        
        private Form f;

        private List<Entity> residents = new List<Entity>();

        public World(PictureBox worldBox, Form form, String texturePath, int depth, int gravity) {
            this.texturePath = texturePath;
            this.worldBox = worldBox;
            this.depth = depth;
            worldBox.Size = form.Size;
            this.gravity = gravity;
            WorldServer.registerWorld(this);
        }

        public int getGravity() {
            return gravity * -1;
        }

        public List<Entity> getResidents() {
            return residents;
        }

        public int getDepth() {
            return depth;
        }

        public void removeResident(Entity e) {
            if (residents.Contains(e))
            residents.Remove(e);
        }

        public void addAsResident(Entity e) {
            foreach (World w in WorldServer.getRegisteredWorlds()) {
                    w.removeResident(e);
            }
            residents.Add(e);
        }

    }
}
