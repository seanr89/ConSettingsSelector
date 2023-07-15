using Spectre.Console;

AnsiConsole.Write(
    new FigletText("Console Selector")
        .LeftJustified()
        .Color(Color.Red));

var opts = new Options();
opts.CreateAccountSubOptions();

// Ask for the user's favorite fruit
var account = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Select an [green]Account[/]?")
        .PageSize(10)
        .MoreChoicesText("[grey](Move up and down to reveal more accounts)[/]")
        .AddChoices(opts.Accounts));

// Echo the account back to the terminal
AnsiConsole.MarkupLine($"You selected the [red]{account}[/] account!");

var env = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Select an [green]Environment[/]?")
        .PageSize(10)
        .MoreChoicesText("[grey](Move up and down to reveal more environments)[/]")
        .AddChoices(opts.AccountSubOptions.First(x => x.Name == account).Values));

// Echo the env back to the terminal
AnsiConsole.MarkupLine($"You selected the [red]{env}[/] environment!");

var project = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Select a [green]Project[/]?")
        .PageSize(10)
        .MoreChoicesText("[grey](Move up and down to reveal more projects)[/]")
        .AddChoices(opts.Projects));

// Echo the env back to the terminal
AnsiConsole.MarkupLine($"You selected the [red]{project}[/] project!");


AnsiConsole.MarkupLine($"Choices Entered- Account:[red]{account}[/] Env:[red]{env}[/] Project:[red]{project}[/]");


AnsiConsole.WriteLine("App Complete!");