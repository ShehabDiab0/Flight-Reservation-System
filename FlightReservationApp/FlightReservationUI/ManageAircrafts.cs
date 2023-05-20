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
        private int selectedIndex = 0;


        // Make Confirmation Messages On Delete and Modify Btns
        // Validate Modified Input
        public ManageAircrafts()
        {
            InitializeComponent();

            AircraftListBox.SelectedIndexChanged += AircraftListBox_SelectedIndexChanged;
            ModifyButton.Click += ModifyButton_Click;
            DeleteAircraftButton.Click += DeleteAircraftButton_Click;

            ReLoadAircraftsListBox();
        }

        private void DeleteAircraftButton_Click(object? sender, EventArgs e)
        {
            if (Aircrafts.Count == 0)
                return;

            var selectedAircraft = Aircrafts[selectedIndex];
            GlobalConfig.Connector.DeleteAircraft_ById(selectedAircraft.Id);
            Aircrafts.RemoveAt(selectedIndex);
            ReLoadAircraftsListBox();
        }

        private void ModifyButton_Click(object? sender, EventArgs e)
        {
            if (Aircrafts.Count == 0)
                return;

            var selectedAircraft = Aircrafts[selectedIndex];
            GlobalConfig.Connector.UpdateAircraft(selectedAircraft);
            ReLoadAircraftsListBox();
        }

        private void AircraftListBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            selectedIndex = AircraftListBox.SelectedIndex;
            var aircraft = Aircrafts[selectedIndex];

            SerialNTextbox.Text = aircraft.SerialNumber;
            ModelNameTextbox.Text = aircraft.ModelName;
            nSeatsTextBox.Text = aircraft.NumberOfSeats.ToString();
        }



        private void ReLoadAircraftsListBox()
        {
            Aircrafts = GlobalConfig.Connector.GetAllAircrafts(); // Doesn't work in constructor

            ResetAircraftData();
            AircraftListBox.DataSource = Aircrafts;
            AircraftListBox.DisplayMember = "FullModelData";
        }

        private void ResetAircraftData()
        {
            SerialNTextbox.Text = "";
            ModelNameTextbox.Text = "";
            nSeatsTextBox.Text = "";
        }
    }
}