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
    
        // This is an example class meant to show how to use this game engine and how it works
        
        // The timer that we will use to create repeating events
        Timer t = new Timer();
        // Your computers instance of the game
        Client client = Client.getClient();
        // The entity that will be used as the player in this example
        Entity e;
        // The world that the entity will exist in
        World w;

        public Form1()
        {
            InitializeComponent();
            Client.addDefault("yes");
            Client.addDefault("no");
            Client.addDefault("maybe");
            Client.addDefault("so");
            client.registerClient();
            // This section makes sure that the timer fires every 20 milliseconds
            t.Tick += new EventHandler(worldTickElapsed);
            t.Interval = 20;
            t.Enabled = true;
            t.Start();
            ///////////////////////////////////////////////////////////////////////
            /* This sets the world properties
             * 'pictureBox2' is the PictureBox that will be used as the background
             * 'this' is the Form that the world will use
             * '100' is the Y level that is the ground, in this example, the ground is
             * 100 pixels down
             * '3' is gravity level that will push any entities that are effected by gravity
             * to the ground, the higher the number, the faster they fall!
            */
            w = new World(pictureBox2, this, "", 100, 3);
            // This sets the PictureBox that will be used as the player
            e = new Entity(pictureBox1);
            // This spawns the player at a certain location on the world
            e.spawnAtLocation(new Location(w, 20, 50));
        }

        // The repeating loop that fires every 20 milliseconds
        private void worldTickElapsed(object sender, EventArgs e)
        {
            t.Stop();
            /* This is the game timer, events are repeated between the start and stop lines */

            //Makes the entity move
            this.e.applyVectors();
            
            // When the Left arrow is pressed
            if (client.isKeyPressed(Keys.Left)) {
                Vector v = new Vector(Axis.X);
                v.setForce(2);
                v.setSpeed(Direction.LEFT, 5);
                this.e.getLocation().setVectorX(v);
            }

            // When the right arrow is pressed
            if (client.isKeyPressed(Keys.Right)) {
                Vector v = new Vector(Axis.X);
                v.setForce(2);
                v.setSpeed(Direction.RIGHT, 5);
                this.e.getLocation().setVectorX(v);
            }

            // When the up arrow is pressed
            if (client.isKeyPressed(Keys.Up) && this.e.isOnGround()) {
                Vector v = new Vector(Axis.Y);
                v.setForce(9);
                v.setSpeed(4);
                this.e.getLocation().setVectorY(v);
            }
            /////////////////////// No Code Here!!! //////////////////////////////////////////
            t.Start();
        }

        // When the user presses down on a key on the keyboard
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            client.pressKey(e.KeyCode);
        }

        // When the user releases a key on the keyboard
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            client.releaseKey(e.KeyCode);
        }
    }
}
