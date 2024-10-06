using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Countdown
{
    public partial class Form1 : Form
    {
        private Timer presentationMonitorTimer;

        public Form1()
        {
            InitializeComponent();
            InitializePresentationMonitorTimer();
        }

        private void InitializePresentationMonitorTimer()
        {
            presentationMonitorTimer = new Timer();
            presentationMonitorTimer.Interval = 1000; // Set the timer interval to 1 second
            presentationMonitorTimer.Tick += CheckPresentationApplications;
            presentationMonitorTimer.Start();
        }

        private void CheckPresentationApplications(object sender, EventArgs e)
        {
            Process[] powerPointProcesses = Process.GetProcessesByName("powerpnt"); // PowerPoint
            Process[] wpsPresentationProcesses = Process.GetProcessesByName("wpp"); // WPS Presentation

            bool isPowerPointRunning = powerPointProcesses.Length > 0;
            bool isWpsPresentationRunning = wpsPresentationProcesses.Length > 0;

            if (isPowerPointRunning || isWpsPresentationRunning)
            {
                if (WindowState != FormWindowState.Minimized)
                {
                    WindowState = FormWindowState.Minimized;
                }
            }
            else
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    WindowState = FormWindowState.Normal;
                }
            }
        }

        private void ShowForm2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string projectPath = Path.Combine(currentDirectory, "project.txt");
                string timePath = Path.Combine(currentDirectory, "time.txt");

                string projectText = File.ReadAllText(projectPath);
                label1.Text = $"距离{projectText}还有";
                DateTime today = DateTime.Today;
                long unixTimestampToday = ((DateTimeOffset)today).ToUnixTimeSeconds();
                long timestampFromFile = long.Parse(File.ReadAllText(timePath));
                long timeDifference = timestampFromFile - unixTimestampToday;
                long differenceInDays = timeDifference / 86400;
                label2.Text = differenceInDays.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
                Form2 form2 = new Form2();
                form2.Show();
            }
        }

        private void CloseForm(object sender, EventArgs e)
        {
            Close();
        }

        private void MinimizeForm(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}