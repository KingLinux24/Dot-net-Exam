using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public class DataAccess
{
    private string connectionString;
    public DataAccess()
    {
        // Get the connection string from App.config
        connectionString = ConfigurationManager.ConnectionStrings["AndroidDataManagementConnection"].ConnectionString;
    }
    // Method to get data from the database
    public DataTable GetContacts()
    {
        DataTable contactsTable = new DataTable();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Contacts"; // Replace with your actual query
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            try
            {
                connection.Open();
                adapter.Fill(contactsTable);
            }
            catch (Exception ex)
            {

                // Handle exceptions
                Console.WriteLine(ex.Message);
            }
        }
        return contactsTable;
    }
    // Method to insert a new contact
    public void InsertContact(string name, string phoneNumber, string email)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Contacts (Name, PhoneNumber, Email) VALUES (@Name, @PhoneNumber, @Email)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
            command.Parameters.AddWithValue("@Email", email);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine(ex.Message);
            }
        }
    }
}