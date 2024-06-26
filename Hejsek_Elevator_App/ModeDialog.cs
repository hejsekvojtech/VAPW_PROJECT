﻿using Hejsek_Elevator_App.Enums;

namespace Hejsek_Elevator_App
{
    public partial class ModeDialog : Form
    {
        public ConnectionMode SelectedMode { get; set; }

        public ModeDialog()
        {
            InitializeComponent();
        }

        private void btnSaveMode_Click(object sender, EventArgs e)
        {
            if (rbEventBased.Checked)
                SelectedMode = ConnectionMode.EventBased;
            else if (rbPolling.Checked)
                SelectedMode = ConnectionMode.Polling;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
