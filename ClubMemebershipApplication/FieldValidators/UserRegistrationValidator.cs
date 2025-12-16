using ClubMemebershipApplication.Data;
using FieldValidatorAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMemebershipApplication.FieldValidators
{
    public class UserRegistrationValidator : IFieldValidator
    {

        const int FirstName_Min_Lenght = 2;
        const int FirstName_Max_Lenght = 100;
        const int LastName_Min_Lenght = 2;
        const int LastName_Max_Lenght = 100;

        delegate bool EmailExistsDel(string emailAdress);

        FieldValidatorDel _fieldValidatorDel = null;

        RequiredValidDel _requiredValidDel = null;
        StringLengthValidDel _stringLengthValidDel = null;
        DateValidDel _dateValidDel = null;
        PatternValidDel _patternValidDel = null;
        CompareFieldsValidDel _compareFieldsValidDel = null;

        EmailExistsDel _emailExistsDel = null;

        string[] _fieldArray = null;
        IRegister _register = null;
        public string[] FieldArray
        {
            get
            {
                if (_fieldArray == null)
                {
                    _fieldArray = new string[Enum.GetValues(typeof(FieldConstants.UserRegistrationField)).Length];

                }

                return _fieldArray;
            }
        }

        public FieldValidatorDel ValidatorDel => _fieldValidatorDel;

        public UserRegistrationValidator(IRegister register)
        {
            _register = register;
        }

        public void InitilialiseValidatorDelegates()
        {
            _fieldValidatorDel = new FieldValidatorDel(ValidateField);
            _emailExistsDel = new EmailExistsDel(_register.EmailExists);

            _requiredValidDel = CommonFieldValidatorFunctions.RequiredFieldValidDel;
            _stringLengthValidDel = CommonFieldValidatorFunctions.StringLengthValidDel;
            _dateValidDel = CommonFieldValidatorFunctions.DateValidDel;
            _patternValidDel = CommonFieldValidatorFunctions.PatternValidDel;
            _compareFieldsValidDel = CommonFieldValidatorFunctions.CompareFieldsValidDel;
        }

        private bool ValidateField(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage)
        {
            fieldInvalidMessage = "";

            FieldConstants.UserRegistrationField userRegistrationField = (FieldConstants.UserRegistrationField)fieldIndex;

            switch (userRegistrationField)
            {
                case FieldConstants.UserRegistrationField.EmailAddress:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} \n" : "";
                    fieldInvalidMessage = (fieldInvalidMessage ==  "" && !_patternValidDel(fieldValue, CommonRegularExpressionValidationPatterns.Email_Address_RegEx_Pattern)) ? $"You must enter a valide email address for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} \n" : fieldInvalidMessage;
                    fieldInvalidMessage = (fieldInvalidMessage == "" && _emailExistsDel(fieldValue)) ? $"This email address already exists. Please try again \n" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.FirstName:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} \n" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_stringLengthValidDel(fieldValue, FirstName_Min_Lenght, FirstName_Max_Lenght)) ? $"You must enter a valide First Name must be between {FirstName_Min_Lenght} and {FirstName_Max_Lenght} : {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} \n" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.LastName:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} \n" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_stringLengthValidDel(fieldValue, LastName_Min_Lenght, LastName_Max_Lenght)) ? $"You must enter a valide Last Name must be between {LastName_Min_Lenght} and {LastName_Max_Lenght} : {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} \n" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.Password:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} \n" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternValidDel(fieldValue, CommonRegularExpressionValidationPatterns.Strong_Password_RegEx_Pattern)) ? $"You must enter a valide Password it must have 1 lower case letter, 1 capital letter, 1 special character and the length between 6 and 10 characters : {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} \n" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.PasswordCompare:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} \n" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_compareFieldsValidDel(fieldValue, FieldArray[(int)FieldConstants.UserRegistrationField.Password])) ? $"Your entry did not match your password: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} \n" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.DateOfBirth:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} \n" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_dateValidDel(fieldValue, out DateTime validDateTime)) ? $"Your entry was not a valid date: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} \n" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.PhoneNumber:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} \n" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternValidDel(fieldValue, CommonRegularExpressionValidationPatterns.Uk_PhoneNumber_RegEx_Pattern)) ? $"Your entry was not a valid UK phone number: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} \n" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.AddressFirstLine:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} \n" : "";
                    break;
                case FieldConstants.UserRegistrationField.AddressSecondLine:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} \n" : "";
                    break;
                case FieldConstants.UserRegistrationField.AddressCity:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} \n" : "";
                    break;
                case FieldConstants.UserRegistrationField.PostCode:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} \n" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternValidDel(fieldValue, CommonRegularExpressionValidationPatterns.Uk_Post_Code_RegEx_Pattern)) ? $"Your entry was not a valid UK postal code: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} \n" : fieldInvalidMessage;
                    break;
                default:
                    throw new ArgumentException("This field does not exists");
            }

            return (fieldInvalidMessage == "");
        }
    }
}
