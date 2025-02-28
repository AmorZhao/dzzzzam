// To run this script: `dotnet script Main.cs`
// ensure you have `dotnet-script` installed: `dotnet tool install -g dotnet-script`

#load "Helpers.cs"
#load "FigureGameSolver.cs"
#load "testMain.cs"

FigureGameTests.RunAllTests(); 

// FigureGameTests.RunTestWithSolution(15, new List<int> {4, 3, 3, 1, 0, 0, 1, 2, 2}, verbose: true); 

// const string testFilePath = "test/test4.txt";
// Helpers.ReadData(testFilePath);
// Helpers.PrintData();
// FigureGameSolver.Solve(Helpers.getCurrentData());
