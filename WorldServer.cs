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

        public static void registerWorld(World w) {
            worlds.Add(w);
        }

        public static List<World> getRegisteredWorlds() {
            return worlds;
        }

        public void initWorldServer()
        {
        }

    }
}
