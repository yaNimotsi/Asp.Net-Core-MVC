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
using System.Windows.Threading;

namespace ThreadInWPF
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Run();
        }

        private void Run()
        {
            var threadFibonachi = new Thread(TextBlockUpdateInThread)
            {
                Name = "TextBlockTextUpdateThread"
            };
            threadFibonachi.Start();
        }

        private void TextBlockUpdateInThread()
        {
            var fibonachiNumber = 0;
            var summand = 1;
            var oldSummand = fibonachiNumber;

            while(fibonachiNumber >= 0)
            {
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                {
                    MyTextBlock.Text = fibonachiNumber.ToString();
                }));

                Thread.Sleep(500);

                oldSummand = fibonachiNumber;
                fibonachiNumber += summand;
                summand = oldSummand;

            }
        }
    }
}
