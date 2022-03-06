using Spectre.Console;

var answers = new AnswersModel();

AnsiConsole.Write(
 new FigletText("readme-generator")
     .Centered()
     .Color(Color.White));

answers.ProjectName = AnsiConsole.Prompt<string>(
    new TextPrompt<string>("Enter the [green]project name[/]?")
    );

answers.License = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Select [green]license[/] to use")
        .PageSize(10)
        .MoreChoicesText("[grey](Move up and down to reveal more license)[/]")
        .AddChoices(new[] {
            "MIT", "Apache","GPL"
        }));

answers.projectLogoYesNo = AnsiConsole.Confirm("Do you have a project logo?");

if (answers.projectLogoYesNo)
{
    answers.ProjectLogo = AnsiConsole.Prompt<string>(
        new TextPrompt<string>("Enter the image url of the project logo (leave blank if none)")
        );
}

answers.ShortDescription = AnsiConsole.Prompt<string>(
    new TextPrompt<string>("Enter the short description (it should be short, concise to hook the reader)")
    );

answers.ImageYesNo = AnsiConsole.Confirm("Do you have an image for the project?");

if (answers.ImageYesNo)
{
    answers.ImageUrl = AnsiConsole.Prompt<string>(
        new TextPrompt<string>("Enter the image url (leave blank if none)")
        );
}

answers.DemoImageYesNo = AnsiConsole.Confirm("Do you have an image/gif for the demo of the project?");

if (answers.DemoImageYesNo)
{
    answers.DemoImageUrl = AnsiConsole.Prompt<string>(
        new TextPrompt<string>("Enter the demo image url (leave blank if none)")
        );
}

answers.ContributingYesNo = AnsiConsole.Confirm("Do you want to add a Contributing section?");

AnsiConsole.Status()
    .Start("Generating README...", ctx =>
    {
        string readmePath = Directory.GetCurrentDirectory();


    });