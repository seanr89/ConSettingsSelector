using Spectre.Console;

var opts = new Options();
opts.CreateAccountSubOptions();

AnsiConsole.Write(
    new FigletText("Console Selector")
        .LeftJustified()
        .Color(Color.Red));

bool continueLoop = true;
Console.CancelKeyPress += delegate(object? sender, ConsoleCancelEventArgs e) {
    e.Cancel = true;
    continueLoop = false;
    Console.WriteLine("Exiting...");
    Environment.Exit(0);
};


while(continueLoop)
{
    AskQuestions();
}

/// <summary>
/// Ask the user a series of questions
/// and echo the answers back to the terminal.
/// </summary>
void AskQuestions(){

    var account = CreateAndWaitForResponse("Select an [green]Account[/]?", opts.Accounts);
    var region = CreateAndWaitForResponse("Select a [green]Region[/]?", opts.Regions);
    var env = CreateAndWaitForResponse("Select an [green]Environment[/]?", 
        opts.AccountSubOptions.First(x => x.Name == account).Values.ToArray());

    var project = CreateAndWaitForResponse("Select a [green]Project[/]?", opts.Projects);

    AnsiConsole.MarkupLine($"Choices Entered - Account:[red]{account}[/] Env:[red]{env}[/] Project:[red]{project}[/]");
    continueLoop = AnsiConsole.Confirm("Do you want to continue?");
}

/// <summary>
/// Create selection prompt and wait for response
/// </summary>
/// <param name="message"></param>
/// <param name="choices"></param>
string CreateAndWaitForResponse(string message, string[] choices)
{
    var response = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title(message)
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to reveal more choices)[/]")
            .AddChoices(choices));

    // Echo the response back to the terminal
    AnsiConsole.MarkupLine($"You selected [red]{response}[/]!");

    return response;
}


AnsiConsole.WriteLine("App Complete!");
Environment.Exit(0);