using System;
// using Xunit;

public class FigureGameTests
{
    public static void Test1()
    {
        Helpers.ReadData("test/test1.txt");
        Helpers.PerformOperation(1, 3);
        Helpers.PerformOperation(2, 0);
        Helpers.PerformOperation(3, 3);
        Helpers.PerformOperation(4, 0);
        Console.WriteLine($"Solved puzzle: {Helpers.isClearedMap()}"); //true
    }

    public static void Test2()
    {
        Helpers.ReadData("test/test2.txt");
        Helpers.PerformOperation(1, 0);
        Helpers.PerformOperation(2, 2);
        Helpers.PerformOperation(3, 1);
        Helpers.PerformOperation(4, 0);
        Helpers.PerformOperation(5, 0);
        Helpers.PerformOperation(6, 4);
        Helpers.PerformOperation(7, 2);
        Helpers.PerformOperation(8, 4);
        Helpers.PerformOperation(9, 4);
        Console.WriteLine($"Solved puzzle: {Helpers.isClearedMap()}"); //true
    }

    public static void Test3()
    {
        Helpers.ReadData("test/test3.txt");
        Helpers.PerformOperation(1, 4);
        Helpers.PerformOperation(2, 3);
        Helpers.PerformOperation(3, 2);
        Helpers.PerformOperation(4, 0);
        Helpers.PerformOperation(5, 1);
        Helpers.PerformOperation(6, 0);
        Helpers.PerformOperation(7, 2);
        Helpers.PerformOperation(8, 0);
        Helpers.PerformOperation(9, 0);
        Console.WriteLine($"Solved puzzle: {Helpers.isClearedMap()}"); //true
    }

    public static void Test4()
    {
        Helpers.ReadData("test/test4.txt");
        Helpers.PerformOperation(1, 1);
        Helpers.PerformOperation(2, 0);
        Helpers.PerformOperation(3, 2);
        Helpers.PerformOperation(4, 4);
        Helpers.PerformOperation(5, 0);
        Console.WriteLine($"Solved puzzle: {Helpers.isClearedMap()}"); //true
    }

    public static void RunAllTests()
    {
        Test1();
        Test2();
        Test3();
        Test4();
    }
}