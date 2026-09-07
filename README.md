# Chessington

A chess exercise built with a .NET game engine, NUnit tests, and a WPF user interface.

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) (the repo pins SDK `10.0.100` via `global.json`)
- Windows (required for the WPF UI)

## Build

From the repository root:

```powershell
dotnet restore
dotnet build
```

Build a single project:

```powershell
dotnet build Chessington.GameEngine
dotnet build Chessington.GameEngine.Tests
dotnet build Chessington.UI
```

## Test

Run all tests:

```powershell
dotnet test Chessington.GameEngine.Tests
```

Run tests with more detail:

```powershell
dotnet test Chessington.GameEngine.Tests --verbosity normal
```

## Run the UI

```powershell
dotnet run --project Chessington.UI
```

The WPF window shows the board, piece icons, selection, and captured pieces.


## Rider

### Run the UI

1. Open `Chessington.sln`
2. Right-click **Chessington.UI** → **Run** or **Debug**

Or create a shared run configuration:

1. **Run → Edit Configurations…**
2. **+ → .NET Project**
3. Name: `Chessington UI`, Project: `Chessington.UI/Chessington.UI.csproj`
4. Enable **Store in project file** to save it under `.run/`

### Run tests

1. Open **View → Tool Windows → Unit Tests**
2. Click **Refresh** if needed
3. Run all tests, a fixture, or a single test from the tree

To create a reusable test run configuration:

1. **Run → Edit Configurations…**
2. **+ → Unit Tests**
3. Name: `All GameEngine Tests`, Scope: `Chessington.GameEngine.Tests`
4. Enable **Store in project file**

If tests do not appear, rebuild the solution and check **Settings → Build, Execution, Deployment → Unit Testing → NUnit** is enabled.

## VS Code

Install these extensions:

- [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) (includes C# and test support)
- Or at minimum: [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)

Open the repository folder (the folder containing `Chessington.sln`).

### Run tests

1. Open the **Testing** side bar (beaker icon)
2. Wait for tests to be discovered in `Chessington.GameEngine.Tests`
3. Use **Run All Tests** or run individual tests from the tree

