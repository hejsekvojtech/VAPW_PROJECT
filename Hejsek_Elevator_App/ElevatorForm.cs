using Hejsek_Elevator;
using Hejsek_Elevator.Enums;
using Hejsek_Elevator_App.Enums;
using Hejsek_Elevator_App.Properties;
using PollingTimer = System.Windows.Forms.Timer;

namespace Hejsek_Elevator_App
{
    public partial class ElevatorForm : Form
    {
        private ConnectionMode connectionMode;
        private Elevator elevator;
        private PollingTimer timerPolling;
        private Button lastFloorBtn;

        private const int FLOOR_NUMBER = 12;
        private int callerFloor;

        public ElevatorForm()
        {
            InitializeComponent();
            InitializeElevator();
            InitializeConnectionMode();

            PopulateElevatorControls(FLOOR_NUMBER);
            PopulateFloorSelector(FLOOR_NUMBER);

            lastFloorBtn = new Button();
            callerFloor = elevator?.CurrentFloor ?? 0;
        }

        private void InitializeElevator()
        {
            elevator = new Elevator();
            elevator.FloorChanged += Elevator_FloorChanged;
            elevator.DoorChanged += Elevator_DoorChanged;
            floorNumber.Text = elevator.CurrentFloor.ToString();
        }


        private void InitializeConnectionMode()
        {
            var dialog = new ModeDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                connectionMode = dialog.SelectedMode;
                SwitchConnectionMode(connectionMode);
            }
            else
            {
                connectionMode = ConnectionMode.EventBased;
                SwitchConnectionMode(connectionMode);
            }

            Text = $"VAPW Elevator | running in {
                connectionMode switch
                {
                    ConnectionMode.EventBased => "event-based",
                    ConnectionMode.Polling => "polling"
                }
            } mode";
        }

        private void SwitchConnectionMode(ConnectionMode mode)
        {
            if (mode == ConnectionMode.EventBased)
            {
                elevator.FloorChanged += Elevator_FloorChanged;
                elevator.DoorChanged += Elevator_DoorChanged;

                if (timerPolling != null)
                {
                    timerPolling.Stop();
                    timerPolling.Dispose();
                    timerPolling = null;
                }
            }
            else if (mode == ConnectionMode.Polling)
            {
                elevator.FloorChanged -= Elevator_FloorChanged;
                elevator.DoorChanged -= Elevator_DoorChanged;

                timerPolling = new PollingTimer();
                timerPolling.Interval = 200;
                timerPolling.Tick += TimerPolling_Tick;
                timerPolling.Start();
            }
        }

        private void Elevator_FloorChanged(object sender, int floor)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    floorNumber.Text = elevator.CurrentFloor.ToString();
                }));
            }
            catch (Exception) { }

        }

        private void Elevator_DoorChanged(object sender, DoorState state)
        {
            if (state == DoorState.Open)
            {
                lastFloorBtn.BackColor = SystemColors.ControlDark;
                pictureBox1.Image = Resources.elevator_open;
            }
            else
            {
                pictureBox1.Image = Resources.elevator_closed;
            }
        }

        private void TimerPolling_Tick(object sender, EventArgs e)
        { 
            Invoke(new Action(() =>
            {
                floorNumber.Text = elevator.CurrentFloor.ToString();

                if (elevator.State == ElevatorState.Idle)
                {
                    timerPolling.Stop();
                }

                if (elevator.Door == DoorState.Open)
                {
                    lastFloorBtn.BackColor = SystemColors.ControlDark;
                    pictureBox1.Image = Resources.elevator_open;
                }
                else
                {
                    pictureBox1.Image = Resources.elevator_closed;
                }
            }));
        }


        private void FloorBtnClick(object sender, EventArgs e)
        {
            if (elevator.State != ElevatorState.Idle)
            {
                MessageBox.Show("Nelze měnit cílové patro v pohybu\nVyčkejte až se výtah zastaví a dveře se otevřou");
                return;
            }

            if (lastFloorBtn != null)
                lastFloorBtn.BackColor = SystemColors.ControlDark;

            Button clickedButton = sender as Button;
            clickedButton.BackColor = Color.LightBlue;
            lastFloorBtn = clickedButton;

            StartTimer();
            elevator.GoToFloor(int.Parse(clickedButton.Text));
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            if (elevator.State != ElevatorState.Idle)
            {
                MessageBox.Show("Výtah právě používá někdo jiný");
                return;
            }

            StartTimer();
            elevator.GoToFloor(callerFloor);
        }

        private void PopulateFloorSelector(int n)
        {
            int rows = (int)Math.Ceiling((double)n / 2);
            int count = 0;

            floorSelectorPanel.RowCount = rows;
            floorSelectorPanel.ColumnCount = 2;

            for (int i = 0; i < rows; i++)
            {
                floorSelectorPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            }

            for (int i = 0; i < 2; i++)
            {
                floorSelectorPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            }

            for (int i = rows; i >= 0; i--)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (count < n)
                    {
                        int floor_num = count - 1;

                        RadioButton rb = new RadioButton();
                        rb.Text = floor_num.ToString();
                        rb.Dock = DockStyle.Fill;
                        rb.Margin = new Padding(5);
                        rb.Click += (sender, e) => callerFloor = floor_num;
                        floorSelectorPanel.Controls.Add(rb, j, i);

                        if (floor_num == callerFloor)
                        {
                            rb.Checked = true;
                        }

                        count++;
                    }
                }
            }
        }

        private void PopulateElevatorControls(int n)
        {
            int rows = (int)Math.Ceiling((double)n / 2);
            int count = 0;

            elevatorControls.RowCount = rows;
            elevatorControls.ColumnCount = 2;

            for (int i = 0; i < rows; i++)
            {
                elevatorControls.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            }

            for (int i = 0; i < 2; i++)
            {
                elevatorControls.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            }

            for (int i = rows; i >= 0; i--)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (count < n)
                    {
                        Button btn = new Button();
                        btn.Text = (count - 1).ToString();
                        btn.Dock = DockStyle.Fill;
                        btn.Margin = new Padding(5);
                        btn.Click += FloorBtnClick;
                        elevatorControls.Controls.Add(btn, j, i);

                        count++;
                    }
                }
            }
        }

        private void StartTimer()
        {
            if (connectionMode == ConnectionMode.Polling)
                timerPolling.Start();
        }

        private void ElevatorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (timerPolling != null)
                {
                    timerPolling.Stop();
                    timerPolling.Dispose();
                    timerPolling = null;
                }

                Invoke(new Action(() =>
                {
                    elevator?.Dispose();
                }));
            }
            catch (Exception)
            {
            }
        }
    }
}
