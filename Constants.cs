using System;
using System.Linq;

namespace ParaBankPractice
{
    public static class Constants
    {
        public const int TimeoutInSeconds = 30;
        private static Random Random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }
        public static readonly string NewUserName = RandomString(7);
        public const string ValidUserName = "HazimOkanovic";
        public const string IncorrectUserName = "HazimHazimHazim";
        public const string ValidPassword = "Something";
        public const string LogInMessage = "Accounts Overview";
        public const string LogOutMessage = "Customer Login";
        public const string EnterUserNameAndPasswordError = "Please enter a username and password.";
        public const string InternalError = "An internal error has occurred and has been logged.";
        public const string WrongPassword = "SomethingSomething";
        public const string SignUpTitle = "Signing up is easy!";
        public const string FirstNameError = "First name is required.";
        public const string LastNameError = "Last name is required.";
        public const string AddressError = "Address is required.";
        public const string CityError = "City is required.";
        public const string StateError = "State is required.";
        public const string ZipCodeError = "Zip Code is required.";
        public const string SsnError = "Social Security Number is required.";
        public const string UserNameError = "Username is required.";
        public const string PasswordError = "Password is required.";
        public const string PasswordConfirmError = "Password confirmation is required.";
        public const string PasswordsDontMatchError = "Passwords did not match.";
        public const string FirstName = "Hazim";
        public const string LastName = "Okanovic";
        public const string Address = "Sahmani";
        public const string City = "Zepce";
        public const string State = "BiH";
        public const string ZipCode = "4784378463";
        public const string PhoneNumber = "9382743987";
        public const string Ssn = "928732917";
        public const string AccountCreatedMessage = "Your account was created successfully. You are now logged in.";
        public const string NewAccountMessage = "Open New Account";
        public const string BankAccountCreatedMessage = "Congratulations, your account is now open.";
        public const string AccountsOverview = "Accounts Overview";
        public const string FourHundredDollars = "$400.00";
        public const string ThreeHundredDollars = "$300.00";
        public const string OneHundredDollars = "$100.00";
        public const string TwoHundredFiftyDollars = "$250.00";
        public const string HundredAndFiftyDollars = "$150.00";
        public const string Fifty = "50";
        public const string ZeroDollars = "$0.00";
        public const string TransferFunds = "Transfer Funds";
        public const string TransferComplete = "Transfer Complete!";
        public const string BillPaymentSuccess = "Bill Payment Complete";
        public const string AmountError = "The amount cannot be empty.";
        public const string AccountMismatch = "The account numbers do not match.";
        public const string AccountError = "Account number is required.";
        public const string PhoneNumberError = "Phone number is required.";
        public const string PayeeNameError = "Payee name is required.";
        public const string BillPaymentService = "Bill Payment Service";
        public const string Hundred = "100";
        public const string FindTransactions = "Find Transactions";
        public const string TransactionResults = "Transaction Results";
        public const string TransactionDetails = "Transaction Details";
        public const string ProfileUpdated = "Profile Updated";
        public const string UpdateProfile = "Update Profile";
        public const string RequestLoan = "Apply for a Loan";
        public const string FiftyK = "50000";
        public const string TwoHundred = "200";
        public const string LoanProcessed = "Loan Request Processed";

        public const string RequestDenied =
            "We cannot grant a loan in that amount with your available funds and down payment.";

        public const string TwoK = "2000";
        public const string RequestApproved = "Congratulations, your loan has been approved.";
        public const string ValidAccountNo = "1154";
    }
}