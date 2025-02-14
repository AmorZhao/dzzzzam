#load "Helpers.cs"
using System;
using System.Collections.Generic;

class FigureGameSolver
{
    private static int stepCounter = 0;
    public static void Solve(List<List<char>> data)
    {
        if (Helpers.getCurrentData().Count <= 10)
        {
            var bestSolution = BruteForceSolve(data); 
            Console.WriteLine($"Best solution takes {bestSolution.Count} steps:");
            Console.WriteLine(string.Join(" ", bestSolution));
            foreach (var step in bestSolution)
            {
                Helpers.PerformOperation(++stepCounter, step, false);
            }
            Console.WriteLine($"Solved puzzle: {Helpers.isClearedMap(Helpers.getCurrentData())}");
            return;
        }
        throw new Exception("Too long... ㅠ-ㅠ taking too much time...");
    }

    private static List<int> BruteForceSolve(List<List<char>> colorMap)
    {
        var solutions = new List<List<int>>();
        var bestPath = new List<int>();
        var lastColor = 'N';

        for (int col = 0; col < colorMap[0].Count; col++)
        {
            if (colorMap[0][col] == lastColor || colorMap[0][col] == 'N')  
            {
                lastColor = 'N';
                continue;
            }
            lastColor = colorMap[0][col];

            Console.WriteLine($"Trying column {col}");
            var newColorMap = Helpers.CreateNewColorMap(colorMap, col);
            Helpers.PrintData(newColorMap);

            if (Helpers.isClearedMap(newColorMap))
            {
                return new List<int> { col };
            }

            var solution = BruteForceSolve(newColorMap);

            if (solution != null)
            {
                solutions.Add(solution);
                if (bestPath.Count == 0 || solution.Count < bestPath.Count)
                {
                    bestPath = new List<int> { col };
                    bestPath.AddRange(solution);
                }
            }
        }    
        return bestPath.Count > 0 ? bestPath : null;
    }
}