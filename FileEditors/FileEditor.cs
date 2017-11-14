using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileEditors
{
    public class FileEditor
    {

        private FileInfo o1;
        private FileStream t;
        private String s;
        public bool j = false;
        

        public FileEditor(String folderDirectory, String filename)
        {
            String desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (!System.IO.Directory.GetDirectories(desktop).Contains(folderDirectory))
            {
                System.IO.Directory.CreateDirectory(desktop + "\\" + folderDirectory);
            }
            String dataPath = desktop + "\\" + folderDirectory "\\" + filename;
            FileInfo clientData = new FileInfo(dataPath);
            if (!clientData.Exists)
            {
                FileStream fs = File.Create(dataPath);
                fs.Close();
                s = dataPath;
                o1 = clientData;
                t = o1.Open(FileMode.Open);
                j = true;
            }
            s = dataPath;
            o1 = clientData;
            t = o1.Open(FileMode.Open);
        }

        public void func_10520(String a4_1)
        {
            t.Close();
            List<String> sts = File.ReadAllLines(s).ToList();
            sts.Add(a4_1);
            File.WriteAllLines(s, sts.ToArray());
        }

        public void func_10419(String d0_96, int tj_42)
        {
            t.Close();
            String[] sts = File.ReadAllLines(s);
            if (tj_42 > sts.Length) return;
            if (tj_42 <= sts.Length)
            {
                int skip = tj_42 - 1;
                sts.SetValue(d0_96, skip);
                File.WriteAllLines(s, sts);
            }
        }

        public void func_10308()
        {
            t.Close();
            FileStream fs = File.Create(s);
            fs.Close();

        }

        public String func_11984(int top_po)
        {
            t.Close();
            String[] sts = File.ReadAllLines(s);
            return (String)sts.GetValue(top_po - 1);
        }

        public String[] getAllLines()
        {
            t.Close();
            return File.ReadAllLines(s);
        }
    }
}
