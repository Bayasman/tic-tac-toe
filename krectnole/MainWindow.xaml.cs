using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace krectnole
{

    public partial class MainWindow : Window
    {
        private string value = "X";
        private int xwins = 0;
        private int owins = 0;
        private static readonly Brush DEFAULTBRUSH = new SolidColorBrush(Color.FromArgb(255, 142, 142, 166));

        public MainWindow()
        {
            InitializeComponent();
        }

        private void restart_Click(object sender, RoutedEventArgs e)
        {
            ResetButtons();
            xwins = 0;  
            owins = 0;
            IBXWins.Content = "X:O";
            IBОWins.Content = "0:O";

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" эти крестики ноликию.\n были сделаны Баясманом\n  Date: 08.02.2023", "krectnole ", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void bt_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            bt.Foreground = Brushes.Black;
            bt.IsEnabled = false;
         
            if (IsWin(btA1, btA2, btA3)) GameOver(btA1.Content.ToString());
            if (IsWin(btB1, btB2, btB3)) GameOver(btB1.Content.ToString());
            if (IsWin(btC1, btC2, btC3)) GameOver(btC1.Content.ToString());
            if (IsWin(btA1, btB1, btC1)) GameOver(btA1.Content.ToString());
            if (IsWin(btA2, btB2, btC2)) GameOver(btA2.Content.ToString());
            if (IsWin(btA3, btB2, btC3)) GameOver(btA3.Content.ToString());
            if (IsWin(btA1, btB2, btC3)) GameOver(btA1.Content.ToString());
            if (IsWin(btA3, btB2, btC1)) GameOver(btA3.Content.ToString());

            if (!btA1.IsEnabled && !btA2.IsEnabled && !btA3.IsEnabled &&
                !btB1.IsEnabled && !btB2.IsEnabled && !btB3.IsEnabled &&
                !btC1.IsEnabled && !btC2.IsEnabled && !btC3.IsEnabled)
                GameOver("");

            value = value == "X" ? "O" : "X";
        }

        private void GameOver(string who)
        {
            if (IBWinner.Visibility == Visibility.Visible) return;
            if (who == "X")
            {
                IBWinner.Content = "игрок x выйград!";
                IBXWins.Content = $"X: {++xwins}";
            }
            else if (who == "O")
            {
                IBWinner.Content = "игрок O выйград!";
                IBОWins.Content = $"O: {++xwins}";
            }
            else IBWinner.Content = "не выйграл";
            IBWinner.Visibility = Visibility.Visible;
            Wait1SecAndRestart();

        }

        private async void Wait1SecAndRestart()
        {
            await Task.Delay(1000);
            IBWinner.Visibility = Visibility.Hidden;
            ResetButtons();

        }

        private void ResetButtons()
        {
            ResetButton(btA1);
            ResetButton(btA2);
            ResetButton(btA3);
            ResetButton(btB1);
            ResetButton(btB2);
            ResetButton(btB3);
            ResetButton(btC1);
            ResetButton(btC2);
            ResetButton(btC3);

        }

        private void ResetButton(Button bt)
        {
            bt.Content = "";
            bt.IsEnabled=true;
            bt.Foreground= DEFAULTBRUSH;
        }
        private bool IsWin(Button bt1, Button bt2, Button bt3 ) =>
            !bt1.IsEnabled && bt1.Content== bt2.Content && bt1.Content == bt3.Content;

        private void bt_Enter(object sender, MouseEventArgs e)
        {
            Button bt = (Button)sender;
            bt.Content=value;

        }

        private void bt_Leave(object sender, MouseEventArgs e)
        {
            Button bt = (Button)sender;
            if (bt.IsEnabled)
                bt.Content = "";
        }

        private void Link_Click(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments= "/c start www.youtube.com/watch?v=jAlFV34LtXk&ab_channel=Re%3A2D",
                CreateNoWindow=true,
                WindowStyle = ProcessWindowStyle.Hidden,

            });
        }
    }
}
