using ClinicApp.Models;
using System.Windows;

namespace ClinicApp
{
    public partial class DoctorDetailsWindow : Window
    {
        public DoctorDetailsWindow(Doctor doctor)
        {
            InitializeComponent();
            DataContext = doctor; // Привязка данных к окну
        }
    }
}
