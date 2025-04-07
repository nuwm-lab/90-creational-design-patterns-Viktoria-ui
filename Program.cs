using System;
using System.Collections.Generic;


class EducationalProgram
{
    public List<string> Subjects = new();
    public int DurationInMonths;
    public string DifficultyLevel;

    public void Display()
    {
        Console.WriteLine("Освітня програма:");
        Console.WriteLine($"- Тривалість: {DurationInMonths} міс.");
        Console.WriteLine($"- Рівень складності: {DifficultyLevel}");
        Console.WriteLine("- Предмети:");
        foreach (var subject in Subjects)
            Console.WriteLine($"  - {subject}");
    }
}


interface IProgramBuilder
{
    void SetSubjects();
    void SetDuration();
    void SetDifficulty();
    EducationalProgram GetProgram();
}


class BeginnerProgramBuilder : IProgramBuilder
{
    private EducationalProgram program = new();

    public void SetSubjects()
    {
        program.Subjects.AddRange(new[] { "Математика", "Інформатика", "Основи програмування" });
    }

    public void SetDuration()
    {
        program.DurationInMonths = 6;
    }

    public void SetDifficulty()
    {
        program.DifficultyLevel = "Початковий";
    }

    public EducationalProgram GetProgram()
    {
        return program;
    }
}

class AdvancedProgramBuilder : IProgramBuilder
{
    private EducationalProgram program = new();

    public void SetSubjects()
    {
        program.Subjects.AddRange(new[] { "Алгоритми", "Архітектура ПЗ", "Бази даних", "ШІ" });
    }

    public void SetDuration()
    {
        program.DurationInMonths = 12;
    }

    public void SetDifficulty()
    {
        program.DifficultyLevel = "Просунутий";
    }

    public EducationalProgram GetProgram()
    {
        return program;
    }
}


class ProgramDirector
{
    private IProgramBuilder builder;

    public ProgramDirector(IProgramBuilder builder)
    {
        this.builder = builder;
    }

    public void Construct()
    {
        builder.SetSubjects();
        builder.SetDuration();
        builder.SetDifficulty();
    }

    public EducationalProgram GetProgram()
    {
        return builder.GetProgram();
    }
}


class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Оберіть тип освітньої програми:");
        Console.WriteLine("1 - Початкова\n2 - Просунута");
        string choice = Console.ReadLine();

        IProgramBuilder builder = choice == "2"
            ? new AdvancedProgramBuilder()
            : new BeginnerProgramBuilder();

        ProgramDirector director = new(builder);
        director.Construct();

        EducationalProgram program = director.GetProgram();
        program.Display();
    }
}
