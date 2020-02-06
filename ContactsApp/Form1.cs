using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ContactsApp
{
    public partial class Form1 : Form
    {

        string ConnectionStr = " server = INSTRUCTORIT; database = CONTACTSAPP; user ID = ProfileUser; password = ProfileUser2019";
        string sqlCommand;
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConnectionStr))//connection with database
                {
                    myConnection.Open();
                    sqlCommand = "SELECT * FROM Contacts WHERE ID =" + txtID.Text.ToString();//sql command
                    SqlCommand myCommand = new SqlCommand(sqlCommand, myConnection);//connection with sql 
                    SqlDataReader myReader = myCommand.ExecuteReader();//to select data
                    while (myReader.Read())//while read, the program reads as an array
                    {
                        txtFirstName.Text = myReader["FirstName"].ToString();
                        txtLastName.Text = myReader["LastName"].ToString();
                        txtPhone.Text = myReader["PhoneNbr"].ToString();
                    }
                    myReader.Close();
                    myConnection.Close();
                }
                    
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using(SqlConnection myConn = new SqlConnection(ConnectionStr))
                {
                    myConn.Open();
                    sqlCommand = "INSERT INTO Contacts" + "( FirstName ,LastName ,PhoneNbr ) VALUES ('" + txtFirstName.Text.ToString() + "', '" + txtLastName.Text.ToString() + "' , '" + txtPhone.Text.ToString() + "');";
                    SqlCommand myCommand = new SqlCommand(sqlCommand, myConn);
                    myCommand.ExecuteNonQuery(); // when i dont need data back
                    myConn.Close();
                    MessageBox.Show("Add new friend successful");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection myConn = new SqlConnection(ConnectionStr))
                {
                    myConn.Open();
                    sqlCommand = "UPDATE Contacts SET FirstName= '" + txtFirstName.Text.ToString() + "', LastName='" + txtLastName.Text.ToString() + "', PhoneNbr=" + txtPhone.Text.ToString() + " WHERE ID="+txtID.Text.ToString();
                    SqlCommand myCommand = new SqlCommand(sqlCommand, myConn);
                    myCommand.ExecuteNonQuery();
                    myConn.Close();
                    MessageBox.Show("Update a friend successful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection myConn = new SqlConnection(ConnectionStr))
                {
                    myConn.Open();
                    sqlCommand = "DELETE FROM Contacts WHERE ID = " + txtIDremove.Text.ToString()+ ";";
                    SqlCommand myCommand = new SqlCommand(sqlCommand, myConn);
                    myCommand.ExecuteNonQuery();
                    myConn.Close();
                    MessageBox.Show("Delete a friend successful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
