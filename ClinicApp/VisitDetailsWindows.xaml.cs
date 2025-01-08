using System.Windows;
using ClinicApp.Models;

namespace ClinicApp
{
    public partial class VisitDetailWindow : Window
    {
        public VisitDetailWindow(Visit visit)
        {
            InitializeComponent();
            PopulateVisitDetails(visit);
        }

        private void PopulateVisitDetails(Visit visit)
        {
            // Присваиваем данные из визита в элементы управления
            VisitDateTextBlock.Text = visit.Date.ToString("dd.MM.yyyy");
            PatientTextBlock.Text = visit.Patient?.FullName ?? "Нет данных";
            DoctorTextBlock.Text = visit.Doctor?.FullName ?? "Нет данных";
            DiagnosisTextBlock.Text = visit.Diagnosis ?? "Нет данных";
            CommentsTextBlock.Text = visit.Comments ?? "Нет данных";

            // Присваиваем данные о лечении
            if (visit.Treatment != null)
            {
                TreatmentTextBlock.Text = $"Медикаменты: {string.Join(", ", visit.Treatment.Medications)}\n" +
                                          $"Процедуры: {string.Join(", ", visit.Treatment.Procedures)}\n" +
                                          $"Тесты: {string.Join(", ", visit.Treatment.Tests)}";
            }
            else
            {
                TreatmentTextBlock.Text = "Нет данных";
            }

            // Присваиваем данные о больничном
            SickLeaveTextBlock.Text = $"Начало больничного: {string.Join(", ", visit.SickLeave.StartDate)}\n" +
                                      $"Конец больничного: {string.Join(", ", visit.SickLeave.EndDate)}";
        }

    }
}
