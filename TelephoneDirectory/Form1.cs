using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace TelephoneDirectory
{

 
    public partial class Form1 : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Phone;Integrated Security=True"); // Connection string as the parameter
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtSurname.Clear();
            txtMobile.Clear();
            txtEmail.Clear();
            comboBox1.SelectedIndex = -1;  // -1 used to clear combo box ( 0 = First Option )
            txtFirstName.Focus(); // Focuses cursor on first name field when data is cleared
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Mobiles " +
                    "(FirstName, Surname, Mobile, Email, Category) " +
                    "VALUES (@FirstName, @Surname, @Mobile, @Email, @Category)", con);

                // Use parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@Surname", txtSurname.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Category", comboBox1.Text);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}