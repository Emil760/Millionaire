using Millioner.Models;
using Millioner.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Millioner.ViewModels
{
    class AdminViewModel : ObserableObject
    {
        private delegate void SaveOption(Task task);

        private SaveOption save_opthion;

        private ObservableCollection<Task> questions;
        private ObservableCollection<int> complexities;
        private Task selected_question;
        private int selected_complexity;

        private bool complexity_is_enabled;
        private bool questions_is_enabled;

        private string question;
        private string answer1;
        private string answer2;
        private string answer3;
        private string answer4;

        private bool question_is_enabled;
        private bool answer1_is_enabled;
        private bool answer2_is_enabled;
        private bool answer3_is_enabled;
        private bool answer4_is_enabled;

        private bool add_is_enabled;
        private bool remove_is_enabled;
        private bool update_is_enabled;
        private bool save_is_enabled;
        private bool cancel_is_enabled;

        public AdminViewModel()
        {
            AddCommand = new Command(Add);
            UpdateCommand = new Command(Update);
            RemoveCommand = new Command(Remove);
            SaveCommand = new Command(Save);
            CancelCommand = new Command(Cancel);
            QuestionChangedCommnad = new Command(QuestionChanged);
            ComplexityChangedCommand = new Command(ComplexityChanged);

            Questions = new ObservableCollection<Task>();
            Complexities = new ObservableCollection<int>();
            foreach (var item in Task.GetAllComplexities())
                Complexities.Add(item);

            AddIsEnabled = true;
            ComplexityIsEnabled = true;
            QuestionsIsEnabled = true;
        }

        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand QuestionChangedCommnad { get; }
        public ICommand ComplexityChangedCommand { get; }

        public ObservableCollection<Task> Questions { get => questions; set => questions = value; }
        public ObservableCollection<int> Complexities { get => complexities; set => complexities = value; }
        public Task SelectedQuestion { get => selected_question; set => Set(ref selected_question, value); }
        public int SelectedComplexity { get => selected_complexity; set => Set(ref selected_complexity, value); }

        public bool ComplexityIsEnabled { get => complexity_is_enabled; set => Set(ref complexity_is_enabled, value); }
        public bool QuestionsIsEnabled { get => questions_is_enabled; set => Set(ref questions_is_enabled, value); }

        public string Question { get => question; set => Set(ref question, value); }
        public string Answer1 { get => answer1; set => Set(ref answer1, value); }
        public string Answer2 { get => answer2; set => Set(ref answer2, value); }
        public string Answer3 { get => answer3; set => Set(ref answer3, value); }
        public string Answer4 { get => answer4; set => Set(ref answer4, value); }

        public bool QuestionIsEnabled { get => question_is_enabled; set => Set(ref question_is_enabled, value); }
        public bool Answer1IsEnabled { get => answer1_is_enabled; set => Set(ref answer1_is_enabled, value); }
        public bool Answer2IsEnabled { get => answer2_is_enabled; set => Set(ref answer2_is_enabled, value); }
        public bool Answer3IsEnabled { get => answer3_is_enabled; set => Set(ref answer3_is_enabled, value); }
        public bool Answer4IsEnabled { get => answer4_is_enabled; set => Set(ref answer4_is_enabled, value); }

        public bool AddIsEnabled { get => add_is_enabled; set => Set(ref add_is_enabled, value); }
        public bool UpdateIsEnabled { get => update_is_enabled; set => Set(ref update_is_enabled, value); }
        public bool RemoveIsEnabled { get => remove_is_enabled; set => Set(ref remove_is_enabled, value); }
        public bool SaveIsEnabled { get => save_is_enabled; set => Set(ref save_is_enabled, value); }
        public bool CancelIsEnabled { get => cancel_is_enabled; set => Set(ref cancel_is_enabled, value); }

        public void Add(object param)
        {
            if (SelectedComplexity <= 0)
            {
                MessageBox.Show("complexity was not selected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            save_opthion = new SaveOption(SaveAdd);

            ComplexityIsEnabled = false;
            QuestionsIsEnabled = false;

            RemoveIsEnabled = false;
            UpdateIsEnabled = false;
            SaveIsEnabled = true;
            CancelIsEnabled = true;

            Question = null;
            Answer1 = null;
            Answer2 = null;
            Answer3 = null;
            Answer4 = null;

            QuestionIsEnabled = true;
            Answer1IsEnabled = true;
            Answer2IsEnabled = true;
            Answer3IsEnabled = true;
            Answer4IsEnabled = true;
        }

        public void Remove(object param)
        {
            if (SelectedQuestion != null)
            {
                Task.RemoveById(SelectedComplexity, SelectedQuestion.Id);
                Questions.Remove(SelectedQuestion);
                SelectedQuestion = null;
                Question = null;
                Answer1 = null;
                Answer2 = null;
                Answer3 = null;
                Answer4 = null;
            }
        }

        public void Update(object param)
        {
            save_opthion = new SaveOption(SaveUpdate);

            QuestionsIsEnabled = false;
            ComplexityIsEnabled = false;

            QuestionIsEnabled = true;
            Answer1IsEnabled = true;
            Answer2IsEnabled = true;
            Answer3IsEnabled = true;
            Answer4IsEnabled = true;

            AddIsEnabled = false;
            RemoveIsEnabled = false;
            SaveIsEnabled = true;
            CancelIsEnabled = true;
        }

        public void Save(object param)
        {
            if (String.IsNullOrWhiteSpace(Question) || String.IsNullOrWhiteSpace(Answer1) || String.IsNullOrWhiteSpace(Answer2) || String.IsNullOrWhiteSpace(Answer3) || String.IsNullOrWhiteSpace(Answer4))
            {
                MessageBox.Show("All fields must be entered", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                save_opthion.Invoke(new Task(Question, Answer1, Answer2, Answer3, Answer4));

                QuestionIsEnabled = false;
                Answer1IsEnabled = false;
                Answer2IsEnabled = false;
                Answer3IsEnabled = false;
                Answer4IsEnabled = false;

                AddIsEnabled = true;
                RemoveIsEnabled = true;
                UpdateIsEnabled = true;
                SaveIsEnabled = false;
                CancelIsEnabled = false;

                ComplexityIsEnabled = true;
                QuestionsIsEnabled = true;
            }
        }

        private void SaveAdd(Task task)
        {
            Task.Save(SelectedComplexity, task);
            Questions.Add(task);
            SelectedQuestion = task;
        }

        private void SaveUpdate(Task task)
        {
            Task.Update(SelectedComplexity, SelectedQuestion.Id, task);
            SelectedQuestion.Question = task.Question;
            SelectedQuestion.Answer1 = task.Answer1;
            SelectedQuestion.Answer2 = task.Answer2;
            SelectedQuestion.Answer3 = task.Answer3;
            SelectedQuestion.Answer4 = task.Answer4;
        }

        public void Cancel(object param)
        {
            if (SelectedQuestion != null)
            {
                Question = SelectedQuestion.Question;
                Answer1 = SelectedQuestion.Answer1;
                Answer2 = SelectedQuestion.Answer2;
                Answer3 = SelectedQuestion.Answer3;
                Answer4 = SelectedQuestion.Answer4;
            }
            else
            {
                Question = null;
                Answer1 = null;
                Answer2 = null;
                Answer3 = null;
                Answer4 = null;
            }
            ComplexityIsEnabled = true;
            QuestionsIsEnabled = true;

            AddIsEnabled = true;
            SaveIsEnabled = false;
            CancelIsEnabled = false;

            QuestionIsEnabled = false;
            Answer1IsEnabled = false;
            Answer2IsEnabled = false;
            Answer3IsEnabled = false;
            Answer4IsEnabled = false;
        }

        public void QuestionChanged(object param)
        {
            if (SelectedQuestion != null)
            {
                Question = SelectedQuestion.Question;
                Answer1 = SelectedQuestion.Answer1;
                Answer2 = SelectedQuestion.Answer2;
                Answer3 = SelectedQuestion.Answer3;
                Answer4 = SelectedQuestion.Answer4;
                RemoveIsEnabled = true;
                UpdateIsEnabled = true;
            }
        }

        public void ComplexityChanged(object param)
        {
            Questions.Clear();
            foreach (var item in Task.GetAllQuestions(SelectedComplexity))
                Questions.Add(item);

            RemoveIsEnabled = false;
            UpdateIsEnabled = false;

            Question = null;
            Answer1 = null;
            Answer2 = null;
            Answer3 = null;
            Answer4 = null;
        }
    }
}
