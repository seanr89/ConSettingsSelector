using Spectre.Console;

AnsiConsole.Write(
    new FigletText("Console Selector")
        .LeftJustified()
        .Color(Color.Red));

var opts = new Options();

// Ask for the user's favorite fruit
var account = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Select an [green]Environment[/]?")
        .PageSize(10)
        .MoreChoicesText("[grey](Move up and down to reveal more environments)[/]")
        .AddChoices(opts.Environments));

// Echo the fruit back to the terminal
AnsiConsole.MarkupLine($"You selected the [red]{account}[/] account!");

AnsiConsole.WriteLine("App Complete!");