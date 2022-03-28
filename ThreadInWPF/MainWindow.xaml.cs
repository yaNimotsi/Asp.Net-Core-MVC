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
        private static double _sliderValue;
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

                Thread.Sleep((int)_sliderValue);

                oldSummand = fibonachiNumber;
                fibonachiNumber += summand;
                summand = oldSummand;

            }
        }

        private void MySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _sliderValue = MySlider.Value * 10;
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                SliderTextBlock.Text = _sliderValue.ToString();
            }));
        }
    }
}

/*
 * Если я правильно понял, то в задании 1.3 требуется описать
 * метод Abort и ошибку которою он вызывает (ThreadAbortException). 
 * Но данный метод не поддерживается. А метод Interapt немного не 
 * подходит под описание в заднии, как мне кажется.
 * */
