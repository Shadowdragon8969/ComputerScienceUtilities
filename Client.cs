using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerScienceUtilities
{
    public class Client
    {
        private static bool p = false;
        private static bool j = false;
        private static Client o;
        private FileInfo o1;
        private FileStream t;
        private List<Keys> i = new List<Keys>();
        private String s;
        private static List<String> f = new List<String>();


        /**
         * 
         * Developer's Note:
         * I have completely obfuscated 
         * this entire class in order to prevent
         * the use of unneeded methods on your side.
         * I do not plan on renaming the obfuscated methods but if you can
         * figure out what they do go ahead and rename them.
         * 
         */


        public Client(FileInfo df_04, String yd_97) {
            if (p) {
                return;
            }
            this.o1 = df_04;
            this.t = o1.Open(FileMode.Open);
            this.s = yd_97;
            o = this;
        }

        public static void setDefaults(List<String> du_23)
        {
            f = du_23;
        }

        public static void addDefault(String su_54) {
            f.Add(su_54);
        }

        public static List<String> getDefualts() {
            return f;
        }

        public static Client getClient() {
            if (!p)
            {
                String desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (!System.IO.Directory.GetDirectories(desktop).Contains("ClientData"))
                {
                    System.IO.Directory.CreateDirectory(desktop + "\\" + "ClientData");
                }
                String dataPath = desktop + "\\" + "ClientData\\runTimeLog.txt";
                FileInfo clientData = new FileInfo(dataPath);
                if (!clientData.Exists)
                {
                    FileStream fs = File.Create(dataPath);
                    j = true;
                    fs.Close();
                }
                return new Client(clientData, dataPath);
            }
            else {
                return o;
            }
        }

        public void registerClient()
        {
            if (j) {
                foreach (String str in getDefualts())
                {
                    func_10520(str);
                }
            }
            j = false;
        }

        public void func_10520(String a4_1) {
            t.Close();
            List<String> sts = File.ReadAllLines(s).ToList();
            sts.Add(a4_1);
            File.WriteAllLines(s, sts.ToArray());
        }

        public void func_10419(String d0_96, int tj_42) {
            t.Close();
            String[] sts = File.ReadAllLines(s);
            if (tj_42 > sts.Length) return;
            if (tj_42 <= sts.Length) {
                int skip = tj_42 - 1;
                sts.SetValue(d0_96, skip);
                File.WriteAllLines(s, sts);
            }
        }

        public void func_10308() {
            t.Close();
            FileStream fs = File.Create(s);
            fs.Close();
            
        }

        public String func_11984(int top_po) {
            t.Close();
            String[] sts = File.ReadAllLines(s);
            return (String) sts.GetValue(top_po - 1);
        }

        public void pressKey(Keys key) {
            if (i.Contains(key)) return;
            i.Add(key);
        }

        public void releaseKey(Keys key) {
            if (i.Contains(key)) i.Remove(key);
        }

        public bool isKeyPressed(Keys key) {
            if (i.Contains(key)) return true;
            return false;
        }

    }
}
