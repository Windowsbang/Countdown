using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string projectPath = Path.Combine(currentDirectory, "project.txt");
                string timePath = Path.Combine(currentDirectory, "time.txt");
                string StartedTimePath = Path.Combine(currentDirectory, "Startedtime.txt");
                string projectText = File.ReadAllText(projectPath);
                label1.Text = $"距离{projectText}还有";
                DateTime today = DateTime.Today;
                long unixTimestampToday = ((DateTimeOffset)today).ToUnixTimeSeconds();
                long timestampFromFile = long.Parse(File.ReadAllText(timePath));
                long timeDifference = timestampFromFile - unixTimestampToday;
                long differenceInDays = timeDifference / 86400;
                label2.Text = differenceInDays.ToString() + "天";

                if (!File.Exists(StartedTimePath))
                {
                    ProgressToTime.Visible = false;
                }
                else
                {
                    long startedUnix = long.Parse(File.ReadAllText(StartedTimePath));
                    int startedDays = (int)(startedUnix / 86400 - 1577667200); //开始时间减2020年1月1日
                    int endDays = (int)(timestampFromFile / 86400 - 1577667200); //结束时间减2020年1月1日
                    int todayDays = (int)(unixTimestampToday / 86400 - 1577667200); //当天时间减2020年1月1日

                    // 计算进度条的最大值
                    int maxDays = endDays - startedDays;
                    ProgressToTime.Maximum = maxDays;

                    // 计算当前进度
                    int currentDays = todayDays - startedDays;
                    ProgressToTime.Value = currentDays;

                    // 设置进度条的最小值
                    ProgressToTime.Minimum = 0;

                    ProgressToTime.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
                Form2 form2 = new Form2();
                form2.Show();
            }
        }

        private void MinimizeForm(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }

    
}