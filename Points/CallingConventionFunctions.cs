namespace Points;

public class CallingConventionFunctions
{
    public static int CallByValue(int value)
    {
        value = 9;
        return value;
    }
    
    public static int CallByReference(ref int value)
    {
        value = 9;
        return value;
    }
    
    public static Point2D CallByRefObj(Point2D point)
    {
        point.X = 9;
        point.Y = 9;
        return point;
    }
    public static Point2D CallByRefObj2(Point2D point)
    {
        point = new Point2D(9, 9);
        return point;
    }
    public static Point2D CallByRefObj3(ref Point2D point)
    {
        point = new Point2D(9, 9);
        return point;
    }
}