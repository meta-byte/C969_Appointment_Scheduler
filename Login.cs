using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using AndrewHowardSchedulerApp.DataClasses;
using AndrewHowardSchedulerApp.DB;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace AndrewHowardSchedulerApp
{
    public partial class login : Form
    {

        string loginErrorMessage;
        string loginErrorTitle;
        string welcomeMessage;
        string welcomeTitle;
        public delegate string Welcome(string name);

        public login()
        {
            InitializeComponent();
            detectLanguage();
        }

        private void detectLanguage()
        {
            switch (CultureInfo.CurrentCulture.TwoLetterISOLanguageName)
            {

                case "ja":
                    japaneseLogin();
                    break;

                default:
                    englishLogin();
                    break;
            }
        }

        private void englishLogin()
        {
            this.Text = "Login";
            loginHeaderLabel.Text = "Howard Corp Appointment Scheduler";
            loginWelcomeLabel.Text = "Please Sign In";
            loginUserLabel.Text = "Username";
            loginPasswordLabel.Text = "Password";
            loginButton.Text = "Login";
            loginErrorMessage = "Invalid Username or Password";
            loginErrorTitle = "Login Error";
            welcomeMessage = " Welcome ";
            welcomeTitle = "Login success!";

        }

        private void japaneseLogin()
        {
            this.Text = "ログイン";
            loginHeaderLabel.Text = "ハワードコーポレーション 予定 スケジューラー";
            loginWelcomeLabel.Text = "サインインしてください";
            loginUserLabel.Text = "ユーザー名";
            loginPasswordLabel.Text = "パスワード";
            loginButton.Text = "ログインする";
            loginErrorMessage = "無効なユーザー名またはパスワード";
            loginErrorTitle = "ログインエラー";
            welcomeMessage = "いらっしゃいませ! ";
            welcomeTitle = "ログイン成功！";
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = loginUserField.Text;
            string password = loginPasswordField.Text;
            DataOperations.Login(username, password);

            var currentUser = User.UserID;

            if (currentUser != 0)
            {
                //A small lambda for a welcome message that works in Japanese and English.
                Welcome obj = (currentUsername) => { return welcomeMessage + currentUsername ; };
                string Welcome = obj.Invoke(User.Username);
                MessageBox.Show(Welcome, welcomeTitle, MessageBoxButtons.OK);

                this.Hide();
                Appointments Appointments = new Appointments(currentUser);
                DataOperations.LogActivity(User.Username, "logged in");
                Appointments.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show(loginErrorMessage,loginErrorTitle, MessageBoxButtons.OK);
            }

        }
    }
}
