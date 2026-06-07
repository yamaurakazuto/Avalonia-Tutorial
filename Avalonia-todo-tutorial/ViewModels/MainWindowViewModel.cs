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
            ToDoItems.Add(new TODoItemViewModel()
            {
                Content = NewItemContent
            });

            NewItemContent = null;
        }

        [RelayCommand]
        private void RemoveItem(TodoItemViewModel item)
        {
            ToDoItems.Remove(item);
        }


        private bool CanAddItem() => !string.IsNullOrWhiteSpace(NewItemContent);



        public ObservableCollection<ToDoItemViewModel> ToDoItems { get; } = new ObservableCollection<ToDoItemViewModel>();
    }
}
