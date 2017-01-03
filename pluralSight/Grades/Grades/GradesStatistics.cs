using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
  public class GradesStatistics
  {

    public GradesStatistics()
    {
      HighestGrade = 0;
      LowestGrade = decimal.MaxValue;
    }
    public decimal AverageGrade;
    public decimal HighestGrade;
    public decimal LowestGrade;
  }
}
