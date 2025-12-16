using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FieldValidatorAPI
{
    public delegate bool RequiredValidDel(string fieldValue);
    public delegate bool StringLengthValidDel(string fieldValue, int min, int max);
    public delegate bool DateValidDel(string fieldValue, out DateTime validDateTime);
    public delegate bool PatternValidDel(string fieldValue, string pattern);
    public delegate bool CompareFieldsValidDel(string fieldValue, string fieldValCompare);
    public class CommonFieldValidatorFunctions
    {
        private static RequiredValidDel _requiredValidDel = null;
        private static StringLengthValidDel _stringLengthValidDel = null;
        private static DateValidDel _dateValidDel = null;
        private static PatternValidDel _patternValidDel = null;
        private static CompareFieldsValidDel _compareFieldsValidDel = null;

        public static RequiredValidDel RequiredFieldValidDel
        {
            get
            {
                if (_requiredValidDel == null)
                {
                    _requiredValidDel = new RequiredValidDel(RequiredValid);
                }

                return _requiredValidDel;
            }
        }

        public static StringLengthValidDel StringLengthValidDel
        {
            get
            {
                if (_stringLengthValidDel == null)
                {
                    _stringLengthValidDel = new StringLengthValidDel(StringLengthValid);
                }

                return _stringLengthValidDel;
            }
        }
        public static DateValidDel DateValidDel
        {
            get
            {
                if (_dateValidDel == null)
                {
                    _dateValidDel = new DateValidDel(DateValid);
                }

                return _dateValidDel;
            }
        }
        public static PatternValidDel PatternValidDel
        {
            get
            {
                if (_patternValidDel == null)
                {
                    _patternValidDel = new PatternValidDel(PatternValid);
                }

                return _patternValidDel;
            }
        }
        public static CompareFieldsValidDel CompareFieldsValidDel
        {
            get
            {
                if (_compareFieldsValidDel == null)
                {
                    _compareFieldsValidDel = new CompareFieldsValidDel(CompareFieldsValid);
                }

                return _compareFieldsValidDel;
            }
        }

        private static bool RequiredValid(string fieldValue)
        {
            if (!string.IsNullOrEmpty(fieldValue))
            {
                return true;
            }

            return false;
        }

        private static bool StringLengthValid(string fieldValue, int min, int max)
        {
            if (fieldValue.Length >= min && fieldValue.Length <= max)
            {
                return true;
            }

            return false;
        }

        private static bool DateValid(string fieldValue, out DateTime validDateTime)
        {
            if (DateTime.TryParse( fieldValue, out validDateTime))
            {
                return true;
            }

            return false;
        }

        private static bool PatternValid(string fieldValue, string pattern)
        {

            Regex regex = new Regex(pattern);
            if (regex.IsMatch(fieldValue))
            {
                return true;
            }

            return false;
        }

        private static bool CompareFieldsValid(string fieldValue, string fieldValCompare)
        {
            if (fieldValue.Equals(fieldValCompare))
            {
                return true;
            }

            return false;
        }


    }
}
