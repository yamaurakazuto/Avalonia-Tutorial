using Avalonia_todo_tutorial.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia_todo_tutorial.ViewModels
{
    public partial class ToDoItemViewModel : ViewModelBase
    {
        [ObservableProperty]
        private bool isChecked;

        [ObservableProperty]
        private string? content;

        public ToDoItemViewModel()
        { 

        }

        public ToDoItemViewModel(ToDoItem item)
        {
            IsChecked = item.IsChecked;
            Content = item.Content;
        }



        public ToDoItem GetToDoItem()
        {
            return new ToDoItem()
            {
                IsChecked = this.IsChecked,
                Content = this.Content
            };
        }
    }
}
