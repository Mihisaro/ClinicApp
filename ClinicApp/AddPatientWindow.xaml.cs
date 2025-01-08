using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ClinicApp.Models;

namespace ClinicApp
{
    public partial class AddPatientWindow : Window
    {
        private List<Patient> _patients; // Список пациентов

        public AddPatientWindow(List<Patient> patients)
        {
            InitializeComponent();
            _patients = patients;
        }

        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {
            // Получаем данные пациента
            var newPatient = new Patient
            {
                CardNumber = CardNumberTextBox.Text,
                FullName = FullNameTextBox.Text,
                Address = AddressTextBox.Text,
                Gender = GenderTextBox.Text,
                BirthYear = BirthYearTextBox.Text,
                IsPensioner = IsPensionerCheckBox.IsChecked ?? false,
                InsurancePolicyNumber = InsurancePolicyNumberTextBox.Text,
                Benefits = new List<string>(BenefitsTextBox.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            };

            // Создаем новый визит
            var newVisit = new Visit
            {
                Date = VisitDatePicker.SelectedDate ?? DateTime.Now,
                Diagnosis = DiagnosisTextBox.Text,
                Comments = CommentsTextBox.Text,
                Doctor = null, 
                Treatment = null, 
                SickLeave = null 
            };

            newPatient.Visits.Add(newVisit);

            // Добавляем пациента в список
            _patients.Add(newPatient);

            // Закрытие окна после добавления
            MessageBox.Show("Пациент успешно добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
