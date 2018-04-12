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

        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Ranked-grading grades students not based on their individual performance, 
        /// but rather their performance compared to their peers
        /// </summary>
        /// <param name="averageGrade">Input Grade</param>
        /// <returns>Letter grade assigned to input grade</returns>
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            var letterGradeDrop = Students.Count / 5;

            // Sort students by grades and then get the thresholds for the top four grades.
            var sortedStudentByGrade = Students.OrderByDescending(s => s.AverageGrade).ToList();

            var top20Percent = sortedStudentByGrade[letterGradeDrop - 1].AverageGrade;
            var second20Percent = sortedStudentByGrade[(letterGradeDrop * 2) - 1].AverageGrade;
            var third20Percent = sortedStudentByGrade[(letterGradeDrop * 3) - 1].AverageGrade;
            var fourth20Percent = sortedStudentByGrade[(letterGradeDrop * 4) - 1].AverageGrade;

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
            else
            {
                return 'F';
            }
        }

        /// <summary>
        /// Checks to see if there are more than 5 students and then calculates Statistics of the gradebook.
        /// </summary>
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        /// <summary>
        /// Checks to see if the gradebook has more than 5 students and 
        /// then calculates the student's overall grade.
        /// </summary>
        /// <param name="name">Name of the student</param>
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
        #endregion
    }
}
