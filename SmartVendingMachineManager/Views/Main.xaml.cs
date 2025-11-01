using System.Windows;
using SmartVendingMachineManager.ViewModel;

namespace SmartVendingMachineManager.Views
{
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }
    }

}