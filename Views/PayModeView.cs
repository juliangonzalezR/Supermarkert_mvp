﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket_mvp.Views
{
    public partial class PayModeView : Form, IPayModeView
    {
        private bool isEdit;
        private bool isSuccessful;
        private string message;
        public PayModeView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();

            tabControl3.TabPages.Remove(tabPagePayModeDetail);
            BtnClose.Click += delegate { this.Close(); };


        }

        private void AssociateAndRaiseViewEvents()
        {
            //buscar, llame Search cuando se haga click en boton Search
            BtnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            TxtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SearchEvent?.Invoke(this, EventArgs.Empty);
                }
            };

            BtnNew.Click += delegate
            {
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                tabControl3.TabPages.Remove(tabPagePayModeList);
                tabControl3.TabPages.Add(tabPagePayModeDetail);
                tabPagePayModeDetail.Text = "Add New Pay Mode";



            };
            BtnEdit.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabControl3.TabPages.Remove(tabPagePayModeList);
                tabControl3.TabPages.Add(tabPagePayModeDetail);
                tabPagePayModeDetail.Text = "Edit Pay Mode";
            };

            BtnSave.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    tabControl3.TabPages.Remove(tabPagePayModeDetail);
                    tabControl3.TabPages.Add(tabPagePayModeList);


                }
                MessageBox.Show(Message);

            };


            BtnDelete.Click += delegate
            {

                var result = MessageBox.Show("Are you sure you want to delete the selected Pay Mode", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);


                }

            };


            BtnCancel.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                tabControl3.TabPages.Remove(tabPagePayModeDetail);
                tabControl3.TabPages.Add(tabPagePayModeList);


            };


        }

        public string PayModeId { get { return TxtPayModeId.Text; } set { TxtPayModeId.Text = value; } }
        public string PayModeName { get { return TxtPayModeName.Text; } set { TxtPayModeName.Text = value; } }
        public string PayModeObservation { get { return TxtPayModeObservation.Text; } set { TxtPayModeObservation.Text = value; } }
        public string SearchValue { get { return TxtSearch.Text; } set { TxtSearch.Text = value; } }
        public bool IsEdit { get { return isEdit; } set { isEdit = value; } }
        public bool IsSuccessful { get { return isSuccessful; } set { isSuccessful = value; } }
        public string Message { get { return message; } set { message = value; } }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        public void SetPayModeListBildingSource(BindingSource payModeList)
        {
            DgPayMode.DataSource = payModeList;
        }

        //singleton para controlar solo una instancia del formulario
        private static PayModeView instance;
        public static PayModeView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new PayModeView();
                instance.MdiParent = parentContainer;


                instance.FormBorderStyle = FormBorderStyle.None;
                instance.Dock = DockStyle.Fill;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                {
                    instance.WindowState = FormWindowState.Normal;
                }
                instance.BringToFront();
            }
            return instance;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void PayModeView_Load(object sender, EventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {

        }

        private void BtnNew_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}