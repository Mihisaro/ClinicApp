using System;
using System.Collections.Generic;
using System.Windows;
using ClinicApp.Models;

namespace ClinicApp
{
    public partial class AddDoctorWindow : Window
    {
        private List<Doctor> _doctors; // Список врачей

        public AddDoctorWindow(List<Doctor> doctors)
        {
            InitializeComponent();
            _doctors = doctors;
        }

        private void AddDoctor_Click(object sender, RoutedEventArgs e)
        {
            // Получаем данные о враче
            var newDoctor = new Doctor
            {
                FullName = FullNameTextBox.Text,
                BirthYear = BirthYearTextBox.Text,
                Specialization = SpecializationTextBox.Text,
                Education = EducationTextBox.Text,
                University = UniversityTextBox.Text,
                GraduationYear = int.TryParse(GraduationYearTextBox.Text, out int graduationYear) ? graduationYear : 0,
                Experience = int.TryParse(ExperienceTextBox.Text, out int experience) ? experience : 0,
                PhoneNumber = PhoneNumberTextBox.Text,
                PhotoPath = PhotoPathTextBox.Text,
                Schedules = new List<Schedule>()
            };

            // Добавление расписания
            var schedule = new Schedule
            {
                DayOfWeek = ScheduleDayTextBox.Text,
                StartTime = TimeSpan.TryParse(ScheduleStartTimeTextBox.Text, out TimeSpan startTime) ? startTime : TimeSpan.Zero,
                EndTime = TimeSpan.TryParse(ScheduleEndTimeTextBox.Text, out TimeSpan endTime) ? endTime : TimeSpan.Zero,
                Room = ScheduleRoomTextBox.Text
            };

            // Добавляем расписание к врачу
            newDoctor.Schedules.Add(schedule);

            // Добавляем врача в список
            _doctors.Add(newDoctor);

            // Закрытие окна после добавления
            MessageBox.Show("Врач успешно добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void EducationTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void GraduationYearTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
