using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        BindingSource bs = new BindingSource();
        SqlDataAdapter sqd = new SqlDataAdapter();
        string select_tab = "tovar";
        static string con_string = "Server=db.edu.cchgeu.ru;DataBase=193_Bordohin;User=193_Bordohin;Password=193_Bordohin";
        SqlConnection con = new SqlConnection(con_string);
        public Form1()
        {
            InitializeComponent();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bs;
            zdg(select_tab);

        }

        private void zdg(string t)
        {
            string cmd = $"select * from {t}";
            try
            {
                sqd = new SqlDataAdapter(cmd, con);
                SqlCommandBuilder cb = new SqlCommandBuilder(sqd);
                DataTable dt = new DataTable();
                sqd.Fill(dt);
                bs.DataSource = dt;
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqd.Update((DataTable)bs.DataSource);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            zdg(select_tab);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            select_tab = "tovar";
            zdg(select_tab);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            select_tab = "roles";
            zdg(select_tab);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            select_tab = "users";
            zdg(select_tab);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            select_tab = "category";
            zdg(select_tab);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo)
                == DialogResult.Yes)
            {
                e.Cancel = false;
                
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }


   






    

    
}
