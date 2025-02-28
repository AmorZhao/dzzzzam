using System;

public class FigureGameTests
{
    public static void RunAllTests(bool verbose = false)
    {
        var Solutions = System.IO.File.ReadAllLines("test/testSolutions.txt");
        var NumberOfTests = Solutions.Length;
        var TestNumbers = Enumerable.Range(1, NumberOfTests).ToList();

        var passed = 0; 

        foreach (var number in TestNumbers)
        {
            Console.WriteLine($"Running test {number}: ");

            Helpers.ReadData($"test/test{number}.txt");
            Helpers.PrintData();

            var operations = Solutions[number - 1].Trim().Split(' ').Where(s => !string.IsNullOrEmpty(s)).Select(int.Parse).ToList();
            for (int i = 0; i < operations.Count; i++)
            {
                Helpers.PerformOperation(i + 1, operations[i], verbose: verbose);
            }
            Console.WriteLine($"Performed operations: {Solutions[number-1]}");
            Console.WriteLine($"Solved test {number}: {Helpers.isClearedMap()}");
            passed += Helpers.isClearedMap() ? 1 : 0;
        }

        Console.WriteLine($"Passed {passed} out of {NumberOfTests} tests");
    }

    public static void RunTestWithSolution(int testNumber, List<int> operations, bool verbose = false)
    {
        Console.WriteLine($"Running test {testNumber}: ");

        Helpers.ReadData($"test/test{testNumber}.txt");
        Helpers.PrintData();

        for (int i = 0; i < operations.Count; i++)
        {
            Helpers.PerformOperation(i + 1, operations[i], verbose: verbose);
        }
        Console.WriteLine($"Performed operations: {string.Join(" ", operations)}");
        Console.WriteLine($"Solved test {testNumber}: {Helpers.isClearedMap()}");
    }
}