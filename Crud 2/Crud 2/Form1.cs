using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Crud_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lihatData();
        }
        private string nip;
        MySqlConnection koneksi = new MySqlConnection("server=localhost;database=db_crud2;uid=root;pwd=;");

        private void button1_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            MySqlCommand cmd;
            cmd = koneksi.CreateCommand();
            cmd.CommandText = "insert into tbpegawai2(nip,nama,jabatan,gaji) values (@nip,@nama,@jabatan,@gaji)";
            cmd.Parameters.AddWithValue("@nip", textBox1.Text);
            cmd.Parameters.AddWithValue("@nama", textBox2.Text);
            cmd.Parameters.AddWithValue("@jabatan", textBox3.Text);
            cmd.Parameters.AddWithValue("@gaji", textBox4.Text);
            MessageBox.Show("Sukses");
            cmd.ExecuteNonQuery();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            lihatData();
            koneksi.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        public void lihatData()
        {
            MySqlCommand cmd;
            cmd = koneksi.CreateCommand();
            cmd.CommandText = "select * from tbpegawai2";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            MySqlCommand cmd;
            cmd = koneksi.CreateCommand();
            cmd.CommandText = " DELETE FROM tbpegawai2 where NIP =@nip";
            cmd.Parameters.AddWithValue("@nip", textBox1.Text);
            MessageBox.Show("Sukses");
            cmd.ExecuteNonQuery();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            lihatData();
            koneksi.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
             koneksi.Open();
            MySqlCommand cmd;
            cmd = koneksi.CreateCommand();
            cmd.CommandText = " UPDATE tbpegawai2 set NAMA = @nama, JABATAN =@jabatan,GAJI =@gaji where NIP =@nip";
            cmd.Parameters.AddWithValue("@nip", textBox1.Text);
            cmd.Parameters.AddWithValue("@nama", textBox2.Text);
            cmd.Parameters.AddWithValue("@jabatan", textBox3.Text);
            cmd.Parameters.AddWithValue("@gaji", textBox4.Text);
            MessageBox.Show("Sukses");
            cmd.ExecuteNonQuery();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            lihatData();
            koneksi.Close();
        }
    }
}
