using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tp07.Model;

namespace Tp07
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

        private async void Buscar()
        {
            string url = "https://fakestoreapi.com/users";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);

                    List<User> Users = JsonSerializer.Deserialize<List<User>>(json);

                    dataGridView1.DataSource = Users.Select(u => new
                    {
                        u.username,
                        u.email,
                        u.password
                    }).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                }
            }
        }

        private void bt_obter_Click(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}