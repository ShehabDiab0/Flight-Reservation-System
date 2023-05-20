﻿using FlightReservationLibrary;
using FlightReservationLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationUI
{
    public partial class ManageAircrafts : Form
    {
        private List<AircaftModel> Aircrafts;
        private int selectedIndex;

        public ManageAircrafts()
        {
            InitializeComponent();
            
            AircraftListBox.SelectedIndexChanged += AircraftListBox_SelectedIndexChanged;
            ModifyButton.Click += ModifyButton_Click;

            ReLoadAircraftsListBox();
            AircraftListBox.SelectedIndex = selectedIndex;
        }

        private void ModifyButton_Click(object? sender, EventArgs e)
        {


            throw new NotImplementedException();
        }

        private void ReLoadAircraftsListBox()
        {
            AircraftListBox.Items.Clear();
            Aircrafts = GlobalConfig.Connector.GetAllAircrafts();

            foreach(var aircraft in Aircrafts)
                AircraftListBox.Items.Add(aircraft);
            
            AircraftListBox.DisplayMember = "FullModelData";
        }

        private void AircraftListBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            int selectedIndex = AircraftListBox.SelectedIndex;
            var aircraft = Aircrafts[selectedIndex];
            IdTextbox.Text = aircraft.Id.ToString();
            SerialNTextbox.Text = aircraft.SerialNumber;
            ModelNameTextbox.Text = aircraft.ModelName;
            nSeatsTextBox.Text = aircraft.NumberOfSeats.ToString();
        }
    }
}
