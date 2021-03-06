﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VolumeHotKey
{
    internal static class ContextMenus
    {
        public static ContextMenuStrip Create()
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem item;

            // About
            item = new ToolStripMenuItem();
            item.Text = Properties.Resources.ContextMenuAboutItemText;
            item.Image = Properties.Resources.messagebox_info;
            item.Click += new EventHandler(aboutItem_Click);
            menu.Items.Add(item);

            // Exit
            item = new ToolStripMenuItem();
            item.Text = Properties.Resources.ContextMenuExitItemText;
            item.Image = Properties.Resources.exit;
            item.Click += new EventHandler(exit_Click);
            menu.Items.Add(item);

            return menu;
        }

        static void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        static void aboutItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.StartPosition = FormStartPosition.CenterScreen;
            aboutForm.ShowInTaskbar = false;
            aboutForm.ShowDialog();
        }
    }
}
