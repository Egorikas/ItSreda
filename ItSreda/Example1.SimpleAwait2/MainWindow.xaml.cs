using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Example1.SimpleAwait2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            //ReadFileSync();
            await ReadFileAsync();
        }

        private void ReadFileSync()
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

        private async Task ReadFileAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(15));
        }
    }
}
