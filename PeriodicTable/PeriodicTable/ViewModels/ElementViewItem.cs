using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using Avalonia.Media;
using Avalonia.Platform;
using PeriodicTable.Models;

namespace PeriodicTable.ViewModels;

public class ElementViewItem
{
    public string AtomicNumber { get; set; }
    public string Symbol { get; set; }
    public string Name { get; set; }
    public string AtomicMass { get; set; }
    public string CPKHexColor { get; set; }
    public SolidColorBrush CPKColor => new (Color.Parse(CPKHexColor));
    public string ElectronConfiguration { get; set; }
    public string Electronegativity { get; set; }
    public string AtomicRadius { get; set; }
    public string IonizationEnergy { get; set; }
    public string ElectronAffinity { get; set; }
    public string OxidationStates { get; set; }
    public string StandardState { get; set; }
    public string MeltingPoint { get; set; }
    public string BoilingPoint { get; set; }
    public string Density { get; set; }
    public string GroupBlock { get; set; }
    public string YearDiscovered { get; set; }

    public int Row { get; set; }
    public int Column { get; set; }

    public static List<ElementViewItem> Load()
    {
        List<Element> elements = new List<Element>();

        using (var stream = AssetLoader.Open(new Uri("avares://PeriodicTable/Assets/elements.json")))
        {
            using (var document = JsonDocument.Parse(stream))
            {
                elements.AddRange(document.RootElement.GetProperty("elements").Deserialize<List<Element>>()!);
            }
        }

        return elements.Select(FromElement).ToList();
    }

    public static ElementViewItem FromElement(Element element)
    {
        return new()
        {
            Symbol = element.Symbol,
            Name = element.Name,
            AtomicNumber = element.AtomicNumber.ToString(),
            AtomicMass = element.AtomicMass.HasValue ? element.AtomicMass.Value.ToString(CultureInfo.InvariantCulture) : "",

            CPKHexColor = element.CPKHexColor,

            ElectronConfiguration = element.ElectronConfiguration,
            Electronegativity = element.Electronegativity.ToString() ?? "",

            AtomicRadius = element.AtomicRadius.ToString() ?? "",

            IonizationEnergy = element.IonizationEnergy.ToString() ?? "",
            ElectronAffinity = element.ElectronAffinity.ToString() ?? "",

            OxidationStates = element.OxidationStates,
            StandardState = element.StandardState,

            MeltingPoint = element.MeltingPoint.ToString() ?? "",
            BoilingPoint = element.BoilingPoint.ToString() ?? "",

            Density = element.Density?.ToString() ?? "",
            GroupBlock = element.GroupBlock,
            YearDiscovered = element.YearDiscovered,

            Column = element.GridPosition.Col - 1,
            Row = element.GridPosition.Row - 1
        };
    }
}