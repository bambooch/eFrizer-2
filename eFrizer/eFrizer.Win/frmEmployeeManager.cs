﻿using eFrizer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eFrizer.Win
{
    public partial class frmEmployeeManager : Form
    {
        //TODO: Should these services be actually querying an Employees table?
        //Or maybe should I make a controller that returns the Employees with a given Hair Salon Id?
        private HairSalon _hairSalon;
        private APIService _hairDressers = new APIService("HairSalonHairDresser");
        private APIService _managers = new APIService("HairSalonManager");
        private List<HairSalonHairDresser> hairSalonHairDressers;
        private List<HairSalonManager> hairSalonManagers;

        public frmEmployeeManager(HairSalon hairSalon)
        {
            _hairSalon = hairSalon;
            InitializeComponent();
        }

        private async void frmEmployeeManager_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            await LoadEmployeeList();
        }

        private async Task LoadEmployeeList()
        {
            var reqHD = new HairSalonHairDresserSearchRequest() { HairSalonId = _hairSalon.HairSalonId};
            var reqM = new HairSalonManagerSearchRequest() { HairSalonId = _hairSalon.HairSalonId};

            hairSalonHairDressers = await _hairDressers.Get<List<HairSalonHairDresser>>(reqHD);
            hairSalonManagers = await _managers.Get<List<HairSalonManager>>(reqM);

            populate_dgvEmployees();
        }

        private void populate_dgvEmployees()
        {
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("HairDresserId"),
                new DataColumn("Name"),
                new DataColumn("Surname"),
                new DataColumn("Description"),
                new DataColumn("Type"),
                new DataColumn("Status"),
            });

            foreach (var item in hairSalonHairDressers)
            {
                var row = dataTable.NewRow();
                row["HairDresserId"] = item.HairDresserId; 
                row["Name"] = item.HairDresser.Name;
                row["Surname"] = item.HairDresser.Surname;
                row["Description"] = item.HairDresser.Description;
                row["Type"] = item.GetType();
                //row["Status"] = item.Status,
                dataTable.Rows.Add(row);
            }

            //foreach (var item in managers)
            //{
            //    var row = dataTable.NewRow();
            //    row["Name"] = item.Manager.Name;
            //    row["Surname"] = item.Manager.Surname;
            //    row["Description"] = item.Manager.Description;
            //    row["Type"] = item.GetType();
            //    //row["Status"] = item.Status,
            //    dataTable.Rows.Add(row);
            //}

            dgvEmployees.DataSource = dataTable;
        }

        private async void dgvEmployees_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dresser = hairSalonHairDressers.Where(x => x.HairDresserId == Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells[0].Value)).FirstOrDefault();
            var manager = dgvEmployees.SelectedRows[0].DataBoundItem as HairSalonManager;

            if (manager == null)
            {
                var form = new frmHairDresserManager(dresser.HairDresser).ShowDialog();
            }
            else if (dresser == null)
            {
                var form = new frmManagerEmployeeManager(manager.Manager).ShowDialog();
            }

            await LoadData();
        }
    }
}
