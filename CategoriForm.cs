using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 유튜브프로젝트
{
    public partial class CategoriForm : Form
    {
        mainForm mainForm = new mainForm();
        string connectionString = "Server=localhost;Database=master;Trusted_Connection=True;";

        public CategoriForm()
        {
            InitializeComponent();
            ReadData();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if(comboCategori.Text == "")
            {
                MessageBox.Show("카테고리를 선택해 주세요");
                return;
            }
                mainForm.CategoriName = comboCategori.Text;
                mainForm.CategoriForm = this;
                mainForm.FormClosed += MainForm_Closed;
                mainForm.refresh();                
                mainForm.Show();              
                this.Hide();
        }
        private void MainForm_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private async Task insertId(string CategoriName)
        {
            mainForm mainForm = new mainForm();
            mainForm.CategoriName = textnsertCategori.Text;
            // DB 연결
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = $"INSERT into CategoriTable VALUES('{CategoriName}')";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    // 파라미터 추가
                   await cmd.ExecuteNonQueryAsync();
                   comboCategori.Items.Add(textnsertCategori.Text);
                   textnsertCategori.Text = "";
                }
                catch (SqlException)
                {
                    
                }
                catch (Exception ex) // DB 연결 오류 발생
                {
                    MessageBox.Show("Error connecting to database: " + ex.Message);
                    return;
                }                
                connection.Close();               
            }
        }

        public void ReadData()
        {
            // DB 연결
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = $"select * from CategoriTable ";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            string data  = reader.GetString(0);
                            mainForm.catetegoriNames.Add(data);
                            comboCategori.Items.Add(data);
                        }
                    }
                }
                catch (Exception ex) // DB 연결 오류 발생
                {
                    MessageBox.Show("Error connecting to database: " + ex.Message);
                }

                connection.Close();                
            }
        }
        
        private async void btnInsertCategori_Click(object sender, EventArgs e)
        {
            if(textnsertCategori.Text == "")
            {
                MessageBox.Show("입력하시려는 카테고리를 입력해 주세요");
                return;
            }
            await insertId(textnsertCategori.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(comboCategori.Text == "")
            {
                MessageBox.Show("삭제하시려는 카테고리를 입력해 주세요");
                return;
            }
            // DB 연결
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = $"delete from CategoriTable where CategoriName = '{textnsertCategori.Text}'; delete from youtube where CategoriName = '{textnsertCategori.Text}';";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.ExecuteReader();
                    comboCategori.Items.Remove(textnsertCategori.Text);
                    textnsertCategori.Text = "";
                }
                catch (Exception ex) // DB 연결 오류 발생
                {
                    MessageBox.Show("Error connecting to database: " + ex.Message);
                }

                connection.Close();
            }
        }

        private void CategoriForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mainForm.isLoding)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }
    }
}
