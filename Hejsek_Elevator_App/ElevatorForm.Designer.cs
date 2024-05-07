namespace Hejsek_Elevator_App
{
    partial class ElevatorForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElevatorForm));
            elevatorControls = new TableLayoutPanel();
            label1 = new Label();
            btnCall = new Button();
            floorSelectorPanel = new TableLayoutPanel();
            labelCallerFloor = new Label();
            labelElevatorPanel = new Label();
            floorNumber = new Label();
            pictureBox1 = new PictureBox();
            elevatorControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // elevatorControls
            // 
            elevatorControls.BackColor = SystemColors.ControlDark;
            elevatorControls.ColumnCount = 2;
            elevatorControls.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            elevatorControls.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            elevatorControls.Controls.Add(label1, 0, 0);
            elevatorControls.Location = new Point(255, 70);
            elevatorControls.Name = "elevatorControls";
            elevatorControls.RowCount = 2;
            elevatorControls.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            elevatorControls.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            elevatorControls.Size = new Size(200, 306);
            elevatorControls.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlLight;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 0;
            label1.Text = "Bourák a syn";
            // 
            // btnCall
            // 
            btnCall.Location = new Point(495, 188);
            btnCall.Name = "btnCall";
            btnCall.Size = new Size(75, 75);
            btnCall.TabIndex = 1;
            btnCall.Text = "Zavolat";
            btnCall.UseVisualStyleBackColor = true;
            btnCall.Click += btnCall_Click;
            // 
            // floorSelectorPanel
            // 
            floorSelectorPanel.ColumnCount = 2;
            floorSelectorPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            floorSelectorPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            floorSelectorPanel.Location = new Point(576, 70);
            floorSelectorPanel.Name = "floorSelectorPanel";
            floorSelectorPanel.RowCount = 2;
            floorSelectorPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            floorSelectorPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            floorSelectorPanel.Size = new Size(200, 306);
            floorSelectorPanel.TabIndex = 2;
            // 
            // labelCallerFloor
            // 
            labelCallerFloor.AutoSize = true;
            labelCallerFloor.Location = new Point(576, 52);
            labelCallerFloor.Name = "labelCallerFloor";
            labelCallerFloor.Size = new Size(197, 15);
            labelCallerFloor.TabIndex = 3;
            labelCallerFloor.Text = "Pokročilý soused simulátor";
            // 
            // labelElevatorPanel
            // 
            labelElevatorPanel.AutoSize = true;
            labelElevatorPanel.Location = new Point(255, 52);
            labelElevatorPanel.Name = "labelElevatorPanel";
            labelElevatorPanel.Size = new Size(75, 15);
            labelElevatorPanel.TabIndex = 4;
            labelElevatorPanel.Text = "Panel vytahu";
            // 
            // floorNumber
            // 
            floorNumber.Anchor = AnchorStyles.None;
            floorNumber.AutoSize = true;
            floorNumber.BackColor = Color.FromArgb(129, 127, 128);
            floorNumber.Font = new Font("Nirmala UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            floorNumber.ForeColor = Color.OrangeRed;
            floorNumber.Location = new Point(108, 80);
            floorNumber.Margin = new Padding(3, 12, 3, 0);
            floorNumber.Name = "floorNumber";
            floorNumber.Size = new Size(21, 15);
            floorNumber.TabIndex = 5;
            floorNumber.Text = "69";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(23, 70);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(192, 306);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // ElevatorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 430);
            Controls.Add(floorNumber);
            Controls.Add(pictureBox1);
            Controls.Add(labelElevatorPanel);
            Controls.Add(labelCallerFloor);
            Controls.Add(floorSelectorPanel);
            Controls.Add(btnCall);
            Controls.Add(elevatorControls);
            Name = "ElevatorForm";
            Text = "Form1";
            FormClosed += ElevatorForm_FormClosed;
            elevatorControls.ResumeLayout(false);
            elevatorControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel elevatorControls;
        private Button btnCall;
        private TableLayoutPanel floorSelectorPanel;
        private Label labelCallerFloor;
        private Label labelElevatorPanel;
        private Label floorNumber;
        private Label label1;
        private PictureBox pictureBox1;
    }
}
