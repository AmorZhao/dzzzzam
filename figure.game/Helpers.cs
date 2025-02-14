// W = white
// C = cyan
// B = blue
// Y = yellow
// N = none

using System;
using System.IO;
using System.Collections.Generic;

class Helpers
{
    private static readonly char[] Letters = { 'W', 'B', 'C', 'Y' };
    private static readonly char Separator = ' ';
    private static readonly int ColumnLength = 5; 
    private static List<List<List<char>>> dataHistory = new List<List<List<char>>>();

    public static List<List<char>> getCurrentData()
    {
        return dataHistory[dataHistory.Count - 1];
    }

    public static void GenerateAndWriteDataToFile(string filename, int rowLength)
    {
        Random random = new Random();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            for (int i = 0; i < rowLength; i++)
            {
                List<char> row = new List<char>(new char[2 * ColumnLength]);
                for (int j = 0; j < ColumnLength; j++)
                {
                    row[j * 2] = Letters[random.Next(Letters.Length)];
                    row[j * 2 + 1] = Separator;
                }
                writer.WriteLine(new string(row.ToArray()));
            }
        }
        Console.WriteLine($"{rowLength} rows of data have been written to {filename}");
    }

    public static List<List<char>> ReadData(string filename)
    {
        var lines = File.ReadAllLines(filename);
        var data = new List<List<char>>(lines.Length);
        for (int i = 0; i < lines.Length; i++)
        {
            var chars = lines[i].Split(Separator);
            var row = new List<char>(new char[5]);
            for (int j = 0; j < ColumnLength; j++)
            {
                row[j] = chars[j][0];
            }
            data.Insert(0, row);
        }
        dataHistory.Add(data);
        return data;
    }

    public static void PrintData(List<List<char>> data = null)
    {
        if (data == null)
        {
            data = getCurrentData();
        }
        for (int i = data.Count-1; i >= 0; i--)
        {
            Console.WriteLine(string.Join(Separator.ToString(), data[i]));
        }
    }

    public static List<List<char>> CreateNewColorMap(List<List<char>> data, int columnNumber)
    {
        var rowLength = data.Count;
        var colLength = data[0].Count;

        var color = data[0][columnNumber];  // C
        Console.WriteLine($"Color: {color}");

        List<List<char>> newColorMap = new List<List<char>>(rowLength);
        for (int i = 0; i < rowLength; i++)
        {
            newColorMap.Add(new List<char>(new char[colLength]));
        }

        void ClearAdjacent(int row, int col)
        {
            if (row < 0 || row >= rowLength || col < 0 || col >= colLength
                || data[row][col] == 'N' || data[row][col] != color)
            {
                return;
            }
            if (data[row][col] == color && newColorMap[row][col] != 'N')
            {
                newColorMap[row][col] = 'N';
                ClearAdjacent(row + 1, col);
                ClearAdjacent(row, col - 1);
                ClearAdjacent(row, col + 1);
            }
            return; 
        }
        ClearAdjacent(0, columnNumber);

        for (int col = 0; col < colLength; col++)
        {
            int insertPosition = 0;
            for (int row = 0; row < rowLength; row++)
            {
                if (newColorMap[row][col] != 'N')
                {
                    newColorMap[insertPosition++][col] = data[row][col];
                    continue; 
                }
            }
            while (insertPosition < rowLength)
            {
                newColorMap[insertPosition++][col] = 'N';
            }
        }
        return newColorMap;
    }

    public static void PerformOperation(int stepCounter, int columnNumber, bool isUndo = false)
    {
        if (isUndo)
        {
            if (dataHistory.Count > 1)
            {
                dataHistory.RemoveAt(dataHistory.Count - 1);
            }
            else
            {
                throw new InvalidOperationException(
                    "Cannot undo operation. "
                );
            }
        }
        
        var data = getCurrentData(); 
        if (data[0][columnNumber] == 'N')
        {
            throw new InvalidOperationException(
                $"Cannot perform operation on column {columnNumber} because it is empty"
            );
        }

        Console.WriteLine($"Operation on column {columnNumber}:");
        dataHistory.Add(CreateNewColorMap(data, columnNumber));
        Console.WriteLine($"Step {stepCounter}:");
        PrintData();
    }

    public static bool isClearedMap(List<List<char>> data = null)
    {
        if (data == null)
        {
            data = getCurrentData();
        }
        return data.TrueForAll(row => 
            row.TrueForAll(cell => cell == 'N')
        );
    }
}
