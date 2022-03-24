using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TruckList.Controller;
using TruckList.Model;

namespace TruckList
{
    public partial class Form1 : Form
    {
        TruckController trucksController = new TruckController();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvTruck.DataSource = trucksController.GetAll();
        }

        private void RefreshTable()
        {
            dgvTruck.DataSource = trucksController.ShowAllTrucks();
        }

        private void btnadd(object sender, EventArgs e)
        {
            TruckTable truck = new TruckTable();
            truck.Brand = textBrand.Text;
            truck.Price = int.Parse(textPrice.Text);
            trucksController.CreateTrucks(truck);
            RefreshTable();
        }

        private void btndelate(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvTruck.CurrentRow;
            int id = int.Parse(row.Cells[0].Value.ToString());
            trucksController.DelateTrucks(id);
            RefreshTable();
        }

        private void btnupdate(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvTruck.CurrentRow;
            int id = int.Parse(row.Cells[0].Value.ToString());
            TruckTable truck = new TruckTable();
            truck.Brand = textBrand.Text;
            truck.Price = int.Parse(textPrice.Text);
            trucksController.UpdateTrucks(id, truck);
            RefreshTable();
        }
    }
}
