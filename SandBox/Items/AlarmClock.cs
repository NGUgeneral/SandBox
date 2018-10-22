using System;
using System.Threading.Tasks;
using System.Timers;

namespace SandBox.Items
{
    class AlarmClock : IDisposable
    {
        Timer MyTimer = new Timer();
        private readonly int Interval;
        private readonly string Name;
        private event Action CustomAlarmEvent;
        private event Action CancelAlarmEvent; 

        public AlarmClock()
        {
            CustomAlarmEvent += CustomAlarmHandler;
            CancelAlarmEvent += CancelAlarmHandler;

            Console.Write("Please enter the alarm name: ");
            Name = Console.ReadLine();
            Console.Write("Please enter the alarm interval: ");
            var i = 0;
            int.TryParse(Console.ReadLine(), out i);
            Interval = i;
            Console.WriteLine($"Alarm {Name} has been configured for {Interval} seconds");

            Console.WriteLine("Press any key to start the alarm");
            Console.ReadKey();
        }

        private void CancelAlarmHandler()
        {
            var cancel = false;

            Console.WriteLine("To cancel the alarm press S ...");
            ConsoleKeyInfo key = Console.ReadKey();
            while (key.Key != ConsoleKey.S)
            {
                key = Console.ReadKey();
            }

            Console.WriteLine($"Alarm {Name} has been canceled.");
            MyTimer.Stop();
        }

        private void CustomAlarmHandler()
        {
            Console.WriteLine($"Alarm {Name} has been set.");
        }

        public void StartAlarm()
        {
            MyTimer.Elapsed += (o, e) => AlarmMessage();
            MyTimer.Elapsed += (o, e) => MyTimer.Stop();
            MyTimer.Interval = Interval * 1000;
            MyTimer.Enabled = true;
            MyTimer.Start();
            CustomAlarmEvent?.Invoke();
            CancelAlarmEvent?.Invoke();
        }

        private void AlarmMessage()
        {
            Console.WriteLine($"Receiving alarm from {Name}\n-- BEEP --\n-- BEEP --\n-- BEEP --");
            CustomAlarmEvent -= CustomAlarmHandler;
            CancelAlarmEvent -= CancelAlarmHandler;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
