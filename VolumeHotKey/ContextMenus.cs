using System;
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
            // Add the default menu options.
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem item;

            // About
            item = new ToolStripMenuItem();
            item.Text = "About";
            item.Click += new EventHandler(aboutItem_Click);
            //item.Image = Resources.About;
            menu.Items.Add(item);

            // Exit.
            item = new ToolStripMenuItem();
            item.Text = "Exit";
            item.Click += new EventHandler(exit_Click);
            //item.Image = Resources.Exit;
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
