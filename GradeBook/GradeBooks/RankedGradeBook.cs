using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        #region Constructors

        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }
        #endregion

        #region Methods

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            var letterGradeDrop = Students.Count / 5;

            // Sort students by grades and then get the thresholds for the top four grades.
            var sortedStudentByGrade = Students.OrderByDescending(s => s.AverageGrade).ToList();

            var top20Percent = sortedStudentByGrade[letterGradeDrop].AverageGrade;
            var second20Percent = sortedStudentByGrade[letterGradeDrop * 2].AverageGrade;
            var third20Percent = sortedStudentByGrade[letterGradeDrop * 3].AverageGrade;
            var fourth20Percent = sortedStudentByGrade[letterGradeDrop * 4].AverageGrade;

            if (averageGrade >= top20Percent)
            {
                return 'A';
            }
            else if (averageGrade >= second20Percent)
            {
                return 'B';
            }
            else if (averageGrade >= third20Percent)
            {
                return 'C';
            }
            else if (averageGrade >= fourth20Percent)
            {
                return 'D';
            }

            return 'F';
        }
        #endregion
    }
}
