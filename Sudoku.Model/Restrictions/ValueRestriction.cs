using SudokuApp.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApp.Model.Restrictions
{
    internal class ValueRestriction : ValueObject
    {
        private readonly int value;
        private readonly ValueRestrictionType valueRestrictionType;

        private ValueRestriction(int value, ValueRestrictionType valueRestrictionType)
        {
            this.value = value;
            this.valueRestrictionType = valueRestrictionType;
        }

        public static ValueRestriction Create(int value, ValueRestrictionType valueRestrictionType)
        {
            return new ValueRestriction(value, valueRestrictionType);
        }

        public int Value { get { return value; } }
    }
}
