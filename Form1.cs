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
        Timer t = new Timer();
        public static List<Keys> keysDown = new List<Keys>();
        Entity e;
        World w;

        public Form1()
        {
            InitializeComponent();
            t.Tick += new EventHandler(worldTickElapsed);
            t.Interval = 20;
            t.Enabled = true;
            t.Start();
            w = new World(pictureBox2, this, "", 100, 3);
            e = new Entity(pictureBox1);
            e.spawnAtLocation(new Location(w, 20, 50));
        }

        private void worldTickElapsed(object sender, EventArgs e)
        {
            t.Stop();
            /* This is the game timer, events are repeated between the start and stop lines */
            this.e.applyVectors();
            
            if (keysDown.Contains(Keys.Left)) {
                Vector v = new Vector(Axis.X);
                v.setForce(2);
                v.setSpeed(Direction.LEFT, 5);
                this.e.getLocation().setVectorX(v);
            }

            if (keysDown.Contains(Keys.Right)) {
                Vector v = new Vector(Axis.X);
                v.setForce(2);
                v.setSpeed(Direction.RIGHT, 5);
                this.e.getLocation().setVectorX(v);
            }

            if (keysDown.Contains(Keys.Up) && this.e.isOnGround()) {
                Vector v = new Vector(Axis.Y);
                v.setForce(9);
                v.setSpeed(4);
                this.e.getLocation().setVectorY(v);
            }
            /////////////////////// No Code Here!!! //////////////////////////////////////////
            t.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (keysDown.Contains(e.KeyCode)) return;
            keysDown.Add(e.KeyCode);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
                keysDown.Remove(e.KeyCode);
        }
    }
}
