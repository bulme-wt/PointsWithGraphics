global using Points;
using System;
using System.Collections.Generic;

using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;

namespace PointsVisualization;

public partial class MainWindow : Window
{
    
    List<Point2D> points = new List<Point2D>();
    private int numPoints = 1;
    public MainWindow()
    {
        InitializeComponent();
        numPoints = (int)numPointsSlider.Value;
    }
    private void fillRandomly(List<Point2D> point_2ds)
    {
        Random rnd = new Random();

        for (int i = 0; i < numPoints; i++)
        { 
            Point2D point = new Point2D(2.0*rnd.NextDouble()-1.0, 2.0*rnd.NextDouble()-1.0);
            point_2ds.Add(point);
        }
    }
    
    private void DrawRandom_OnClickwRandom_OnClick(object? sender, RoutedEventArgs e)
    {
        points.Clear();
        fillRandomly(points);

        drawingArea.addPoints(points);
        drawingArea.InvalidateVisual();
    }

    private void SortButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Point2D.sortPoints(points);
        drawingArea.InvalidateVisual();
    }

    private void NumPointsSlider_OnValueChanged(object? sender, RangeBaseValueChangedEventArgs e)
    {
        numPoints = (int)e.NewValue;
    }

    private void Kjh_OnClick(object? sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }
}