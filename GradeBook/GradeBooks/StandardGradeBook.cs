﻿using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook : BaseGradeBook
    {
        #region Constructors

        public StandardGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Standard;
        }
        #endregion
    }
}
