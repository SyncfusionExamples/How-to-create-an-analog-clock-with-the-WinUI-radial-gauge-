using Microsoft.UI.Xaml;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace AnalogClock
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        public MainWindow()
        {
            this.InitializeComponent();

            this.secondsPointer.Value = DateTime.Now.Second * .2;
            this.minutesPointer.Value = (DateTime.Now.Minute * .2) + (this.secondsPointer.Value / 60);
            this.hoursPointer.Value = (DateTime.Now.Hour > 12 ? DateTime.Now.Hour - 12 : DateTime.Now.Hour) + DateTime.Now.Minute / 60.0;

            timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 0, 1000)
            };
            timer.Tick += Timer_Tick;

            this.secondsPointer.EnableAnimation = true;
            this.timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            this.secondsPointer.Value += 0.2;
            this.minutesPointer.Value = this.minutesPointer.Value + (0.2 / 60);
            this.hoursPointer.Value = DateTime.Now.Hour % 12 + DateTime.Now.Minute / 60.0;
            if (this.secondsPointer.Value >= 12)
            {
                this.secondsPointer.EnableAnimation = false;
                this.secondsPointer.Value = 0.2;
                this.secondsPointer.EnableAnimation = true;
            }

            if (this.minutesPointer.Value >= 12)
            {
                this.minutesPointer.Value = 0.2 / 60;
            }

            if (this.hoursPointer.Value >= 12)
            {
                this.hoursPointer.Value = 0.2 / 3600;
            }
        }
    }
}
