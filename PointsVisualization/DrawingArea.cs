using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using Brushes = Avalonia.Media.Brushes;
using Pen = Avalonia.Media.Pen;
using Point = Avalonia.Point;

namespace PointsVisualization;

public class DrawingArea : Control
{
    private List<Point2D> points = new List<Point2D>();
    public IBrush? Background { get; set; } = Brushes.White;

    public void addPoints(List<Point2D> points)
    {
        this.points = points;
    }
    
    public sealed override void Render(DrawingContext context)
    {
        var renderSize = Bounds.Size;
        context.FillRectangle(Background, new Rect(renderSize));
        
        int half_width= (int)(Bounds.Width / 2);
        int half_height = (int)Bounds.Height / 2;
        context.DrawLine(new Pen(Brushes.Gray), new Point(0, half_height), new Point(Bounds.Width, half_height));
        context.DrawLine(new Pen(Brushes.Gray), new Point(half_width, 0), new Point(half_width, Bounds.Height));

        for (var count = 0; count < points.Count - 1 ; count++)
        {
            var p1 = new Point(points[count].X * half_width + half_width, points[count].Y * half_width + half_width);
            var p2 = new Point(points[count + 1].X * half_height + half_height, points[count + 1].Y * half_height + half_height);
            
            context.DrawEllipse(Brushes.Black, new Pen(Brushes.Red),p1, 2, 2);
            context.DrawText(new FormattedText($"{count}", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, 
                new Typeface(FontFamily.Default), 12, Brushes.Black), p1);
        }
    }
}