namespace Points;

public class Point2D
{
    // Properties to store the coordinates
    public double X { get; set; }
    public double Y { get; set; }

    // Constructor to initialize the point with specific coordinates
    public Point2D(double x, double y)
    {
        X = x;
        Y = y;
    }

    // Method to calculate the distance from origin
    public double CalculateDistanceFromOrigin()
    {
        return Math.Sqrt(X * X + Y * Y);
    }
    
    // Method to calculate the distance between two points
    public double CalculateDistance(Point2D otherPoint)
    {
        double deltaX = X - otherPoint.X;
        double deltaY = Y - otherPoint.Y;
        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }

public string getColor()
    {
        Point2D ursprung = new Point2D(0, 0);
        var dist = CalculateDistance(ursprung);
        if (dist < 1)
        {
            return "blue";
        }

        if (X <= 1 && X >= -1 && Y <= 1 && Y >= -1)
        {
            return "red";
        }
        
        return "white";
    }

    public static List<Point2D> getRedPoints(List<Point2D> points)
    {
        List<Point2D> reds = new List<Point2D>();

        return reds;
    }
    public Point2D? findNearest(List<Point2D> points)
    {
        if (points.Count == 0)
            return null;
        
        Point2D? nearest = null;
        var smallestDistance = double.PositiveInfinity;
        foreach (var point in points)
        {
            var distance = CalculateDistance(point);
            if (distance < smallestDistance)
            {
                smallestDistance = distance;
                nearest = point;
            }
        }

        return nearest;
    }

    public List<Point2D> findAllPointsWithinRadius(List<Point2D> points, double radius)
    {
        List<Point2D> result = new List<Point2D>();
        foreach (var point in points)
        {
            if (CalculateDistance(point) <= radius)
            {
                result.Add(point);
            }
        }

        return result;
        
    }
    
    public static (Point2D?, Point2D?) findClosestTuple(List<Point2D> points)
    {
        Point2D? point1 = null;
        Point2D? point2 = null;
        var smallestDistance = double.PositiveInfinity;
        
        foreach (var p1 in points)
        {
            foreach (var p2 in points)
            {
                if (p1 == p2)
                {
                    continue;
                }
                
                var distance = p1.CalculateDistance(p2);
                if (distance < smallestDistance)
                {
                    smallestDistance = distance;
                    point1 = p1;
                    point2 = p2;
                }   
            }
        }
        
        return (point1, point2);
    }
    
    public static (Point2D?, Point2D?) findClosestTuple2(List<Point2D> points)
    {
        Point2D? point1 = null;
        Point2D? point2 = null;
        var smallestDistance = double.PositiveInfinity;
        
        for(int i1 = 0; i1 < points.Count; i1++)
        {
            var p1 = points[i1];
            for(int i2 = i1 + 1; i2 < points.Count; i2++)
            {
                var p2 = points[i2];   
                var distance = p1.CalculateDistance(p2);
                if (distance < smallestDistance)
                {
                    smallestDistance = distance;
                    point1 = p1;
                    point2 = p2;
                }   
            }
        }
        
        return (point1, point2);
    }

    public static List<Point2D> sortPoints(List<Point2D> points)
    {
        for (var count = 0; count < points.Count() - 1 ; count++) 
        {
            for (int i = 0; i < points.Count() - 1; i++)
            {
                if (points[i].CalculateDistanceFromOrigin() > points[i + 1].CalculateDistanceFromOrigin())
                {
                    var temp = points[i + 1];
                    points[i + 1] = points[i];
                    points[i] = temp;
                }
            }
        }

        return points;
    }
}