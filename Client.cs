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

        private FileInfo clientFile;
        private FileStream clientStream;
        private List<Keys> keysDown = new List<Keys>();

        public Client(FileInfo clientData) {
            this.clientFile = clientData;
            this.clientStream = clientFile.Open(FileMode.Open);
        }

        public static Client getClient() {
            String desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (!System.IO.Directory.GetDirectories(desktop).Contains("ClientData")) {
            System.IO.Directory.CreateDirectory(desktop + "\\" + "ClientData");
            }
            String dataPath = desktop + "\\" + "ClientData\\runTimeLog.txt";
            FileStream fs = File.Create(dataPath);
            fs.Close();
            FileInfo clientData = new FileInfo(dataPath);
            return new Client(clientData);
        }

        public void writeToRuntimeLog(String info) {
            StreamWriter sw = new StreamWriter(clientStream);
            sw.WriteLine(info);
            sw.Close();
        }

        public void pressKey(Keys key) {
            if (keysDown.Contains(key)) return;
            keysDown.Add(key);
        }

        public void releaseKey(Keys key) {
            if (keysDown.Contains(key)) keysDown.Remove(key);
        }

        public bool isKeyPressed(Keys key) {
            if (keysDown.Contains(key)) return true;
            return false;
        }

    }
}
