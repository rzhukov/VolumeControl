using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KeyboardHookReduxSample;

namespace VolumeHotKey
{
    public partial class SettingsForm : Form
    {
        private KeyboardHook _VolUpHook;
        private KeyboardHook _VolDownHook;
        private KeyboardHook _VolMuteHook;
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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

        void _VolMuteHook_Pressed(object sender, EventArgs e)
        {
            VolumeController.SwitchMute();
        }

        void _VolDownHook_Pressed(object sender, EventArgs e)
        {
            VolumeController.VolumeDown(5);
        }

        void _VolUpHook_Hooked(object sender, EventArgs e)
        {
            VolumeController.VolumeUp(5);
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _VolUpHook.Disengage();
            _VolDownHook.Disengage();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
