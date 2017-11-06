using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerScienceUtilities
{
    public partial class Form1 : Form
    {
        // The timer that we will use to create repeating events
        Timer t = new Timer();
        // Your computers instance of the game
        Client client = Client.getClient();
        // The entity that will be used as the player in this example
        EntityPlayer e;
        EntityLiving enemy;
        // The world that the entity will exist in
        World w;

        public Form1()
        {
            InitializeComponent();
            ///////////////////////////////////////////////////////////////////////
            /* This sets the world properties
             * 'pictureBox2' is the PictureBox that will be used as the background
             * 'this' is the Form that the world will use
             * '100' is the Y level that is the ground, in this example, the ground is
             * 100 pixels down
             * '3' is gravity level that will push any entities that are effected by gravity
             * to the ground, the higher the number, the faster they fall!
            */
            w = new World(pictureBox2, this, "", 200, 3);

            Client.addDefault("yes");
            Client.addDefault("no");
            Client.addDefault("maybe");
            Client.addDefault("so");
            e = new EntityPlayer(pictureBox1, 10, 10, "Player1", label2);
            e.setJumpHeight(50);
            e.setMovementSpeed(20);
            client.registerClient(this);
            client.setClientPlayer(e);
            WorldServer.initWorldServer(client, e);
            
            // This sets the PictureBox that will be used as the player
            
            enemy = new EntityLiving(pictureBox3, 10, 10, "Bad Guy", label3);
            enemy.setHostile(true);
            enemy.spawnAtLocation(new Location(w, 150, 50));
            // This spawns the player at a certain location on the world
            e.spawnAtLocation(new Location(w, 50, 50));
            enemy.setAttackDamage(1);
            label1.Text = e.distance(enemy) + "";
        }

    }
}
