using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMemebershipApplication.FieldValidators
{

    public delegate bool FieldValidatorDel(int fieldIndex, string fieldvalue, string[] fieldArrray, out string fieldInvalidMessage);
    public interface IFieldValidator
    {

        void InitilialiseValidatorDelegates();
        
        string[] FieldArray { get; }

        FieldValidatorDel ValidatorDel { get; }

    }
}
