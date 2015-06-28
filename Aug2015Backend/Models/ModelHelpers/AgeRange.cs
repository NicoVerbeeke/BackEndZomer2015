using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aug2015Backend.Models.ModelHelpers
{
    public class AgeRange
    {
        private int _minAge = 0;
        private int _maxAge = int.MaxValue;

        public int Min_leeftijd
        {
            get { return _minAge; }

            set
            {
                if (!(value < 0 || value > Max_leeftijd))
                {
                    _minAge = value;
                }
            }
        }

        public int Max_leeftijd
        {
            get { return _maxAge; }

            set
            {
                if (!(value < Min_leeftijd || value > 100))
                {
                   _maxAge = value;
                }
            }
        }
    }
}