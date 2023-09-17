using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
    
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        //Update
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var connectionString = "Data Source=S3INNOVATE\\SQLEXPRESS;Initial Catalog=UniversityDatabase;Integrated Security=True";

                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string updateCommand = "update Student set name=@name, session=@session, cgpa=@cgpa where matrixId=@matrixId";
                SqlCommand sqlCommand = new SqlCommand(updateCommand, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@matrixId", MatrixId.Text);
                sqlCommand.Parameters.AddWithValue("@name", Name.Text);
                sqlCommand.Parameters.AddWithValue("@session", Session.Text);
                sqlCommand.Parameters.AddWithValue("@cgpa", double.Parse(Cgpa.Text));
                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

                MessageBox.Show("Student's Data Updated!!!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Something error occurred");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var connectionString = "Data Source=S3INNOVATE\\SQLEXPRESS;Initial Catalog=UniversityDatabase;Integrated Security=True";

                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string readCommand = "";

                if (MatrixId.Text.ToString() == "")
                {
                    readCommand = "select * from student"; 
                }
                else
                {
                    readCommand = "select * from student where matrixId=@matrixId";
                }

                SqlCommand sqlCommand = new SqlCommand(readCommand, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@matrixId", MatrixId.Text);


                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();

                sqlDataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }
        //Delete
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var connectionString = "Data Source=S3INNOVATE\\SQLEXPRESS;Initial Catalog=UniversityDatabase;Integrated Security=True";

                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string deleteCommand = "delete student where matrixId=@matrixId";
                SqlCommand sqlCommand = new SqlCommand(deleteCommand, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@matrixId", MatrixId.Text);
                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

                MessageBox.Show("Student's Data Deleted!!!");
            }
            catch(Exception ex )
            {
                MessageBox.Show("Error");
            }
        }
        //Submit
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var connectionString = "Data Source=S3INNOVATE\\SQLEXPRESS;Initial Catalog=UniversityDatabase;Integrated Security=True";

                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                var insertQuery = "insert into student values(@matrixId, @name, @session, @cgpa)";

                SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@matrixId", MatrixId.Text);
                sqlCommand.Parameters.AddWithValue("@name", Name.Text);
                sqlCommand.Parameters.AddWithValue("@session", Session.Text);
                sqlCommand.Parameters.AddWithValue("@cgpa", double.Parse(Cgpa.Text));

                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                MessageBox.Show("Data Inserted Succesfully!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Somthing went wrong");
            }
        } 
    }
}
