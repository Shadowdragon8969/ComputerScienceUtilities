using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerScienceUtilities
{
    public class WorldServer
    {
        private static Timer t = new Timer();
        private static List<World> worlds = new List<World>();
        public static String testString = "hhh";
        public static int tickSpeed = 20;
        private static Client cl;
        private static EntityPlayer ep;

        public static void registerWorld(World w) {
            worlds.Add(w);
        }

        public static List<World> getRegisteredWorlds() {
            return worlds;
        }

        public static void initWorldServer(Client c, EntityPlayer enp)
        {
            cl = c;
            ep = enp;
            t.Tick += new EventHandler(serverTickElapsed);
            t.Interval = tickSpeed;
            t.Enabled = true;
            t.Start();
        }

        private static void serverTickElapsed(object sender, EventArgs e)
        {
            t.Stop();
            foreach (Entity ent in Entity.getRegisteredEntities())
            {
                ent.applyVectors();
                if (ent is EntityLiving && !(ent is EntityPlayer))
                {
                    EntityLiving el = (EntityLiving)ent;
                    el.aiMovement();
                }
                if (ent is EntityPlayer)
                {
                    EntityPlayer ep = (EntityPlayer)ent;
                    ep.aiMovement();
                }
            }
            if (cl.getKeysDown().Contains(cl.left.getKey())) {
                Vector v = new Vector(Axis.X);
                v.setForce(4);
                v.setSpeed(Direction.LEFT, ep.getMovementSpeed());
                ep.getLocation().setVectorX(v);
            }
            if (cl.getKeysDown().Contains(cl.right.getKey()))
            {
                Vector v = new Vector(Axis.X);
                v.setForce(4);
                v.setSpeed(Direction.RIGHT, ep.getMovementSpeed());
                ep.getLocation().setVectorX(v);
            }
            if (cl.getKeysDown().Contains(cl.up.getKey()))
            {
                ep.jump();
            }
            t.Start();
        }

    }
}
