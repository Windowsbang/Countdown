using Microsoft.Win32; 
using System;
using System.IO;
using System.Windows.Forms;

namespace Countdown
{
    public partial class Form2 : Form // Form2类继承自Form
    {
        public Form2() // 构造函数
        {
            InitializeComponent(); // 初始化窗体组件
        }

        private void SaveCountdown_Click(object sender, EventArgs e) // 保存倒计时按钮点击事件
        {
            string yearText = textBoxYear.Text; // 获取年份文本
            string monthText = textBoxMonth.Text; // 获取月份文本
            string dayText = textBoxDay.Text; // 获取日期文本

            try
            {
                // 创建一个新的DateTime对象，时间部分设置为午夜
                DateTime countdownDate = new DateTime(int.Parse(yearText), int.Parse(monthText), int.Parse(dayText), 0, 0, 0, DateTimeKind.Utc);
                TimeSpan timeDifference = countdownDate - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

                // 将时间差转换为UNIX时间戳（以秒为单位）
                long unixTimestamp = (long)timeDifference.TotalSeconds;

                // 获取应用程序的运行目录
                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string projectPath = Path.Combine(currentDirectory, "project.txt"); // 项目文件路径
                string timePath = Path.Combine(currentDirectory, "time.txt"); // 时间戳文件路径

                File.WriteAllText(projectPath, textBoxProject.Text); // 将项目文本写入文件
                File.WriteAllText(timePath, unixTimestamp.ToString()); // 将时间戳写入文件
            }
            catch (FormatException ex) // 如果格式不正确，捕获异常
            {
                // 显示错误消息
                MessageBox.Show($"错误：请将此信息提供给程序开发者：{ex}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // 获取应用程序的运行目录
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectPath = Path.Combine(currentDirectory, "project.txt"); // 项目文件路径
            string timePath = Path.Combine(currentDirectory, "time.txt"); // 时间戳文件路径
            string startedTimePath = Path.Combine(currentDirectory, "Startedtime.txt"); // 开始时间戳文件路径

            int timeDifference;
            if (!File.Exists(projectPath)) // 如果项目文件不存在
            {
                MessageBox.Show($"文件不存在：{projectPath}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                textBoxProject.Text = File.ReadAllText(projectPath); // 将项目文件内容读入文本框
            }
            if (!File.Exists(timePath)) // 如果时间戳文件不存在
            {
                MessageBox.Show($"文件不存在：{timePath}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (int.TryParse(File.ReadAllText(timePath), out timeDifference)) // 如果能够解析时间戳
                {
                    long days = timeDifference / 86400; // 将秒转换为天数
                    DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // UNIX纪元开始时间
                    DateTime countdownDate = start.AddDays(days); // 计算倒计时日期
                    string formattedDate = countdownDate.ToString("yyyy-MM-dd"); // 格式化日期
                    textBoxYear.Text = formattedDate.Split('-')[0]; // 设置年份文本
                    textBoxMonth.Text = formattedDate.Split('-')[1]; // 设置月份文本
                    textBoxDay.Text = formattedDate.Split('-')[2]; // 设置日期文本
                }
            }

            // 读取开始时间戳文件
            if (!File.Exists(startedTimePath)) // 如果开始时间戳文件不存在
            {
                MessageBox.Show($"文件不存在：{startedTimePath}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                long startedTimeDifference;
                if (long.TryParse(File.ReadAllText(startedTimePath), out startedTimeDifference)) // 如果能够解析开始时间戳
                {
                    DateTime startedCountdownDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(startedTimeDifference); // 计算开始日期
                    string startedFormattedDate = startedCountdownDate.ToString("yyyy-MM-dd"); // 格式化开始日期
                    textBoxStartedYear.Text = startedFormattedDate.Split('-')[0]; // 设置开始年份文本
                    textBoxStartedMonth.Text = startedFormattedDate.Split('-')[1]; // 设置开始月份文本
                    textBoxStartedDay.Text = startedFormattedDate.Split('-')[2]; // 设置开始日期文本
                }
            }

            // 读取当前用户的启动项从注册表
            string runKeyPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
            using (RegistryKey runKey = Registry.CurrentUser.OpenSubKey(runKeyPath))
            {
                if (runKey != null)
                {
                    // 读取倒计时键的值
                    string countdownPath = (string)runKey.GetValue("countdown");

                    // 检查值是否存在并与应用程序路径匹配
                    checkBoxAutoStart.Checked = countdownPath != null && countdownPath.Equals(Application.ExecutablePath, StringComparison.OrdinalIgnoreCase);
                }
            }
        }

        private void checkBoxAutoStart_CheckedChanged(object sender, EventArgs e) // 自动启动复选框更改事件
        {
            try
            {
                if (checkBoxAutoStart.Checked) // 如果选中自动启动
                {
                    RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true); // 创建注册表键
                    registryKey.SetValue("countdown", Application.ExecutablePath); // 设置倒计时键的值为应用程序路径
                }
                else
                {
                    RegistryKey key = Registry.CurrentUser; // 获取当前用户的注册表键
                    key.DeleteValue("countdown", false); // 删除倒计时键值
                }
            }
            catch (Exception ex) // 捕获异常
            {
                // 显示错误消息
                MessageBox.Show("错误：" + ex.Message);
            }
        }

        private void SaveStartedDate_Click(object sender, EventArgs e) // 保存开始日期按钮点击事件
        {
            string StartedYearText = textBoxStartedYear.Text; // 获取开始年份文本
            string StartedMonthText = textBoxStartedMonth.Text; // 获取开始月份文本
            string StartedDayText = textBoxStartedDay.Text; // 获取开始日期文本

            try
            {
                // 创建一个新的DateTime对象，时间部分设置为午夜
                DateTime StartedCountdownDate = new DateTime(int.Parse(StartedYearText), int.Parse(StartedMonthText), int.Parse(StartedDayText), 0, 0, 0, DateTimeKind.Utc);
                TimeSpan timeDifference = StartedCountdownDate - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

                // 将时间差转换为UNIX时间戳（以秒为单位）
                long unixTimestamp = (long)timeDifference.TotalSeconds;

                // 获取应用程序的运行目录
                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string timePath = Path.Combine(currentDirectory, "Startedtime.txt"); // 开始时间戳文件路径

                File.WriteAllText(timePath, unixTimestamp.ToString()); // 将时间戳写入文件
            }
            catch (FormatException ex) // 如果格式不正确，捕获异常
            {
                // 显示错误消息
                MessageBox.Show($"错误：请将此信息提供给程序开发者：{ex}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveAll_Click(object sender, EventArgs e)
        {
                // 调用保存倒计时日期的方法
                SaveCountdown_Click(sender, e);
                // 调用保存开始日期的方法
                SaveStartedDate_Click(sender, e);
        }
    }
}