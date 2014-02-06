using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace VolumeHotKey
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool isNew;
            Mutex mutex = new Mutex(true, "VOLUME_CONTROL_HOTKEY_MUTEX", out isNew);
            if(!isNew)
            {
                MessageBox.Show("В памяти компьютера уже загружен один экземпляр данного приложения", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Process.GetCurrentProcess().Kill();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SettingsForm());

            mutex.ReleaseMutex();
        }
    }
}
