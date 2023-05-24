using System;

public class Box
{
    public double Height { get; set; }
    public double Width { get; set; }
    public double Length { get; set; }
    public enum BoxType { SmallBox, MediumBox, LargeBox }
    public BoxType Type { get; set; }

    public Box() { }

    public Box(double height, double width, double length)
    {
        Height = height;
        Width = width;
        Length = length;
        double volume = GetVolume();
        if (volume <= 5) Type = BoxType.SmallBox;
        else if (volume > 5 && volume <= 10) Type = BoxType.MediumBox;
        else Type = BoxType.LargeBox;
    }

    public override string ToString()
    {
        return $"Box type: {Type}, Height: {Height}, Width: {Width}, Length: {Length}";
    }

    public double GetVolume()
    {
        return Height * Width * Length;
    }

    public static Box operator +(Box box1, Box box2)
    {
        double newHeight = Math.Sqrt(Math.Pow(box1.Height, 2) + Math.Pow(box2.Height, 2)) * 0.43;
        double newWidth = Math.Sqrt(Math.Pow(box1.Width, 2) + Math.Pow(box2.Width, 2)) * 0.85;
        double newLength = Math.Sqrt(Math.Pow(box1.Length, 2) + Math.Pow(box2.Length, 2)) * 0.19;
        Box newBox = new Box(newHeight, newWidth, newLength);
        return newBox;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Box smallBox = new Box(1, 1, 1);
        Box mediumBox = new Box(2, 2, 1.5);
        Box largeBox = new Box(3, 4, 2);

        Box box1 = new Box(1, 2, 3);
        Box box2 = new Box(2, 3, 4);
        Box newBox = box1 + box2;

        Console.WriteLine(smallBox.ToString());
        Console.WriteLine(mediumBox.ToString());
        Console.WriteLine(largeBox.ToString());
        Console.WriteLine(box1.ToString());
        Console.WriteLine(box2.ToString());
        Console.WriteLine(newBox.ToString());

        Console.ReadLine();
    }
}