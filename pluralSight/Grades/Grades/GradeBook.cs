using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
  public class GradeBook
  {

    public GradeBook()
    {
      _grades = new List<decimal>();
    }

    public GradesStatistics ComputeStatistics()
    {
      GradesStatistics stats = new GradesStatistics();

      stats.HighestGrade = _grades.Max();
      stats.LowestGrade = _grades.Min();
      stats.AverageGrade = _grades.Average();
      var sum = _grades.Sum();

      var evens = _grades.Where(x => (Math.Round(x) % 2) == 0);
      var letters = _grades.Select(x => GradeFor(x));
      var letters2 = _grades.Select(GradeFor);

      var testResults = _grades.Select(g => new
      {
        Grade = g,
        Letter = GradeFor(g),
        IsPassing = GradeFor(g) != "F",
      });

      var letterGrades = testResults.GroupBy(group => group.Letter);
      var failing = letterGrades.Where(group => group.Key == "F").SelectMany(grouping => grouping);
      var passing = letterGrades.Where(group => group.Key != "F").SelectMany(g => g);

      var otherPassing = testResults.Where(r => r.IsPassing);

      Func<decimal, decimal> doubleIt = Doubler;
      Func<decimal, decimal> halver =
        (x) =>
        {
          return x / 2m;
        };
      Func<decimal, decimal> quarterer = (x) => x / 4m;

      var doubled = _grades.Sum(doubleIt);
      var quadrupled = _grades.Sum(x => x * 4);


      foreach (var grade in _grades)
      {
        stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
        stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
        sum += grade;
      }

      stats.AverageGrade = sum / _grades.Count;

      return stats;
    }

    public decimal Doubler(decimal x)
    {
      return x * 2;
    }

    public void AddGrade(decimal grade)
    {
      _grades.Add(grade);
    }

    private string GradeFor(decimal x)
    {
      string grade;
      if (x > 90) grade = "A";
      else if (x > 80) grade = "B";
      else grade = "F";

      return grade;
    }

    public string Name;

    private List<decimal> _grades;
  }
}
