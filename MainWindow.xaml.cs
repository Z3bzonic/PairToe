using PairToe.Common.Enum;
using PairToe.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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

namespace PairToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainViewModel vm { get; private set; } = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
            Gridke.DataContext = vm;
        }

        public State state { get; set; } = State.O;

        public string[] gameBoard = new string[9];

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            currentplayer.Content = state.ToString();
            Button b = sender as Button;
            b.Content = state.ToString();
            b.IsEnabled = false;
            SwitchState();
            int tilenumber;
            bool tile = int.TryParse(Regex.Replace(b.Name, "[^0-9]+", string.Empty), out tilenumber);
            gameBoard[tilenumber - 1] = state.ToString();
        }

        private void CheckWin(int tile)
        {
        }

        private void SwitchState()
        {
            if (state == State.O)
            {
                state = State.X;
            }
            else
            {
                state = State.O;
            }
        }
    }
}