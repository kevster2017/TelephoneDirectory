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
            Display();
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
                MessageBox.Show("Successfully added to database");
                Display();
            }
        }

        void Display()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * from Mobiles", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
            }

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            txtFirstName.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtSurname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtMobile.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtEmail.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("DELETE from Mobiles WHERE (Mobile = ' " + txtMobile.Text + "')", con);


                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
                MessageBox.Show("Successfully deleted from database");
                Display();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("DELETE from Mobiles WHERE (Mobile = ' " + txtMobile.Text + "')", con);


                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
                MessageBox.Show("Successfully deleted from database");
                Display();
            }
        }
    }
}