﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class sortingSequenceSelector : UserControl
    {
        public sortingSequenceSelector()
        {
            InitializeComponent();
        }
        private void textBox_MouseDown(object sender, MouseEventArgs e)
        {
            ((TextBox)sender).DoDragDrop(((TextBox)sender), DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void textBox_DragEnter(object sender, DragEventArgs e)
        {

            int len = e.Data.GetFormats().Length - 1;
            int i;
            for (i = 0; i <= len; i++)
            {

                if (e.Data.GetFormats()[i].Equals("System.Windows.Forms.TextBox"))
                {
                    e.Effect = DragDropEffects.Move;
                }
            }

        }

        private void textBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TextBox)))
            {
                TextBox draggedTextBox = (TextBox)e.Data.GetData(typeof(TextBox));
                int orgLeft = draggedTextBox.Left;
                draggedTextBox.Left = ((TextBox)sender).Left;
                ((TextBox)sender).Left = orgLeft;

                int accumulatedLeft = 0;
                foreach (Control control in this.Controls.Cast<Control>().OrderBy(o => o.Location.X))
                {
                    TextBox currTextBox = (TextBox)control;
                    currTextBox.Left = accumulatedLeft;
                    accumulatedLeft = accumulatedLeft + currTextBox.Width;
                }

            }


        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            this.ActiveControl = this;
        }

    }
}
