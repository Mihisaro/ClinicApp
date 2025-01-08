using System.Linq;
using System.Windows;
using ClinicApp.Models;

namespace ClinicApp
{
    public partial class PatientDetailsWindow : Window
    {
        public PatientDetailsWindow(Patient patient)
        {
            InitializeComponent();

            // Проверяем, есть ли визиты и назначаем контекст данных
            if (patient.Visits != null && patient.Visits.Count > 0)
            {
                // Получаем последний визит
                var lastVisit = patient.Visits.Last();

                // Создаём анонимный объект для привязки данных в окне
                this.DataContext = new
                {
                    patient.CardNumber,
                    patient.FullName,
                    patient.Address,
                    patient.Gender,
                    patient.BirthYear,
                    patient.IsPensioner,
                    patient.InsurancePolicyNumber,
                    patient.Benefits,
                    LastVisit = new
                    {
                        VisitDate = lastVisit.Date,
                        Diagnosis = lastVisit.Diagnosis,
                        Comments = lastVisit.Comments
                    }
                };
            }
            else
            {
                // Если визитов нет, просто передаем те данные, что есть
                this.DataContext = patient;
            }
        }
    }
}
