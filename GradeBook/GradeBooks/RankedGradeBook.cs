using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();

            var betterGrade = 0;
            foreach (Student student in Students)
            {
                if (averageGrade < student.AverageGrade)
                    betterGrade += 1;
            }

            var top20Percent = (int)Math.Ceiling(Students.Count * 0.2);
            var top40Percent = (int)Math.Ceiling(Students.Count * 0.4);
            var top60Percent = (int)Math.Ceiling(Students.Count * 0.6);
            var top80Percent = (int)Math.Ceiling(Students.Count * 0.8);

            if (betterGrade <= top20Percent)
                return 'A';
            else if (betterGrade > top20Percent && betterGrade <= top40Percent)
                return 'B';
            else if (betterGrade > top40Percent && betterGrade <= top60Percent)
                return 'C';
            else if (betterGrade > top60Percent && betterGrade <= top80Percent)
                return 'D';

            return 'F';
        }
    }
}
