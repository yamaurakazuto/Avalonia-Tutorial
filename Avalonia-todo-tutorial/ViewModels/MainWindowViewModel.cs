using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace Avalonia_todo_tutorial.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddItemCommand))]
        public partial string? NewItemContent { get; set; }

        [RelayCommand (CanExecute = nameof(CanAddItem))]
        private void AddItem()
        {
            ToDoItems.Add(new ToDoItemViewModel()
            {
                Content = NewItemContent
            });

            NewItemContent = null;
        }

        [RelayCommand]
        private void RemoveItem(ToDoItemViewModel item)
        {
            ToDoItems.Remove(item);
        }


        private bool CanAddItem() => !string.IsNullOrWhiteSpace(NewItemContent);



        public ObservableCollection<ToDoItemViewModel> ToDoItems { get; } = new ObservableCollection<ToDoItemViewModel>();
    }
}
