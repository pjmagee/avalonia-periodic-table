using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PeriodicTable.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public ObservableCollection<ElementViewItem> Elements { get; set; } = new();


    private ElementViewItem? _selectedElement;

    public ElementViewItem? SelectedElement
    {
        get => _selectedElement;
        set => SetProperty(ref _selectedElement, value);
    }
}