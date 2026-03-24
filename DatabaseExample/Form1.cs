using Microsoft.Data.SqlClient;
using System.Data;

namespace DatabaseExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;
              AttachDbFilename=|DataDirectory|\Database1.mdf;
              Integrated Security=True;
              Connect Timeout=30;";

            using var conn = new SqlConnection(cs);
            conn.Open();

            using var cmd = new SqlCommand("SELECT Name FROM [Students]", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var name = reader.GetString(0);
                listBox1.Items.Add(name);
            }


        }
    }
}
