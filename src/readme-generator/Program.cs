using Spectre.Console;
using System.Text;

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
    .Start("Generating README.md...", ctx =>
    {
        var readmePath = Path.Combine(Directory.GetCurrentDirectory(), "README.md");
        var sb = new StringBuilder();

        sb.AppendLine("<div align=\"center\">");
        sb.AppendLine($"<h1>{answers.ProjectName}</h1>");

        if (answers.projectLogoYesNo)
        {
            sb.AppendLine($"<img src =\"{answers.ProjectLogo}\" alt=\"{answers.ProjectName}\" align=\"center\" width=\"100\" height=\"100\">");
        }

        sb.AppendLine("<br />");

        switch (answers.License.ToLower())
        {
            case "mit":
                sb.AppendLine("<img alt=\"License: MIT\" src=\"https://img.shields.io/badge/License-MIT-blue.svg\" />");
                break;
            case "apache":
                sb.AppendLine("<img alt=\"License: Apache\" src=\"https://img.shields.io/badge/license-Apache%202-blue\" />");
                break;
            case "gpl":
                sb.AppendLine("<img alt=\"License: GPL\" src=\"https://img.shields.io/badge/license-GPL-blue\" />");
                break;

            default:
                break;
        }

        sb.AppendLine("<br />");

        sb.AppendLine($"{answers.ShortDescription}");

        sb.AppendLine("<br />");

        if (answers.ImageYesNo)
        {
            sb.AppendLine("<hr />");
            sb.AppendLine($"<h2>Screenshots</h2>");
            sb.AppendLine($"<img src =\"{answers.ImageUrl}\" alt=\"{answers.ProjectName}\" align=\"center\" height=\"500\">");
        }

        sb.AppendLine("<br />");

        if (answers.DemoImageYesNo)
        {
            sb.AppendLine("<hr />");
            sb.AppendLine($"<h2>Demo</h2>");
            sb.AppendLine($"<img src =\"{answers.DemoImageUrl}\" alt=\"{answers.ProjectName}\" align=\"center\" height=\"500\">");
        }

        sb.AppendLine("<br />");

        if (answers.ImageYesNo)
        {
            sb.AppendLine("<hr />");
            sb.AppendLine($"<h2>Contributing</h2>");
            sb.AppendLine("Contributions are always welcome!");
        }

        sb.AppendLine("</div>");

        File.WriteAllText(readmePath, sb.ToString());

        AnsiConsole.MarkupLine($"README created successfully: {readmePath}");
    });