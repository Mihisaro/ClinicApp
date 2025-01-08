using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ClinicApp.Models;

namespace ClinicApp
{
    public partial class AddVisitWindow : Window
    {
        private List<Visit> _visits;
        private List<Doctor> _doctors;
        private List<Patient> _patients;

        public AddVisitWindow(List<Visit> visits, List<Doctor> doctors, List<Patient> patients)
        {
            InitializeComponent();
            _visits = visits;
            _doctors = doctors;
            _patients = patients;


            // Заполняем ComboBox врачами
            DoctorComboBox.ItemsSource = _doctors;
            DoctorComboBox.DisplayMemberPath = "FullName";
            DoctorComboBox.SelectedIndex = 0; // Выбираем первого врача по умолчанию

            // Заполняем ComboBox пациентами
            PatientsComboBox.ItemsSource = _patients;
            PatientsComboBox.DisplayMemberPath = "FullName";
            PatientsComboBox.SelectedIndex = 0; // Выбираем первого пациента по умолчанию



        }

        private void AddVisit_Click(object sender, RoutedEventArgs e)
        {
            if (!_doctors.Any() || !_patients.Any())
            {
                MessageBox.Show("Добавьте хотя бы одного врача и пациента перед добавлением приема.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var selectedDoctor = DoctorComboBox.SelectedItem as Doctor;
            var selectedPatient = PatientsComboBox.SelectedItem as Patient;

            // Создаем новый прием
            var newVisit = new Visit
            {
                Date = VisitDatePicker.SelectedDate ?? DateTime.Now,
                Doctor = selectedDoctor,
                Patient = selectedPatient,
                Diagnosis = DiagnosisTextBox.Text,
                Comments = CommentsTextBox.Text,
                Treatment = new Treatment
                {
                    Medications = new List<string>(MedicationsTextBox.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)),
                    Procedures = new List<string>(ProceduresTextBox.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)),
                    Tests = new List<string>(TestsTextBox.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                },
                SickLeave = new SickLeave
                {
                    StartDate = SickLeaveStartDatePicker.SelectedDate ?? DateTime.Now,
                    EndDate = SickLeaveEndDatePicker.SelectedDate ?? DateTime.Now.AddDays(7)
                }
            };

            // Добавляем прием в список
            _visits.Add(newVisit);

            // Закрытие окна после добавления
            MessageBox.Show("Прием успешно добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
