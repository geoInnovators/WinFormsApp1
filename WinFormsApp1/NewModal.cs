﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class NewModal : Form
    {
        public NewModal()
        {
            InitializeComponent();
        }

        public Image Image { get; set; }

        public Person NewPerson { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Image = Image.FromFile(openFileDialog.FileName);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewPerson = new Person
            {
                BirthDate = dateTimePicker1.Value,
                FirstName = textBox1.Text,
                LastName = textBox2.Text,
            };
            DialogResult = DialogResult.OK;
        }
    }
}
