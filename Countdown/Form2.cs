using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Forms;

namespace Countdown
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void SaveCountdown_Click(object sender, EventArgs e)
        {
            string yearText = textBoxYear.Text;
            string monthText = textBoxMonth.Text;
            string dayText = textBoxDay.Text;

            try
            {
                // Create a new DateTime object with time part as midnight
                DateTime countdownDate = new DateTime(int.Parse(yearText), int.Parse(monthText), int.Parse(dayText), 0, 0, 0, DateTimeKind.Utc);
                TimeSpan timeDifference = countdownDate - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

                // Convert the time difference to UNIX timestamp (in seconds)
                long unixTimestamp = (long)timeDifference.TotalSeconds;

                // Get the application's running directory
                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string projectPath = Path.Combine(currentDirectory, "project.txt");
                string timePath = Path.Combine(currentDirectory, "time.txt");

                File.WriteAllText(projectPath, textBoxProject.Text);
                File.WriteAllText(timePath, unixTimestamp.ToString());
            }
            catch (FormatException ex)
            {
                // If the format is incorrect, display an error message
                MessageBox.Show($"Error: Please provide this to the program developer: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Get the application's running directory
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectPath = Path.Combine(currentDirectory, "project.txt");
            string timePath = Path.Combine(currentDirectory, "time.txt");

            int timeDifference;
            if (!File.Exists(projectPath))
            {
                MessageBox.Show($"文件不存在：{projectPath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                textBoxProject.Text = File.ReadAllText(projectPath);
            }
            if (!File.Exists(projectPath))
            {
                MessageBox.Show($"文件不存在：{projectPath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (int.TryParse(File.ReadAllText(timePath), out timeDifference))
                {
                    long days = timeDifference / 86400;
                    DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    DateTime countdownDate = start.AddDays(days);
                    string formattedDate = countdownDate.ToString("yyyy-MM-dd");
                    textBoxYear.Text = formattedDate.Split('-')[0];
                    textBoxMonth.Text = formattedDate.Split('-')[1];
                    textBoxDay.Text = formattedDate.Split('-')[2];
                }
            }
            // Read the current user's startup items from the registry
            string runKeyPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
            using (RegistryKey runKey = Registry.CurrentUser.OpenSubKey(runKeyPath))
            {
                if (runKey != null)
                {
                    // Read the value of the countdown key
                    string countdownPath = (string)runKey.GetValue("countdown");

                    // Check if the value exists and matches the application's path
                    checkBoxAutoStart.Checked = countdownPath != null && countdownPath.Equals(Application.ExecutablePath, StringComparison.OrdinalIgnoreCase);
                }
            }
        }

        private void checkBoxAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxAutoStart.Checked)
                {
                    RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    registryKey.SetValue("countdown", Application.ExecutablePath);
                }
                else
                {
                    RegistryKey key = Registry.CurrentUser;
                    key.DeleteValue("countdown", false); // Delete the countdown key value
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, such as displaying an error message
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}