using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileDataManagementSystem
{
    public partial class Form1 : Form
    {
        private DataAccess dataAccess; // Instance of DataAccess class
        private DataTable contactsTable; // DataTable to hold contacts
        private DataTable smsTable; // DataTable to hold SMS messages
        private DataTable callLogTable; // DataTable to hold call logs
        private DataTable deviceInfoTable; // DataTable to hold device information


        public Form1()
        {
            InitializeComponent();
            dataAccess = new DataAccess(); // Initialize the DataAccess class
            contactsTable = new DataTable(); // Initialize the DataTable
            callLogTable = new DataTable(); // Initialize the DataTable
            InitializeContactsTable();
            InitializeSMSTable(); // Set up the DataTable structure
            InitializeCallLogTable(); // Set up the DataTable structure
            deviceInfoTable = new DataTable(); // Initialize the DataTable
            InitializeDeviceInfoTable(); // Set up the DataTable structure
        }
        private void InitializeDeviceInfoTable()
        {
            // Define the structure of the DataTable for device information
            deviceInfoTable.Columns.Add("DeviceName", typeof(string));
            deviceInfoTable.Columns.Add("Model", typeof(string));
            deviceInfoTable.Columns.Add("OSVersion", typeof(string));
            deviceInfoTable.Columns.Add("IMEI", typeof(string));
            // Bind the DataTable to the DataGridView (assuming you have a DataGridView named dataGridViewDeviceInfo)
           // dataGridViewDeviceInfo.DataSource = deviceInfoTable;
        }
        private void InitializeCallLogTable()
        {
            // Define the structure of the DataTable for call logs
            callLogTable.Columns.Add("Caller", typeof(string));
            callLogTable.Columns.Add("Receiver", typeof(string));
            callLogTable.Columns.Add("Duration", typeof(string)); // Duration as a string (e.g., "5:30")
            callLogTable.Columns.Add("Timestamp", typeof(DateTime));
            // Bind the DataTable to the DataGridView (assuming you have a DataGridView named dataGridViewCallLogs)
           // dataGridViewCallLogs.DataSource = callLogTable;
        }
        private void InitializeContactsTable()
        {
            // Define the structure of the DataTable
            contactsTable.Columns.Add("Name", typeof(string));
            contactsTable.Columns.Add("PhoneNumber", typeof(string));
            contactsTable.Columns.Add("Email", typeof(string));
            // Bind the DataTable to the DataGridView
            //dataGridViewContacts.DataSource = contactsTable;
        }
        private void InitializeSMSTable()
        {
            // Define the structure of the DataTable for SMS messages
            smsTable.Columns.Add("Sender", typeof(string));
            smsTable.Columns.Add("Receiver", typeof(string));
            smsTable.Columns.Add("Message", typeof(string));
            smsTable.Columns.Add("Timestamp", typeof(DateTime));
            // Bind the DataTable to the DataGridView (assuming you have a DataGridView named dataGridViewSMS)
          //  dataGridViewSMS.DataSource = smsTable;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            // Load contacts from extracted files (implement your logic here)
            // For demonstration, let's add some sample data
            contactsTable.Rows.Clear(); // Clear existing data
            contactsTable.Rows.Add("John Doe", "1234567890", "john@example.com");
            contactsTable.Rows.Add("Jane Smith", "0987654321", "jane@example.com");
            MessageBox.Show("Contacts loaded from files.");
        }

        private void btnSaveToDatabase_Click(object sender, EventArgs e)
        {
            // Save loaded contacts to the database
            foreach (DataRow row in contactsTable.Rows)
            {
                string name = row["Name"].ToString();
                string phoneNumber = row["PhoneNumber"].ToString();
                string email = row["Email"].ToString();
                // Insert the contact into the database
                dataAccess.InsertContact(name, phoneNumber, email);
            }
            MessageBox.Show("Contacts saved to database.");
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            // Generate and display a report of the contacts (implement your logic here)
            // For demonstration, let's just show a message box with the count of contacts
            MessageBox.Show($"Total contacts: {contactsTable.Rows.Count}");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Load SMS messages from extracted files (implement your logic here)
            // For demonstration, let's add some sample data
            smsTable.Rows.Clear(); // Clear existing data
            smsTable.Rows.Add("John Doe", "Jane Smith", "Hello, how are you?", DateTime.Now);
            smsTable.Rows.Add("Jane Smith", "John Doe", "I'm good, thanks!", DateTime.Now);
            MessageBox.Show("SMS messages loaded from files.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Save loaded SMS messages to the database
            foreach (DataRow row in smsTable.Rows)
            {
                string sender = row["Sender"].ToString();
                string receiver = row["Receiver"].ToString();
                string message = row["Message"].ToString();
                DateTime timestamp = Convert.ToDateTime(row["Timestamp"]);
                // Insert the SMS message into the database
                dataAccess.InsertSMS(sender, receiver, message, timestamp); // Implement this method in DataAccess class
            }
            MessageBox.Show("SMS messages saved to database.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Generate and display a report of the SMS messages (implement your logic here)
            // For demonstration, let's just show a message box with the count of SMS messages
            MessageBox.Show($"Total SMS messages: {smsTable.Rows.Count}");
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Load call logs from extracted files (implement your logic here)
            // For demonstration, let's add some sample data
            callLogTable.Rows.Clear(); // Clear existing data
            callLogTable.Rows.Add("John Doe", "Jane Smith", "5:30", DateTime.Now);
            callLogTable.Rows.Add("Jane Smith", "John Doe", "3:15", DateTime.Now);
            MessageBox.Show("Call logs loaded from files.");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Save loaded call logs to the database
            foreach (DataRow row in callLogTable.Rows)
            {
                string caller = row["Caller"].ToString();
                string receiver = row["Receiver"].ToString();
                string duration = row["Duration"].ToString();
                DateTime timestamp = Convert.ToDateTime(row["Timestamp"]);
                // Insert the call log into the database
                dataAccess.InsertCallLog(caller, receiver, duration, timestamp); // Implement this method in DataAccess class
            }
            MessageBox.Show("Call logs saved to database.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Generate and display a report of the call logs (implement your logic here)
            // For demonstration, let's just show a message box with the count of call logs
            MessageBox.Show($"Total call logs: {callLogTable.Rows.Count}");
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Save loaded device information to the database
            foreach (DataRow row in deviceInfoTable.Rows)
            {
                string deviceName = row["DeviceName"].ToString();
                string model = row["Model"].ToString();
                string osVersion = row["OSVersion"].ToString();
                string imei = row["IMEI"].ToString();
                // Insert the device information into the database
                dataAccess.InsertDeviceInfo(deviceName, model, osVersion, imei); // Implement this method in DataAccess class
            }
            MessageBox.Show("Device information saved to database.");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Load device information from extracted files (implement your logic here)
            // For demonstration, let's add some sample data
            deviceInfoTable.Rows.Clear(); // Clear existing data
            deviceInfoTable.Rows.Add("Samsung Galaxy S21", "S21", "Android 11", "123456789012345");
            deviceInfoTable.Rows.Add("iPhone 12", "12", "iOS 14", "987654321098765");
            MessageBox.Show("Device information loaded from files.");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Generate and display a report of the device information (implement your logic here)
            // For demonstration, let's just show a message box with the count of devices
            MessageBox.Show($"Total devices: {deviceInfoTable.Rows.Count}");
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
        private void LoadContacts()
        {
            DataAccess dataAccess = new DataAccess();
            DataTable contactsTable = dataAccess.GetContacts();
            dataGridViewContacts.DataSource = contactsTable; // Assuming you have a DataGridView named dataGridViewContacts
        }
    }
}
