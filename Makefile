.PHONY: lint run

run:
	dotnet run --project MazeConsole/

lint:
	dotnet csharpier .
