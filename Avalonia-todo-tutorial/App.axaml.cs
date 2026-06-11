using System.Linq;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Avalonia_todo_tutorial.ViewModels;
using Avalonia_todo_tutorial.Views;
using Avalonia_todo_tutorial.Services;

namespace Avalonia_todo_tutorial
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

       

        private readonly MainWindowViewModel _mainViewModel = new MainWindowViewModel();

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = _mainViewModel // Remember to change this line to use our private reference to the MainViewModel
                };

                // Listen to the ShutdownRequested-event
                desktop.ShutdownRequested += DesktopOnShutdownRequested;
            }

            base.OnFrameworkInitializationCompleted();


        }

        private bool _canClose;
        private async void DesktopOnShutdownRequested(object? sender, ShutdownRequestedEventArgs e)
        {
            e.Cancel = !_canClose; // Cancel the shutdown process if we haven't saved yet

            if (!_canClose)
            {
                var itemToSave = _mainViewModel.ToDoItems.Select(item => item.GetToDoItem());
                await ToDoListFileService.SaveToFileAsync(itemToSave);

                _canClose = true;
                if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                {
                    desktop.Shutdown(); // Now we can safely shutdown the application
                }
            }
        }
    }
}