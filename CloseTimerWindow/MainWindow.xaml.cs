using System;
using System.Windows;
using System.Windows.Threading;

namespace CloseTimerWindow
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            // タイマーの間隔(ミリ秒)
            // 10秒定期
            // UI処理なのでDispatcherTimerである必要がある
            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(10000)
            };

            // タイマーの処理
            timer.Tick += (sender, e) =>
            {
                var cw = new AutoCloseWindow();
                cw.Show("10秒定期に作成されるwindowです。\n15秒後消えます", 15);
            };

            // タイマーを開始する
            timer.Start();
        }

        private void top_Click(object sender, RoutedEventArgs e)
        {
            var cw = new AutoCloseWindow();
            cw.Show(this.top.Content.ToString(), 5);
        }

        private void bottom_Click(object sender, RoutedEventArgs e)
        {
            var cw = new AutoCloseWindow();
            cw.Show(this.bottom.Content.ToString(), 5);
        }
    }
}
