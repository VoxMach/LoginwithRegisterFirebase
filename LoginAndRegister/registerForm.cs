using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace LoginAndRegister
{
    public partial class registerForm : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {

            AuthSecret = "ib5kqbglNj5V4AbVoTJ4GWK6yAINgchKrCjzgLS4",
            BasePath = "https://fir-tutorials-e53b7.firebaseio.com/"

        };
        IFirebaseClient client;

        //same to the other form need to declare it.
        public registerForm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void registerForm_Load(object sender, EventArgs e)
        {
            try
            {
                //also this one.
                client = new FireSharp.FirebaseClient(config);

                if (client != null)
                {


                    this.CenterToScreen();
                    this.Size = Screen.PrimaryScreen.WorkingArea.Size;
                    this.WindowState = FormWindowState.Normal;

                }

            }
            catch
            {
                MessageBox.Show("Connection Fail.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Register

            if (string.IsNullOrEmpty(username.Text) || string.IsNullOrEmpty(password.Text)
                || string.IsNullOrEmpty(id.Text)){
                //Check all textbox if some are Empty.
                MessageBox.Show("Please Specify All Data Needed.");
            }
            else
            {

                //The Register Class
                var register = new register
                {

                    username = username.Text,
                    password = password.Text,
                    id = id.Text

                };

                //but if you want to have like a unique key use Push not Set.
                FirebaseResponse response = client.Set("Users/" + id.Text, register);
                
                register res = response.ResultAs<register>();
                MessageBox.Show("Register Account Successfully");
                id.Text = string.Empty;
                username.Text = string.Empty;
                password.Text = string.Empty;
            }
        }

        private void id_Leave(object sender, EventArgs e)
        {
            //Identifying if the ID is existed or not.
            // From looping it using foreach.

            FirebaseResponse response = client.Get("Users/");
            Dictionary<string , register> getSameId = response.ResultAs<Dictionary<string,register>>();
            foreach (var sameID in getSameId)
            {
                string getsame = sameID.Value.id;
                if (id.Text == getsame)
                {
                    MessageBox.Show("ID is Already Taken.");
                    id.Text = string.Empty;
                    break;
                }

                // Thats All the Source Code is on the below just click it.
                // Thnks for Watching  i Hope i help.
                //have a nice day.
            }
        
        
        }
    }
}
