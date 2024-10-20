using Avalonia.Controls;
using Avalonia.Input;
using PeriodicTable.ViewModels;

namespace PeriodicTable.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();

        if (Design.IsDesignMode)
        {
            DataContext = new MainViewModel()
            {
                Elements = new System.Collections.ObjectModel.ObservableCollection<ElementViewItem>(ElementViewItem.Load())
            };
        }
    }

    void Panel_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (sender is Panel panel && panel.DataContext is ElementViewItem element)
        {
            if (DataContext is MainViewModel viewModel)
            {
                viewModel.SelectedElement = element;
            }
        }
    }
}