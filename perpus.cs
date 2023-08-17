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

namespace test_input
{
    public partial class perpus : Form
    {
        public perpus()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=db.perpus;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand cmd;
        SqlDataReader read;
        SqlDataAdapter drr;
        bool mood = true;
        string sql;

        private void perpus_Load(object sender, EventArgs e)
        {
            display();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            string id_buku = textBox1.Text;
            string jb = textBox2.Text;
            string penerbit = textBox3.Text;
            string pengarang = textBox4.Text;
            string thn = textBox6.Text;
            string j_buku = comboBox1.Text;
            if (mood)
            {
                SqlCommand cmd = new SqlCommand($"Insert into buku(id_buku,jb,penerbit,pengarang,thn,j_buku) values('{id_buku}','{jb}','{penerbit}','{pengarang}','{thn}','{j_buku}')", conn);
                SqlDataAdapter drr = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                drr.Fill(dt);
                MessageBox.Show("Data Sudah Terinput");
                perpus n = new perpus();
                n.Show();
                Hide();
            }
            else
            {

            }
        }
        private void display()
        {
            SqlCommand cmd = new SqlCommand("select * from buku ", conn);
            SqlDataAdapter drr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            drr.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void close()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string id_buku = textBox1.Text;
            string jb = textBox2.Text;
            string penerbit = textBox3.Text;
            string pengarang = textBox4.Text;
            string thn = textBox6.Text;
            string j_buku = comboBox1.Text;
            if (mood)
            {
                SqlCommand cmd = new SqlCommand($"update buku set jb = '{jb}',penerbit = '{penerbit}',pengarang = '{pengarang}',thn = '{thn}',j_buku = '{j_buku}' where id_buku = '{id_buku}'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Data Sudah Kembali Terdaftar");
                display();
                close();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            close();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("yakin Ingin menghapus data ini?", "informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string id_buku = textBox1.Text;
                SqlCommand cmd = new SqlCommand($"delete from buku where id_buku='{id_buku}'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Data Berhasil Dihapus");
                display();
                close();
            }
            else
            {
                MessageBox.Show("Data gagal di hapus");
            }
        }
        private void search(string valuesearch)
        {
            SqlDataAdapter drr = new SqlDataAdapter($"select * from buku where concat (id_buku,jb,penerbit,pengarang,thn,j_buku) like '%{valuesearch}%'", conn);
            DataTable dt = new DataTable();
            drr.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            string valuesearch = textBox5.Text.ToString();
            search(valuesearch);
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Perpus_Load_1(object sender, EventArgs e)
        {
            display();
        }
    }
}
