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
            worldBox.Location = new System.Drawing.Point(0, 0);
            this.gravity = gravity;
            WorldServer.registerWorld(this);
            this.f = form;
        }

        public World(PictureBox worldBox, Form form, int depth, int gravity)
        {
            this.worldBox = worldBox;
            this.depth = depth;
            worldBox.Size = form.Size;
            worldBox.Location = new System.Drawing.Point(0, 0);
            this.gravity = gravity;
            WorldServer.registerWorld(this);
            this.f = form;
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

        public void resizeToBasicScreenDepth()
        {
            if (f.Size == Screen.PrimaryScreen.Bounds.Size)
            {
                int dep = f.Size.Height - (f.Size.Height / 10);
                depth = dep;
            }
        }

        public static int getResizeToScreenDepth(Form f)
        {
            int dep = f.Size.Height - (f.Size.Height / 4);
            return dep;
        }

    }
}
