using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerScienceUtilities
{
    public class EntityLiving : Entity
    {

        private int hp;
        private int maxhp;
        private bool damageable = true;
        private bool ai = true;
        private bool hostile = false;
        private String name = "";
        private DamageSource lastDmg;
        private DamageSource killer;
        private int movementSpeed = 3;
        private int attackDamage = 0;
        private int jumpHeight = 8;
        private int cooldownMax = 20;
        private int cooldown = 0;
        private int lastAttack = 0;
        private Label l;

        public EntityLiving(PictureBox box, int health, int maxhealth, String name, Label label) : base(box)
        {
            this.l = label;
            this.hp = health;
            this.maxhp = maxhealth;
            this.name = name;
        }

        public void kill(DamageSource killer) {
            if (!isDead())
            {
                this.killer = killer;
                l.Visible = false;
                remove();
            }
            else {
                return;
            }
        }

        public void damage(DamageSource source, int damage)
        {
            if (!damageable) return;
            this.lastDmg = source;
            this.hp = hp - damage;
            if (hp <= 0)
            {
                kill(source);
            }
        }

        public void setHostile(bool arg0) {
            hostile = arg0;
        }

        public int getMovementSpeed() {
            return movementSpeed;
        }

        public int getJumpHeight() {
            return jumpHeight;
        }

        public int getAttackDamage() {
            return attackDamage;
        }

        public void setMovementSpeed(int arg0)
        {
            movementSpeed = arg0;
        }

        public void setJumpHeight(int arg0)
        {
            jumpHeight = arg0;
        }

        public void setAttackDamage(int arg0)
        {
            attackDamage = arg0;
        }

        public void setLastAttackTime(int ti)
        {
            lastAttack = ti;
        }

        public int getAttackTime()
        {
            return lastAttack;
        }

        public void aiMovement() {
            if (cooldown < cooldownMax) cooldown++;
            if (lastAttack > 0) lastAttack--;
            if (lastAttack == 0)
            {
                getBox().BackColor = System.Drawing.Color.Orange;
            }
            l.Location = new System.Drawing.Point(getBox().Location.X, getBox().Location.Y - 20);
            l.Text = name + "\n" + hp + "/" + maxhp;
            if (hostile) {
                foreach (Entity e in Entity.getRegisteredEntities()) {
                    if (e is EntityPlayer) {
                        EntityPlayer ep = (EntityPlayer)e;
                        if (getBox().Bounds.IntersectsWith(e.getBox().Bounds) && cooldown >= cooldownMax && ep.getAttackTime() == 0) {
                            
                            ep.damage(DamageSource.createDamageSource(this, DamageSource.ENTITY_ATTACK), attackDamage);
                            ep.getBox().BackColor = System.Drawing.Color.Red;
                            ep.setLastAttackTime(10);
                        }
                        if (e.getLocation().getX() < this.getLocation().getX()) {
                            Vector v = new Vector(Axis.X);
                            v.setForce(7);
                            v.setSpeed(Direction.LEFT, movementSpeed);
                            this.getLocation().setVectorX(v);
                        }
                        if (e.getLocation().getX() > this.getLocation().getX())
                        {
                            Vector v = new Vector(Axis.X);
                            v.setForce(7);
                            v.setSpeed(Direction.RIGHT, movementSpeed);
                            this.getLocation().setVectorX(v);
                        }
                        if (e.getLocation().getY() < this.getLocation().getY() && distance(e) < 60)
                        {
                            Vector v = new Vector(Axis.Y);
                            v.setForce(7);
                            v.setSpeed(jumpHeight);
                            this.getLocation().setVectorY(v);
                        }
                    }
                }
            }
        }

    }
}
