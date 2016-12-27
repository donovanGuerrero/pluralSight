using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {

        public GradeBook()
        {
            _grades = new List<float>();
        }

        public GradesStatistics ComputeStatistics()
        {
            GradesStatistics stats = new GradesStatistics();
            float sum = 0;
            foreach (float grade in _grades )
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / _grades.Count;

            return stats;
        }

        public void AddGrade(float grade)
        {
            _grades.Add(grade);
        }

        private List<float> _grades;
    }
}
