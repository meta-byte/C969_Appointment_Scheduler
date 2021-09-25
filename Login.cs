using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace AndrewHowardSchedulerApp
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            detectLanguage();
        }

        private void detectLanguage()
        {
            switch (RegionInfo.CurrentRegion.EnglishName)
            {

                case "Japan":
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
        }

        private void japaneseLogin()
        {
            this.Text = "ログイン";
            loginHeaderLabel.Text = "ハワードコーポレーション 予定 スケジューラー";
            loginWelcomeLabel.Text = "サインインしてください";
            loginUserLabel.Text = "ユーザー名";
            loginPasswordLabel.Text = "パスワード";
            loginButton.Text = "ログインする";
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Appointments Appointments = new Appointments();
            Appointments.ShowDialog();
            this.Close();
        }
    }
}
