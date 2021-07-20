namespace SPAM_TOOL
{
    using CustomAlertBoxDemo;
    using InputManager;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Media;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
    using VKB;

    public class Form1 : Form
    {
        private Button btn_Clear;
        private Button btnStart;
        private ComboBox comboBox_Button;
        private IContainer components = null;
        private GroupBox groupBox_Logs;
        private GroupBox groupBox_Setting;
        private GroupBox groupBox2;
        private Label label1;
        private Label label2;
        private Label label4;
        private RichTextBox richTextBox_Log;
        private RichTextBox richTextBox1;
        protected internal System.Windows.Forms.Timer timer;
        private NumericUpDown txtReleaseTime;
        private NumericUpDown txtTime;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private NumericUpDown numericUpDown_LoopTime;
        private Label label5;
        KeyboardHook hook = new KeyboardHook();

        private int logLength = 0;
        private int maxLogLeng = 30;

        public Form1()
        {
            this.InitializeComponent();

            // register the event that is fired after the key press.
            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            // register the control + alt + F12 combination as hot key.
            hook.RegisterHotKey(SPAM_TOOL.ModifierKeys.Control, Keys.F7);
        }

        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            //MessageBox.Show(e.Modifier.ToString() + " + " + e.Key.ToString());
            this.btnStart.PerformClick();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            if (this.richTextBox_Log.Text == "")
            {
                return;
            }
            if (MessageBox.Show("Are you sure ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.richTextBox_Log.Clear();
            }
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Alert("Success Alert", Form_Alert.enmType.Success);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.send_Code())
            {
                if (!this.timer.Enabled)
                {
                    this.timer.Enabled = true;
                    this.timer.Start();
                    this.timer.Interval = int.Parse(this.txtTime.Value.ToString());
                    this.btnStart.Text = "Stop";
                    this.groupBox_Setting.Enabled = false;
                    this.btn_Clear.Enabled = false;
                    this.logToBox("Started");
                    SystemSounds.Beep.Play();
                    this.Alert("The auto press is running", Form_Alert.enmType.Info);
                }
                else
                {
                    this.timer.Enabled = false;
                    this.timer.Stop();
                    this.btnStart.Text = "Start";
                    this.groupBox_Setting.Enabled = true;
                    this.btn_Clear.Enabled = true;
                    this.logToBox("Stopped");
                    SystemSounds.Hand.Play();
                    this.Alert("The auto press is stopped", Form_Alert.enmType.Warning);
                }
            }
        }

        private void comboBox_Button_SelectedIndexChanged(object sender, EventArgs e)
        {
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Keys keys in EnumUtil.GetValues<Keys>())
            {
                this.comboBox_Button.Items.Add(keys);
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.txtTime = new System.Windows.Forms.NumericUpDown();
            this.richTextBox_Log = new System.Windows.Forms.RichTextBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.txtReleaseTime = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_Button = new System.Windows.Forms.ComboBox();
            this.groupBox_Setting = new System.Windows.Forms.GroupBox();
            this.numericUpDown_LoopTime = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox_Logs = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.txtTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReleaseTime)).BeginInit();
            this.groupBox_Setting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_LoopTime)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox_Logs.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(22, 27);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(414, 37);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Button";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Interval";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(155, 41);
            this.txtTime.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(54, 20);
            this.txtTime.TabIndex = 7;
            this.txtTime.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // richTextBox_Log
            // 
            this.richTextBox_Log.Location = new System.Drawing.Point(17, 54);
            this.richTextBox_Log.Name = "richTextBox_Log";
            this.richTextBox_Log.ReadOnly = true;
            this.richTextBox_Log.Size = new System.Drawing.Size(380, 85);
            this.richTextBox_Log.TabIndex = 8;
            this.richTextBox_Log.Text = "";
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(17, 25);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 23);
            this.btn_Clear.TabIndex = 10;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // txtReleaseTime
            // 
            this.txtReleaseTime.Location = new System.Drawing.Point(248, 40);
            this.txtReleaseTime.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.txtReleaseTime.Name = "txtReleaseTime";
            this.txtReleaseTime.Size = new System.Drawing.Size(46, 20);
            this.txtReleaseTime.TabIndex = 12;
            this.txtReleaseTime.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Release time";
            // 
            // comboBox_Button
            // 
            this.comboBox_Button.FormattingEnabled = true;
            this.comboBox_Button.Location = new System.Drawing.Point(6, 40);
            this.comboBox_Button.Name = "comboBox_Button";
            this.comboBox_Button.Size = new System.Drawing.Size(123, 21);
            this.comboBox_Button.TabIndex = 13;
            this.comboBox_Button.SelectedIndexChanged += new System.EventHandler(this.comboBox_Button_SelectedIndexChanged);
            // 
            // groupBox_Setting
            // 
            this.groupBox_Setting.Controls.Add(this.numericUpDown_LoopTime);
            this.groupBox_Setting.Controls.Add(this.comboBox_Button);
            this.groupBox_Setting.Controls.Add(this.label1);
            this.groupBox_Setting.Controls.Add(this.label5);
            this.groupBox_Setting.Controls.Add(this.label2);
            this.groupBox_Setting.Controls.Add(this.txtReleaseTime);
            this.groupBox_Setting.Controls.Add(this.txtTime);
            this.groupBox_Setting.Controls.Add(this.label4);
            this.groupBox_Setting.Location = new System.Drawing.Point(22, 81);
            this.groupBox_Setting.Name = "groupBox_Setting";
            this.groupBox_Setting.Size = new System.Drawing.Size(414, 77);
            this.groupBox_Setting.TabIndex = 15;
            this.groupBox_Setting.TabStop = false;
            this.groupBox_Setting.Text = "Setting";
            // 
            // numericUpDown_LoopTime
            // 
            this.numericUpDown_LoopTime.Enabled = false;
            this.numericUpDown_LoopTime.Location = new System.Drawing.Point(342, 40);
            this.numericUpDown_LoopTime.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numericUpDown_LoopTime.Name = "numericUpDown_LoopTime";
            this.numericUpDown_LoopTime.Size = new System.Drawing.Size(46, 20);
            this.numericUpDown_LoopTime.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(339, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Loop";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Location = new System.Drawing.Point(22, 350);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(414, 78);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(17, 19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(380, 40);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "";
            // 
            // groupBox_Logs
            // 
            this.groupBox_Logs.Controls.Add(this.richTextBox_Log);
            this.groupBox_Logs.Controls.Add(this.btn_Clear);
            this.groupBox_Logs.Location = new System.Drawing.Point(22, 164);
            this.groupBox_Logs.Name = "groupBox_Logs";
            this.groupBox_Logs.Size = new System.Drawing.Size(414, 180);
            this.groupBox_Logs.TabIndex = 17;
            this.groupBox_Logs.TabStop = false;
            this.groupBox_Logs.Text = "Log";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(462, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Image = global::Properties.Resources.menu;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Image = global::Properties.Resources.about;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 442);
            this.Controls.Add(this.groupBox_Logs);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox_Setting);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atuo Presser 1.0 - Nguyen Van Vuong 1510289";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReleaseTime)).EndInit();
            this.groupBox_Setting.ResumeLayout(false);
            this.groupBox_Setting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_LoopTime)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox_Logs.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        public void logToBox(string message)
        {
            this.richTextBox_Log.AppendText(DateTime.Now.ToString("h:mm:ss tt") + ": " + message + "\n");
            this.richTextBox_Log.ScrollToCaret();
        }

        public bool send_Code()
        {
            try
            {
                object selectedItem = this.comboBox_Button.SelectedItem;
                if (selectedItem == null)
                {
                    MessageBox.Show("Please select a button", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                Keys kCode = (Keys)Enum.Parse(typeof(Keys), selectedItem.ToString());
                Keyboard.KeyDown(kCode);
                Thread.Sleep(int.Parse(this.txtReleaseTime.Value.ToString()));
                Keyboard.KeyUp(kCode);
                this.logToBox("Sent key code " + selectedItem.ToString());
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.send_Code();
            this.logLength += 1;
            if (this.logLength == maxLogLeng)
            {
                logLength = 0;
                this.richTextBox_Log.Clear();
            }
        }

        public static class EnumUtil
        {
            public static IEnumerable<T> GetValues<T>()
            {
                return Enum.GetValues(typeof(T)).Cast<T>();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Are you sure ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (ret == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ref: https://www.codeproject.com/Articles/117657/InputManager-library-Track-user-input-and-simulate
            MessageBox.Show("-Author: 1510289 Nguyen Van Vuong\n" +
                "- Hotkey: Ctrl + F7\n" +
                "- Email: nguyenvanvuong972@gmail.com\n" +
                "- Thank for shynet-InputManager\n" +
                "-----------------\n" +
                "Note:\n" +
                "- The unit of time is milliseconds\n" +
                "- Loop =0 is infinity", "About", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}

