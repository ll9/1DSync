﻿using _1DSync.Controllers;
using _1DSync.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1DSync
{
    public partial class MainView : Form
    {
        private MainController _controller;

        public MainView()
        {
            InitializeComponent();
            _controller = new MainController(this);

            dataGridView1.DataSource = _controller.GetDataSource();
        }

        private void SaveButtonClicked(object sender, EventArgs e)
        {
            _controller.SaveChanges();
        }

        private void DevButton_Click(object sender, EventArgs e)
        {
            _controller.Dev();
        }

        private void SyncButton_Click(object sender, EventArgs e)
        {
            _controller.SaveChanges();
            _controller.Synchronize();
        }
    }
}
