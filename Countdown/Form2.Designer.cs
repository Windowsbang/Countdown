namespace Countdown
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.textBoxMonth = new System.Windows.Forms.TextBox();
            this.textBoxDay = new System.Windows.Forms.TextBox();
            this.SaveCountdown = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxAutoStart = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxProject = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(39, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "倒计时项目：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(39, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "结束日期：";
            // 
            // textBoxYear
            // 
            this.textBoxYear.Font = new System.Drawing.Font("宋体", 14F);
            this.textBoxYear.Location = new System.Drawing.Point(225, 142);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(122, 39);
            this.textBoxYear.TabIndex = 3;
            // 
            // textBoxMonth
            // 
            this.textBoxMonth.Font = new System.Drawing.Font("宋体", 14F);
            this.textBoxMonth.Location = new System.Drawing.Point(399, 142);
            this.textBoxMonth.Name = "textBoxMonth";
            this.textBoxMonth.Size = new System.Drawing.Size(122, 39);
            this.textBoxMonth.TabIndex = 4;
            // 
            // textBoxDay
            // 
            this.textBoxDay.Font = new System.Drawing.Font("宋体", 14F);
            this.textBoxDay.Location = new System.Drawing.Point(573, 142);
            this.textBoxDay.Name = "textBoxDay";
            this.textBoxDay.Size = new System.Drawing.Size(122, 39);
            this.textBoxDay.TabIndex = 5;
            // 
            // SaveCountdown
            // 
            this.SaveCountdown.Font = new System.Drawing.Font("宋体", 12F);
            this.SaveCountdown.Location = new System.Drawing.Point(504, 37);
            this.SaveCountdown.Name = "SaveCountdown";
            this.SaveCountdown.Size = new System.Drawing.Size(214, 56);
            this.SaveCountdown.TabIndex = 6;
            this.SaveCountdown.Text = "保存";
            this.SaveCountdown.UseVisualStyleBackColor = true;
            this.SaveCountdown.Click += new System.EventHandler(this.SaveCountdown_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14F);
            this.label3.Location = new System.Drawing.Point(353, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 28);
            this.label3.TabIndex = 7;
            this.label3.Text = "年";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14F);
            this.label4.Location = new System.Drawing.Point(527, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 28);
            this.label4.TabIndex = 8;
            this.label4.Text = "月";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14F);
            this.label5.Location = new System.Drawing.Point(701, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 28);
            this.label5.TabIndex = 9;
            this.label5.Text = "日";
            // 
            // checkBoxAutoStart
            // 
            this.checkBoxAutoStart.AutoSize = true;
            this.checkBoxAutoStart.Location = new System.Drawing.Point(44, 208);
            this.checkBoxAutoStart.Name = "checkBoxAutoStart";
            this.checkBoxAutoStart.Size = new System.Drawing.Size(142, 22);
            this.checkBoxAutoStart.TabIndex = 11;
            this.checkBoxAutoStart.Text = "开机自动启动";
            this.checkBoxAutoStart.UseVisualStyleBackColor = true;
            this.checkBoxAutoStart.CheckedChanged += new System.EventHandler(this.checkBoxAutoStart_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.pictureBox1.Image = global::Countdown.Properties.Resources.片头;
            this.pictureBox1.Location = new System.Drawing.Point(276, 187);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(206, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // textBoxProject
            // 
            this.textBoxProject.Font = new System.Drawing.Font("宋体", 14F);
            this.textBoxProject.Location = new System.Drawing.Point(225, 47);
            this.textBoxProject.Name = "textBoxProject";
            this.textBoxProject.Size = new System.Drawing.Size(257, 39);
            this.textBoxProject.TabIndex = 12;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(777, 317);
            this.Controls.Add(this.textBoxProject);
            this.Controls.Add(this.checkBoxAutoStart);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SaveCountdown);
            this.Controls.Add(this.textBoxDay);
            this.Controls.Add(this.textBoxMonth);
            this.Controls.Add(this.textBoxYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.ShowInTaskbar = false;
            this.Text = "设置";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.TextBox textBoxMonth;
        private System.Windows.Forms.TextBox textBoxDay;
        private System.Windows.Forms.Button SaveCountdown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBoxAutoStart;
        private System.Windows.Forms.TextBox textBoxProject;
    }
}