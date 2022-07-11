using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PhoneBook
{
    /// <summary>
    /// Логика взаимодействия для ChangeContact.xaml
    /// </summary>
    public partial class ChangeContact : Window
    {
        public ChangeContact()
        {
            InitializeComponent();
            RedactorViewModel redactorViewModel = new RedactorViewModel();
            DataContext = redactorViewModel;
            if (redactorViewModel.CloseAction == null)
                redactorViewModel.CloseAction = new Action(Close);
        }
    }
}
