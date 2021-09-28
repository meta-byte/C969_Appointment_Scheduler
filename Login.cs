using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using AndrewHowardSchedulerApp.DataClasses;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace AndrewHowardSchedulerApp
{
    public partial class login : Form
    {

        string loginErrorMessage;
        string loginErrorTitle;

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
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = loginUserField.Text;
            string password = loginPasswordField.Text;
            DB.DataOperations.Login(username, password);

            var currentUser = User.UserID;

            if (currentUser != 0)
            {

                this.Hide();
                Appointments Appointments = new Appointments(currentUser);
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
