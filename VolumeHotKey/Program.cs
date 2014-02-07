using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using KeyboardHookReduxSample;

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
                MessageBox.Show(Properties.Resources.AnotherCopyRunMessage, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Process.GetCurrentProcess().Kill();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (NotifyIcon ni = new NotifyIcon())
            {
                ni.Icon = VolumeHotKey.Properties.Resources.volumenormal_3729;
                ni.Visible = true;
                ni.Text = Properties.Resources.TrayIconHintText;
                ni.ContextMenuStrip = ContextMenus.Create();

                SetupHotkeys();
                Application.Run();
            }
            mutex.ReleaseMutex();
        }

        private static KeyboardHook _VolUpHook;
        private static KeyboardHook _VolDownHook;
        private static KeyboardHook _VolMuteHook;

        static void SetupHotkeys()
        {
            _VolUpHook = new KeyboardHook();
            _VolUpHook.SetKeys(new KeyCombination(KeysEx.F12 | KeysEx.WinLogo));
            _VolUpHook.AutoRepeat = true;

            _VolUpHook.Pressed += new EventHandler(_VolUpHook_Hooked);

            _VolUpHook.Engage();

            _VolDownHook = new KeyboardHook();
            _VolDownHook.SetKeys(new KeyCombination(KeysEx.F11 | KeysEx.WinLogo));
            _VolDownHook.AutoRepeat = true;

            _VolDownHook.Pressed += new EventHandler(_VolDownHook_Pressed);

            _VolDownHook.Engage();

            _VolMuteHook = new KeyboardHook();
            _VolMuteHook.SetKeys(new KeyCombination(KeysEx.F10 | KeysEx.WinLogo));
            _VolMuteHook.AutoRepeat = true;

            _VolMuteHook.Pressed += new EventHandler(_VolMuteHook_Pressed);

            _VolMuteHook.Engage();
        }

        static void _VolMuteHook_Pressed(object sender, EventArgs e)
        {
            VolumeController.SwitchMute();
        }

        static void _VolDownHook_Pressed(object sender, EventArgs e)
        {
            VolumeController.VolumeDown(5);
        }

        static void _VolUpHook_Hooked(object sender, EventArgs e)
        {
            VolumeController.VolumeUp(5);
        }
    }
}
