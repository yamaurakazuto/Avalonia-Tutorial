using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia_todo_tutorial.ViewModels
{
    public partial class ToDoItemViewModel : ViewModelBase
    {
        [ObservableProperty]
        public partial bool _isChecked;

        [ObservableProperty]
        public partial string? _content;

        public ToDoItemViewModel()
        { 

        }

        public ToDoItemViewModel(ToDoItemViewModel item)
        {
            _isChecked = item._isChecked;
            Content = item.Content;
        }
    }
}
