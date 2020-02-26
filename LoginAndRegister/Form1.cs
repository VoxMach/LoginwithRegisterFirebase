using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//FireSharp Extension 
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
namespace LoginAndRegister
{
    public partial class Form1 : Form
    {
        //Configure FirebaseConfig
        IFirebaseConfig config = new FirebaseConfig {
            
            //You can find it in Service Account.
            AuthSecret = "ib5kqbglNj5V4AbVoTJ4GWK6yAINgchKrCjzgLS4",
            //this one is on the top of the  database.
            BasePath = "https://fir-tutorials-e53b7.firebaseio.com/"

        };
        //Firebase Client
        IFirebaseClient client;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //Getting the Connection
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
        //Declare a static string
        public static string usernamepass;
        private void button1_Click(object sender, EventArgs e)
        {
            //Login

            if (string.IsNullOrEmpty(user.Text) || string.IsNullOrEmpty(pass.Text))
            {
                // Check if textbox is Empty
                MessageBox.Show("Please Put Username or Password.");
            }
            else
            {
                //Looping to get the match data using foreach
                FirebaseResponse response = client.Get("Users/");
                Dictionary<string, register> result = response.ResultAs<Dictionary<string, register>>();

                foreach (var get in result)
                {
                    string userresult = get.Value.username;
                    string passresult = get.Value.password;

                    if (user.Text == userresult)
                    {

                        if (pass.Text == passresult)
                        {

                            MessageBox.Show("Welcome " + user.Text);
                            //Declare some public string so you can pass the data to the another Frame.
                            usernamepass = user.Text;
                            home home = new home();
                            this.Hide();
                            home.ShowDialog();

                        }

                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Register Form
            registerForm rf = new registerForm();
            this.Hide();
            rf.ShowDialog();
            this.Close();
        }

        private void user_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //Show password using Checkbox
            if (checkBox1.Checked)
            {
                pass.UseSystemPasswordChar = false;
            }
            else
            {
                pass.UseSystemPasswordChar = true;
            }
        }
    }
}
