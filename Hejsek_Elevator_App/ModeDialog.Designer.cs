namespace Hejsek_Elevator_App
{
    partial class ModeDialog
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
            groupBox1 = new GroupBox();
            rbPolling = new RadioButton();
            rbEventBased = new RadioButton();
            btnSaveMode = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbPolling);
            groupBox1.Controls.Add(rbEventBased);
            groupBox1.Location = new Point(16, 11);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(222, 79);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Connection Mode";
            // 
            // rbPolling
            // 
            rbPolling.AutoSize = true;
            rbPolling.Location = new Point(13, 52);
            rbPolling.Name = "rbPolling";
            rbPolling.Size = new Size(96, 19);
            rbPolling.TabIndex = 1;
            rbPolling.TabStop = true;
            rbPolling.Text = "Polling Based";
            rbPolling.UseVisualStyleBackColor = true;
            // 
            // rbEventBased
            // 
            rbEventBased.AutoSize = true;
            rbEventBased.Location = new Point(13, 27);
            rbEventBased.Name = "rbEventBased";
            rbEventBased.Size = new Size(88, 19);
            rbEventBased.TabIndex = 0;
            rbEventBased.TabStop = true;
            rbEventBased.Text = "Event Based";
            rbEventBased.UseVisualStyleBackColor = true;
            // 
            // btnSaveMode
            // 
            btnSaveMode.Location = new Point(16, 96);
            btnSaveMode.Name = "btnSaveMode";
            btnSaveMode.Size = new Size(222, 23);
            btnSaveMode.TabIndex = 1;
            btnSaveMode.Text = "Save mode";
            btnSaveMode.UseVisualStyleBackColor = true;
            btnSaveMode.Click += btnSaveMode_Click;
            // 
            // ModeDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(259, 132);
            Controls.Add(btnSaveMode);
            Controls.Add(groupBox1);
            Name = "ModeDialog";
            Text = "ModeDialog";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton rbPolling;
        private RadioButton rbEventBased;
        private Button btnSaveMode;
    }
}