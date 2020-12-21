using System;
using System.Windows;
using System.Windows.Threading;

namespace CloseTimerWindow
{
    /// <summary>
    /// AutoCloseWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class AutoCloseWindow : Window
    {
        private DispatcherTimer timer;


        public AutoCloseWindow()
        {
            InitializeComponent();

            var desktopWorkingArea = SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Right - this.Width;
            this.Top = desktopWorkingArea.Bottom - this.Height;
        }

        /// <summary>
        /// https://takap-tech.com/entry/2017/09/09/225342
        /// </summary>
        /// <param name="message"></param>
        public void Show(string message, int elapsedSecond)
        {
            this.Content.Text = message;
            this.Show();
            this.TimerText.Text = "0秒経過中";
            int num = 0;

            // タイマーの間隔(ミリ秒)
            this.timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(1000)
            };

            // 5秒以下なら最低5秒もたせる
            if(elapsedSecond < 5)
            {
                elapsedSecond = 5;
            }

            // タイマーの処理
            this.timer.Tick += (s, e) =>
            {
                if (num < elapsedSecond)
                {
                    num++;
                    this.TimerText.Text = num.ToString() + "秒経過中";
                }
                else
                {
                    this.TimerText.Text = "windowをcloseします";
                    this.timer.Stop();
                    this.Close();
                }
            };

            // タイマーを開始する
            timer.Start();
        }
    }
}
