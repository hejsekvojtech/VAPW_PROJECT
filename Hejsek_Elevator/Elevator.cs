using System;
using System.Threading;
using Hejsek_Elevator.Enums;

namespace Hejsek_Elevator
{
    public class Elevator : IDisposable
    {
        private const int FLOOR_TRANSITION_DELAY_MS = 1000;

        public int CurrentFloor { get; private set; }
        public int TargetFloor { get; private set; }
        public ElevatorState State { get; private set; }
        public DoorState Door { get; private set; }

        public event EventHandler<int> FloorChanged;
        public event EventHandler<ElevatorState> StateChanged;
        public event EventHandler<DoorState> DoorChanged;

        private bool _running;
        private Thread _elevatorThread;

        public Elevator()
        {
            CurrentFloor = 0;

            State = ElevatorState.Idle;
            Door = DoorState.Closed;

            _running = true;
            _elevatorThread = new Thread(MoveElevator);
            _elevatorThread.Start();
        }

        public void Dispose()
        {
            try
            {
                _running = false;
                _elevatorThread.Interrupt();
                _elevatorThread.Join();
            }
            catch (Exception)
            {

            }
        }

        public void GoToFloor(int floor)
        {
            // vytah je v pohybu nebo prave dorazil
            if (State != ElevatorState.Idle)
                return;

            // uz tam jsme
            if (floor == CurrentFloor)
            {
                // muzeme jak debilove furt dokola otevirat dvere
                State = ElevatorState.Arrived;
                StateChanged?.Invoke(this, State);
                return;
            }

            TargetFloor = floor;
            ElevatorState targetState = floor > CurrentFloor ? ElevatorState.MovingUp : ElevatorState.MovingDown;
            State = targetState;
            StateChanged?.Invoke(this, State);
          
        }

        private void MoveElevator()
        {
            while (_running)
            {
                try
                {
                    switch (State)
                    {
                        case ElevatorState.MovingUp:
                            CurrentFloor++;
                            FloorChanged?.Invoke(this, CurrentFloor);
                            Thread.Sleep(FLOOR_TRANSITION_DELAY_MS);
                            break;
                        case ElevatorState.MovingDown:
                            CurrentFloor--;
                            FloorChanged?.Invoke(this, CurrentFloor);
                            Thread.Sleep(FLOOR_TRANSITION_DELAY_MS);
                            break;
                        case ElevatorState.Arrived:
                            Door = DoorState.Open;
                            DoorChanged?.Invoke(this, Door);
                            Thread.Sleep(3000);
                            Door = DoorState.Closed;
                            DoorChanged?.Invoke(this, Door);
                            State = ElevatorState.Idle;
                            break;
                        default:
                            break;

                    }
                } catch (ThreadInterruptedException) { }

                if (State != ElevatorState.Idle && CurrentFloor == TargetFloor)
                {
                    State = ElevatorState.Arrived;
                }
            }
        }
    }
}