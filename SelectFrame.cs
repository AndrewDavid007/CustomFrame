using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using CustomFrame.Properties;
using PaintDotNet.Effects;

namespace CustomFrame
{
    public class SelectFrame : EffectConfigDialog
    {
        private IContainer components;

        private ComboBox comboBox1;

        private Button button1;

        private Button button2;

        private GroupBox groupBox1;

        private ComboBox comboBox2;

        private TrackBar trackBar1;

        private string thepath;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            comboBox1 = new System.Windows.Forms.ComboBox();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            trackBar1 = new System.Windows.Forms.TrackBar();
            comboBox2 = new System.Windows.Forms.ComboBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(12, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(260, 21);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += new System.EventHandler(frameBox_SelectedIndexChanged);
            button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            button1.Location = new System.Drawing.Point(62, 147);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new System.EventHandler(button1_Click);
            button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            button2.Location = new System.Drawing.Point(143, 147);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += new System.EventHandler(button2_Click);
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.Controls.Add(trackBar1);
            groupBox1.Controls.Add(comboBox2);
            groupBox1.Location = new System.Drawing.Point(12, 39);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(260, 100);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Blending";
            trackBar1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            trackBar1.Location = new System.Drawing.Point(6, 46);
            trackBar1.Maximum = 255;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new System.Drawing.Size(248, 45);
            trackBar1.TabIndex = 1;
            trackBar1.TickFrequency = 255;
            trackBar1.Value = 255;
            trackBar1.Scroll += new System.EventHandler(opacitySlide_Scroll);
            comboBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[14]
            {
                "Normal", "Multiply", "Additive", "Colour Burn", "Colour Dodge", "Reflect", "Glow", "Overlay", "Difference", "Negation",
                "Lighten", "Darken", "Screen", "Xor"
            });
            comboBox2.Location = new System.Drawing.Point(6, 19);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new System.Drawing.Size(248, 21);
            comboBox2.TabIndex = 0;
            comboBox2.SelectedIndexChanged += new System.EventHandler(bmBox_SelectedIndexChanged);
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(284, 179);
            base.Controls.Add(groupBox1);
            base.Controls.Add(comboBox1);
            base.Controls.Add(button1);
            base.Controls.Add(button2);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.Location = new System.Drawing.Point(0, 0);
            base.Name = "SelectFrame";
            base.ShowIcon = false;
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Select a frame...";
            base.TopMost = true;
            base.Load += new System.EventHandler(SelectFrame_Load);
            base.Controls.SetChildIndex(button2, 0);
            base.Controls.SetChildIndex(button1, 0);
            base.Controls.SetChildIndex(comboBox1, 0);
            base.Controls.SetChildIndex(groupBox1, 0);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
        }

        public SelectFrame()
        {
            InitializeComponent();
        }

        private void SelectFrame_Load(object sender, EventArgs e)
        {
            thepath = Path.Combine(PdnInfo.UserDataPath, "Custom Frames");
            if (!Directory.Exists(thepath))
            {
                Directory.CreateDirectory(thepath);
                Resources.Lines.Save(Path.Combine(thepath, "Lines.png"));
                Resources.Simple.Save(Path.Combine(thepath, "Simple.png"));
            }
            comboBox1.Items.Add("Select a frame...");
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            DirectoryInfo directoryInfo = new DirectoryInfo(thepath);
            for (int i = 0; i < directoryInfo.GetFiles("*.png").Length; i++)
            {
                comboBox1.Items.Add(directoryInfo.GetFiles()[i].Name.Replace(".png", ""));
            }
            FinishTokenUpdate();
        }

        protected override void InitialInitToken()
        {
            theEffectToken = new FrameConfigToken();
        }

        protected override void InitTokenFromDialog()
        {
            FrameConfigToken frameConfigToken = (FrameConfigToken)theEffectToken;
            frameConfigToken.FrameIndex = comboBox1.SelectedIndex;
            frameConfigToken.BlendMode = comboBox2.SelectedIndex;
            frameConfigToken.Opacity = trackBar1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            FinishTokenUpdate();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FinishTokenUpdate();
        }

        private void bmBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FinishTokenUpdate();
        }

        private void opacitySlide_Scroll(object sender, EventArgs e)
        {
            FinishTokenUpdate();
        }
    }
}

