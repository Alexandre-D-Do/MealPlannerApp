using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
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

namespace MealPlannerApp.View.UserControls
{
    /// <summary>
    /// Interaction logic for ClearableTextBox.xaml
    /// </summary>
    public partial class ClearableTextBox : UserControl, INotifyPropertyChanged
    {
        public ClearableTextBox()
        {
            DataContext = this;
            InitializeComponent();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private string placeHolder;

        public string PlaceHolder
        {
            get { return placeHolder; }
            set
            {
                placeHolder = value;
                OnPropertyChanged();
            }
        }



        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            textInputBox.Clear();
            textInputBox.Focus();

        }

        private void TextInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(textInputBox.Text))
            {
                placeHolderText.Visibility = Visibility.Visible;
            }
            else
            {
                placeHolderText.Visibility = Visibility.Hidden;
            }



        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
