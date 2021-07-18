namespace SPAM_TOOL
{
    using InputManager;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
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

        public Form1()
        {
            this.InitializeComponent();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chứ ?", "Cảnh b\x00e1o", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                this.richTextBox_Log.Clear();
            }
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
                }
                else
                {
                    this.timer.Enabled = false;
                    this.timer.Stop();
                    this.btnStart.Text = "Start";
                    this.groupBox_Setting.Enabled = true;
                    this.btn_Clear.Enabled = true;
                    this.logToBox("Stopped");
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

        public static void HandleKeyPress(byte keyName)
        {
            KeyBoard.keybd_event(keyName, 0, 0, 0);
            KeyBoard.keybd_event(keyName, 0, 2, 0);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.btnStart = new Button();
            this.label1 = new Label();
            this.label2 = new Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.txtTime = new NumericUpDown();
            this.richTextBox_Log = new RichTextBox();
            this.btn_Clear = new Button();
            this.txtReleaseTime = new NumericUpDown();
            this.label4 = new Label();
            this.comboBox_Button = new ComboBox();
            this.groupBox_Setting = new GroupBox();
            this.groupBox2 = new GroupBox();
            this.groupBox_Logs = new GroupBox();
            this.richTextBox1 = new RichTextBox();
            this.txtTime.BeginInit();
            this.txtReleaseTime.BeginInit();
            this.groupBox_Setting.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox_Logs.SuspendLayout();
            base.SuspendLayout();
            this.btnStart.Location = new Point(0x2b, 30);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new Size(0x19e, 0x25);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new EventHandler(this.btnStart_Click);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(3, 0x18);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Button (code)";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x98, 0x19);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x5f, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Time (mini second)";
            this.timer.Interval = 0x3e8;
            this.timer.Tick += new EventHandler(this.timer_Tick);
            this.txtTime.Location = new Point(0x9b, 0x29);
            int[] bits = new int[4];
            bits[0] = 0x3b9ac9ff;
            this.txtTime.Maximum = new decimal(bits);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new Size(0x5c, 20);
            this.txtTime.TabIndex = 7;
            int[] numArray2 = new int[4];
            numArray2[0] = 0x1f40;
            this.txtTime.Value = new decimal(numArray2);
            this.richTextBox_Log.Location = new Point(0x11, 0x36);
            this.richTextBox_Log.Name = "richTextBox_Log";
            this.richTextBox_Log.ReadOnly = true;
            this.richTextBox_Log.Size = new Size(380, 0x60);
            this.richTextBox_Log.TabIndex = 8;
            this.richTextBox_Log.Text = "";
            this.btn_Clear.Location = new Point(0x11, 0x19);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new Size(0x4b, 0x17);
            this.btn_Clear.TabIndex = 10;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new EventHandler(this.btn_Clear_Click);
            this.txtReleaseTime.Location = new Point(0x115, 40);
            int[] numArray3 = new int[4];
            numArray3[0] = 0x3b9ac9ff;
            this.txtReleaseTime.Maximum = new decimal(numArray3);
            this.txtReleaseTime.Name = "txtReleaseTime";
            this.txtReleaseTime.Size = new Size(0x5c, 20);
            this.txtReleaseTime.TabIndex = 12;
            int[] numArray4 = new int[4];
            numArray4[0] = 200;
            this.txtReleaseTime.Value = new decimal(numArray4);
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x112, 0x18);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x85, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Release time (mini second)";
            this.comboBox_Button.FormattingEnabled = true;
            this.comboBox_Button.Location = new Point(6, 40);
            this.comboBox_Button.Name = "comboBox_Button";
            this.comboBox_Button.Size = new Size(0x7b, 0x15);
            this.comboBox_Button.TabIndex = 13;
            this.comboBox_Button.SelectedIndexChanged += new EventHandler(this.comboBox_Button_SelectedIndexChanged);
            this.groupBox_Setting.Controls.Add(this.comboBox_Button);
            this.groupBox_Setting.Controls.Add(this.label1);
            this.groupBox_Setting.Controls.Add(this.label2);
            this.groupBox_Setting.Controls.Add(this.txtReleaseTime);
            this.groupBox_Setting.Controls.Add(this.txtTime);
            this.groupBox_Setting.Controls.Add(this.label4);
            this.groupBox_Setting.Location = new Point(0x2b, 0x55);
            this.groupBox_Setting.Name = "groupBox_Setting";
            this.groupBox_Setting.Size = new Size(0x19e, 0x48);
            this.groupBox_Setting.TabIndex = 15;
            this.groupBox_Setting.TabStop = false;
            this.groupBox_Setting.Text = "Setting";
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Location = new Point(0x2b, 0x16d);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x19e, 0x6d);
            this.groupBox2.TabIndex = 0x10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log";
            this.groupBox_Logs.Controls.Add(this.richTextBox_Log);
            this.groupBox_Logs.Controls.Add(this.btn_Clear);
            this.groupBox_Logs.Location = new Point(0x2b, 0xb3);
            this.groupBox_Logs.Name = "groupBox_Logs";
            this.groupBox_Logs.Size = new Size(0x19e, 180);
            this.groupBox_Logs.TabIndex = 0x11;
            this.groupBox_Logs.TabStop = false;
            this.groupBox_Logs.Text = "Log";
            this.richTextBox1.Location = new Point(0x11, 0x13);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new Size(380, 0x3a);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1f8, 0x200);
            base.Controls.Add(this.groupBox_Logs);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox_Setting);
            base.Controls.Add(this.btnStart);
            base.Name = "Form1";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Spam Tool - Nguyen Van Vuong 1510289";
            base.Load += new EventHandler(this.Form1_Load);
            this.txtTime.EndInit();
            this.txtReleaseTime.EndInit();
            this.groupBox_Setting.ResumeLayout(false);
            this.groupBox_Setting.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox_Logs.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://community.bistudio.com/wiki/DIK_KeyCodes");
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
                    MessageBox.Show("Vui l\x00f2ng chọn một ph\x00edm để spam", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                Keys kCode = (Keys) Enum.Parse(typeof(Keys), selectedItem.ToString());
                Keyboard.KeyDown(kCode);
                Thread.Sleep(int.Parse(this.txtReleaseTime.Value.ToString()));
                Keyboard.KeyUp(kCode);
                this.logToBox("Sent key code " + selectedItem.ToString());
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
        }

        public void Send_Key(short Keycode)
        {
            INPUT[] pInputs = new INPUT[1];
            pInputs[0].type = 1;
            pInputs[0].ki.wScan = Keycode;
            pInputs[0].ki.dwFlags = 8;
            pInputs[0].ki.time = 0;
            pInputs[0].ki.dwExtraInfo = IntPtr.Zero;
            SendInput(1, pInputs, Marshal.SizeOf(typeof(INPUT)));
            this.logToBox("Sent key code " + Keycode.ToString());
        }

        [DllImport("user32.dll")]
        private static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex=0, SizeConst=1)] INPUT[] pInputs, int cbSize);
        private void timer_Tick(object sender, EventArgs e)
        {
            this.send_Code();
        }

        public static class EnumUtil
        {
            public static IEnumerable<T> GetValues<T>()
            {
                return Enum.GetValues(typeof(T)).Cast<T>();
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct HARDWAREINPUT
        {
            public int uMsg;
            public short wParamL;
            public short wParamH;
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct INPUT
        {
            [FieldOffset(4)]
            public Form1.HARDWAREINPUT hi;
            [FieldOffset(4)]
            public Form1.KEYBDINPUT ki;
            [FieldOffset(4)]
            public Form1.MOUSEINPUT mi;
            [FieldOffset(0)]
            public int type;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct KEYBDINPUT
        {
            public short wVk;
            public short wScan;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }
    }
}

