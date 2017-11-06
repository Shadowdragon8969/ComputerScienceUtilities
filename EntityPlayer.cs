using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerScienceUtilities
{
    public class EntityPlayer : EntityLiving
    {

        public EntityPlayer(PictureBox box, int health, int maxhealth, string name, Label label, Color c) : base(box, health, maxhealth, name, label, c)
        {
            setHostile(false);
        }

        public void jump() {
            if (!isOnGround()) return;
            Vector v = new Vector(Axis.Y);
            v.setForce(10);
            v.setSpeed(getJumpHeight());
            getLocation().setVectorY(v);
        }

    }
}
