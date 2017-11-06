using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerScienceUtilities
{
    public class DamageSource
    {
        private Object o;

        public DamageSource(Object cause, SourceId id) {
            o = cause;
        }

        public static DamageSource createDamageSource(Object source, SourceId id) {
            return new DamageSource(source, id);
        }

        public static SourceId ENTITY_ATTACK = new SourceId(0, "Entity_Attack");
        public static SourceId ENTITY_PROJECTILE_HIT = new SourceId(1, "Entity_Attack_Ranged");
        public static SourceId FALL = new SourceId(2, "Fall");
        public static SourceId AREA_DAMAGE = new SourceId(3, "Environment_Attack");
        //public static SourceId ENTITY_ATTACK = new SourceId(4, "Entity_Attack");
        //public static SourceId ENTITY_ATTACK = new SourceId(5, "Entity_Attack");

    }

    public class SourceId {

        private int id;
        private String name;
        private static List<int> registeredIds = new List<int>();

        public SourceId(int id, String name) {
            foreach (int i in registeredIds) {
                if (i == id) return;
            }
            this.id = id;
            this.name = name;
        }

        public int getId() {
            return id;
        }

        public String getName()
        {
            return name;
        }

    }
}
