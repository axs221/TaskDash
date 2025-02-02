﻿using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using TaskDash.Core.Models.Tasks;
using TaskDash.CustomControls.Dialogs;
using TaskDash.ViewModels;

namespace TaskDash.UserControls.Tasks
{
    public class TaskDetailsViewModel : ViewModelBase<TaskDetailsViewModel>
    {
        private TaskDetailsView _view;

        public TaskDetailsViewModel(TaskDetailsView view, ITaskList taskList)
        {
            _view = view;

            taskList.SelectedTaskChanged += OnSelectedTaskChanged;

            _view.ListBoxLogs.SelectionChanged += OnSelectedLogChanged;
        }

        private void OnSelectedLogChanged(object sender, SelectionChangedEventArgs e)
        {
            //TODO: We should be able to use data binding in XAML instead
        }

        internal void RefreshItems()
        {
            if (SelectedTask == null) return;

            Task task = SelectedTask;

            var view = (ListCollectionView)task.FilteredItems.View;

            // Search
            view.Refresh();

            //SelectFirstTask();
        }


        public void OnSelectedTaskChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems == null || e.AddedItems.Count == 0) return;

            Task task = (Task)e.AddedItems[0];
            SelectedTask = task;
        }


        public Task SelectedTask
        {
            get { return (Task)GetValue(SelectedTaskProperty); }
            set { SetValue(SelectedTaskProperty, value); }
        }

        public static readonly DependencyProperty SelectedTaskProperty =
            DependencyProperty.Register("SelectedTask", typeof(Task), typeof(TaskDetailsViewModel), new UIPropertyMetadata(null));


        public Log SelectedLog
        {
            get { return (Log)GetValue(SelectedLogProperty); }
            set { SetValue(SelectedLogProperty, value); }
        }

        public static readonly DependencyProperty SelectedLogProperty =
            DependencyProperty.Register("SelectedLog", typeof(Log), typeof(TaskDetailsViewModel), new UIPropertyMetadata(null));

        
        private void RefreshLogs()
        {
            if (SelectedTask == null) return;

            Task task = SelectedTask;
            if (task == null) return;


            var view = (ListCollectionView)task.FilteredLogs.View;

            // Search
            view.Refresh();
        }

        public void OpenIssueTracker()
        {
            Process.Start("http://devjira/browse/" + SelectedTask.Key);
        }

        internal void FindInIssueTracker()
        {
            const string OR = "+OR+";
            const string LIKE = "+~+";
            const string options = "&reset=true&tempMax=10";


            string page = @"http://devjira/secure/IssueNavigator.jspa?reset=true&jqlQuery=";
            string[] queryWords = SelectedTask.Description.Split(' ');
            string jqlQueryTerms = @"'" + String.Join("+", queryWords) + @"'";

            // I found out the syntax to this by doing a search, then doing Views -> Full Content. URL has querystrings
            // E.g. http://devjira-prod/secure/IssueNavigator.jspa?reset=true&jqlQuery=summary+~+"test+this+out"+OR+description+~+"test+this+out"+OR+comment+~+"test+this+out"+OR+environment+~+"test+this+out"&tempMax=1000&tempMax=1000
            string jqlQuery =
                "summary" + LIKE + jqlQueryTerms
                + OR + "description" + LIKE + jqlQueryTerms
                //+ OR + "comment" + LIKE + jqlQueryTerms       // This is SLOW
                ;


            string queryUrl = page + jqlQuery + options;
            Process.Start(queryUrl);
        }

        public void ShowEditTaskItemDialog()
        {
            Task task = SelectedTask;
            var listBox = _view.listBoxItems;
            var item = (TaskItem)listBox.SelectedItem;

            var editTaskItem = new EditTaskItem(task.FilteredItems.View, item);
            editTaskItem.Show();
        }
    }
}
