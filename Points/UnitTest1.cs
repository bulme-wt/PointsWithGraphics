using System.Collections;
using System.Diagnostics;
using Xunit.Abstractions;

namespace Points;

public class UnitTest1
{
    private readonly ITestOutputHelper _testOutputHelper;
    private const long NUM_ELEMENTS = 1000;
    
    
    private void fillRandomly(List<Point2D> point_2ds)
    {
        Random rnd = new Random();

        for (int i = 0; i < NUM_ELEMENTS; i++)
        { 
            Point2D point = new Point2D(rnd.NextDouble(), rnd.NextDouble());
            point_2ds.Add(point);
        }
    }
    
    public UnitTest1(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void TestConstructor()
    {
        Point2D point = new Point2D(1, 2);
        Assert.Equal(1, point.X);
        Assert.Equal(2, point.Y);
    }
    [Fact]
    public void TestConstructor2()
    {
        Point2D point = new Point2D(-3.14, 2.29);
        Assert.Equal(-3.14, point.X);
        Assert.Equal(2.29, point.Y);
    }
    
    [Fact]
    public void TestDistance()
    {
        Point2D point1 = new Point2D(0, 0);
        Point2D point2 = new Point2D(3, 4);
        Assert.Equal(5, point1.CalculateDistance(point2));
    }
    
    [Fact]
    public void TestDistance2()
    {
        Point2D point1 = new Point2D(234, -516);
        Point2D point2 = new Point2D(237, -512);
        Assert.Equal(5, point1.CalculateDistance(point2));
    }
        
    [Fact]
    public void TestDistance3()
    {
        Point2D point1 = new Point2D(234, -516);
        Point2D point2 = new Point2D(234, -512);
        Assert.Equal(4, point1.CalculateDistance(point2));
    }
    
            
    [Fact]
    public void TestDistance4()
    {
        Point2D point1 = new Point2D(234, -516);
        Point2D point2 = new Point2D(214, -516);
        Assert.Equal(20, point1.CalculateDistance(point2));
    }
    
    [Fact]
    public void TestDistance5()
    {
        Point2D point1 = new Point2D(234, -516);
        Point2D point2 = new Point2D(234, -516);
        Assert.Equal(0, point1.CalculateDistance(point2));
    }
    
    [Fact]
    public void TestDistance6()
    {
        Point2D point1 = new Point2D(0, 0);
        Point2D point2 = new Point2D(2.3, -4.9);
        Assert.InRange( point1.CalculateDistance(point2), 5.4129, 5.4130);
    }

    [Fact]
    public void TestFillArrayList()
    {
        ArrayList points = new ArrayList();
        Random rnd = new Random();
        var stopwatch = new Stopwatch();
        
        stopwatch.Start();
        for (int i = 0; i < NUM_ELEMENTS; i++)
        { 
            Point2D point = new Point2D(rnd.NextDouble(), rnd.NextDouble());
            points.Add(point);
        }
        
        stopwatch.Stop();
        var elapsed_time = stopwatch.ElapsedMilliseconds;

        Assert.Equal( NUM_ELEMENTS, points.Count);
        
        _testOutputHelper.WriteLine("Elapsed time duration: " + elapsed_time);
    }
    
    [Fact]
    public void TestFillList()
    {
        List<Point2D> points = new List<Point2D>();
        Random rnd = new Random();
        
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 0; i < NUM_ELEMENTS; i++)
        { 
            Point2D point = new Point2D(rnd.NextDouble(), rnd.NextDouble());
            points.Add(point);
        }
        stopwatch.Stop();
        var elapsed_time = stopwatch.ElapsedMilliseconds;

        Assert.Equal( NUM_ELEMENTS, points.Count);
        
        _testOutputHelper.WriteLine("Elapsed time: " + elapsed_time);
    }
    
    [Fact]
    public void TestFillLinkedList()
    {
        LinkedList<Point2D> points = new LinkedList<Point2D>();
        Random rnd = new Random();
        
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 0; i < NUM_ELEMENTS; i++)
        { 
            Point2D point = new Point2D(rnd.NextDouble(), rnd.NextDouble());
            points.AddLast(point);
        }
        stopwatch.Stop();
        var elapsed_time = stopwatch.ElapsedMilliseconds;

        Assert.Equal( NUM_ELEMENTS, points.Count);
        
        _testOutputHelper.WriteLine("Elapsed time: " + elapsed_time);
    }


    [Fact]
    public void TestFindNearestPoint()
    {
        List<Point2D> points = new List<Point2D>();
        Random rnd = new Random();
        
        for (int i = 0; i < NUM_ELEMENTS; i++)
        { 
            Point2D point = new Point2D(rnd.NextDouble(), rnd.NextDouble());
            points.Add(point);
        }
        Point2D pointOfInterest = new Point2D(rnd.NextDouble(), rnd.NextDouble());

        var nearest = pointOfInterest.findNearest(points);
        
        Assert.False(nearest == null);
        Assert.IsType<Point2D>(nearest);
        
        double smallestDistance = pointOfInterest.CalculateDistance(nearest);
        foreach (Point2D point in points)
        {
            Assert.True(pointOfInterest.CalculateDistance(point) >= smallestDistance);
        }
    }


    [Fact]
    public void TestSortPoints()
    {
        List<Point2D> points = new List<Point2D>();
        fillRandomly(points);

        Point2D.sortPoints(points);
        
        // test if most distant point is last element in list
        var greatest_distance = points[points.Count-1].CalculateDistanceFromOrigin();
        for (var i = 0; i < points.Count - 1; i++)
        {
            Assert.True(points[i].CalculateDistanceFromOrigin() < greatest_distance);
        }

        for (var i = 0; i < points.Count - 1; i++)
        {
            Assert.True(false);
        }
    }
}