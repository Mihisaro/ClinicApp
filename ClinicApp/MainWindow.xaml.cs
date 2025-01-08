using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;
using System.Windows;
using ClinicApp.Models;
using System.Windows.Input;

namespace ClinicApp
{
    public partial class MainWindow : Window
    {
        private List<Doctor> _doctors = new List<Doctor>();
        private List<Patient> _patients = new List<Patient>();
        private List<Visit> _visits = new List<Visit>();

        private const string DoctorsFilePath = "doctors.json";
        private const string PatientsFilePath = "patients.json";
        private const string VisitsFilePath = "visits.json";

        public MainWindow()
        {
            InitializeComponent();
        }

        // Врачи
        private void AddDoctor_Click(object sender, RoutedEventArgs e)
        {
            var addDoctorWindow = new AddDoctorWindow(_doctors);
            addDoctorWindow.ShowDialog();
            UpdateDoctorsList();
        }
        
        private void UpdateDoctorsList()
        {
            DoctorsListBox.ItemsSource = null;
            DoctorsListBox.ItemsSource = _doctors;
        }

        private void DeleteDoctor_Click(object sender, RoutedEventArgs e)
        {
            if (DoctorsListBox.SelectedItem is Doctor selectedDoctor)
            {
                _doctors.Remove(selectedDoctor);
                UpdateDoctorsList();
            }
            else
            {
                MessageBox.Show("Выберите врача для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveDoctors_Click(object sender, RoutedEventArgs e)
        {
            JsonHelper.SaveToFile<Doctor>(DoctorsFilePath, _doctors);
            MessageBox.Show("Список врачей сохранен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void LoadDoctors_Click(object sender, RoutedEventArgs e)
        {
            _doctors = JsonHelper.LoadFromFile<Doctor>(DoctorsFilePath);
            DoctorsListBox.ItemsSource = _doctors;

            if (_doctors.Any())
            {
                DoctorsListBox.SelectedIndex = 0;
            }
        }

        private void DoctorsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DoctorsListBox.SelectedItem is Doctor selectedDoctor)
            {
                UpdateSchedulesList(selectedDoctor);
            }
        }

        private void UpdateSchedulesList(Doctor doctor)
        {
            if (doctor == null)
            {
                SchedulesListBox.ItemsSource = null;
                return;
            }
            SchedulesListBox.ItemsSource = doctor.Schedules;
        }

        // Пациенты
        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {
            var addPatientWindow = new AddPatientWindow(_patients);
            addPatientWindow.ShowDialog();
            UpdatePatientsList();
        }

        private void UpdatePatientsList()
        {
            PatientsListBox.ItemsSource = null;
            PatientsListBox.ItemsSource = _patients;
        }

        private void DeletePatient_Click(object sender, RoutedEventArgs e)
        {
            if (PatientsListBox.SelectedItem is Patient selectedPatient)
            {
                _patients.Remove(selectedPatient);
                UpdatePatientsList();
            }
            else
            {
                MessageBox.Show("Выберите пациента для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SavePatients_Click(object sender, RoutedEventArgs e)
        {
            JsonHelper.SaveToFile(PatientsFilePath, _patients);
            MessageBox.Show("Список пациентов сохранен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void LoadPatients_Click(object sender, RoutedEventArgs e)
        {
            _patients = JsonHelper.LoadFromFile<Patient>(PatientsFilePath);
            UpdatePatientsList();
        }

        // Приемы
        private void AddVisit_Click(object sender, RoutedEventArgs e)
        {
            if (!_doctors.Any() || !_patients.Any())
            {
                MessageBox.Show("Добавьте хотя бы одного врача и пациента перед добавлением приема.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var addVisitWindow = new AddVisitWindow(_visits, _doctors, _patients);
            addVisitWindow.ShowDialog(); // Ждем, пока окно не будет закрыто

            UpdateVisitsList();
        }

        private void DeleteVisit_Click(object sender, RoutedEventArgs e)
        {
            if (VisitsListBox.SelectedItem is Visit selectedVisit)
            {
                _visits.Remove(selectedVisit);
                UpdateVisitsList();
            }
            else
            {
                MessageBox.Show("Выберите прием для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveVisits_Click(object sender, RoutedEventArgs e)
        {
            JsonHelper.SaveToFile(VisitsFilePath, _visits);
            MessageBox.Show("Список приемов сохранен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void LoadVisits_Click(object sender, RoutedEventArgs e)
        {
            _visits = JsonHelper.LoadFromFile<Visit>(VisitsFilePath);
            UpdateVisitsList();
        }

        private void UpdateVisitsList()
        {
            VisitsListBox.ItemsSource = null;
            VisitsListBox.ItemsSource = _visits;
        }

        private void SchedulesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void DoctorsListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (DoctorsListBox.SelectedItem is Doctor selectedDoctor)
            {
                var doctorDetailsWindow = new DoctorDetailsWindow(selectedDoctor);
                doctorDetailsWindow.ShowDialog(); // Теперь покажет все данные о враче, включая его расписание
            }
        }
        private void PatientsListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (PatientsListBox.SelectedItem is Patient selectedPatient)
            {
                var patientDetailsWindow = new PatientDetailsWindow(selectedPatient);
                patientDetailsWindow.ShowDialog(); // Показывает окно с информацией о пациенте
            }
            else
            {
                MessageBox.Show("Выберите пациента для просмотра.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void VisitsListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (VisitsListBox.SelectedItem is Visit selectedVisit)
            {
                VisitDetailWindow detailWindow = new VisitDetailWindow(selectedVisit);
                detailWindow.ShowDialog(); // Используем ShowDialog для открытия окна
            }
        }
        private void VisitsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }




    }

}
