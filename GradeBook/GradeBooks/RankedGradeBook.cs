using System;
using System.Collections.Generic;
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

            Students.Sort((x, y) => x.AverageGrade.CompareTo(y.AverageGrade));
            return 'F';
        }
        #endregion
    }
}
