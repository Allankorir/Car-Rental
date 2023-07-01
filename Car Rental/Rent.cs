using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Car_Rental.Rent;

namespace Car_Rental
{
    public partial class Rent : Form
    {
        private List<Vehicle> vehicles;
        public Rent()
        {
            InitializeComponent();
            vehicles = new List<Vehicle>
            {
                new Vehicle { Name = "BMW", PricePerDay = 50.0m },
                new Vehicle { Name = "MERCEDES", PricePerDay = 30.0m },
                new Vehicle { Name = "PORSCHE", PricePerDay = 30.0m },
                new Vehicle { Name = "HARRIER", PricePerDay = 30.0m },
                new Vehicle { Name = "BENTLEIGH", PricePerDay = 30.0m },
                new Vehicle { Name = "LEXUS", PricePerDay = 30.0m },
                // Add more vehicles if needed
            };

            // Bind the vehicle names to the ComboBox
            comboBoxCardType.DataSource = vehicles;
            comboBoxCardType.DisplayMember = "Name";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Save data using LINQ or any data storage method of your choice
            // For simplicity, we'll use a MessageBox to simulate the successful booking.
            MessageBox.Show("Booking successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear the textboxes and reset the form for the next booking
            textBoxName.Text = "";
            pickingDateTimePicker.Value = DateTime.Now;
            returnDateTimePicker.Value = DateTime.Now;
            numOfDaysTextBox.Text = "";
            priceLabel.Text = "Price: ";
        }

        private void Rent_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public class Vehicle
        {
            public string Name { get; set; }
            public decimal PricePerDay { get; set; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime pickingDate = pickingDateTimePicker.Value;
            DateTime returnDate = returnDateTimePicker.Value;
            int numOfDays = (int)(returnDate - pickingDate).TotalDays;

            if (numOfDays <= 0)
            {
                MessageBox.Show("Return date should be after picking date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal pricePerDay = ((Vehicle)comboBoxCardType.SelectedItem).PricePerDay;
            decimal totalPrice = numOfDays * pricePerDay;

            numOfDaysTextBox.Text = numOfDays.ToString();
            priceLabel.Text = $"{totalPrice:F2}$";
        }
    }
}
