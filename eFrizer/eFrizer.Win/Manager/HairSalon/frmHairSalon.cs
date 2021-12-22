﻿using eFrizer.Model;
using eFrizer.Win.Categories;
using eFrizer.Win.Reservation;
using eFrizer.Win.Review;
using eFrizer.Win.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eFrizer.Win
{
    public partial class frmHairSalon : Form
    {
        private HairSalon _hairSalon { get; set; }
        private Manager _user;
        private APIService _cityService = new APIService("City"); 
        private APIService _hairSalonService = new APIService("HairSalon");

        public frmHairSalon(HairSalon hairSalon, Manager user)
        {
            _hairSalon = hairSalon;
            _user = user;
            InitializeComponent();
        }

        private async void frmHairSalon_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            LoadBasicInfo();
            await LoadCities();
        }

        private async Task LoadCities()
        {
            var cities = await _cityService.Get<List<City>>();
            cbCities.DataSource = cities;
            cbCities.DisplayMember = "Name";
            cbCities.ValueMember = "CityId";
            
        }

        private void LoadBasicInfo()
        {
            txtName.Text = _hairSalon.Name;
            txtAddress.Text = _hairSalon.Address;
            txtDescription.Text = _hairSalon.Description;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var req = new HairSalonUpdateRequest();
            req.Name = txtName.Text;
            req.Address = txtAddress.Text;
            req.Description = txtDescription.Text;
            req.CityId = Convert.ToInt32(cbCities.SelectedValue);
            await _hairSalonService.Update<HairSalon>(_hairSalon.HairSalonId, req);
            MessageBox.Show("Changes saved!");
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            new frmEmployeeManager(_hairSalon, _user).ShowDialog();
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            var forma = new frmService(_hairSalon);
            forma.ShowDialog();
        }

        private void btnReviews_Click(object sender, EventArgs e)
        {
            var forma = new frmReview(_hairSalon);
            forma.ShowDialog();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            var forma = new frmCategories(_hairSalon);
            forma.ShowDialog();
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            var forma = new frmReservation(_hairSalon);
            forma.ShowDialog();
        }

        private void btnLoyalty_Click(object sender, EventArgs e)
        {
            //ToDO: create helper function for all these buttons that open new forms
            var forma = new frmLoyalty();
            forma.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            var forma = new ReservationReport();
            forma.ShowDialog();
        }
    }
}
