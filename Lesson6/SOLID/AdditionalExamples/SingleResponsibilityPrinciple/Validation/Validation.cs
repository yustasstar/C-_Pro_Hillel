namespace SingleResponsibilityPrinciple.Validation
{
	public class Validation
	{
		private readonly ValidationText _validationText;
		private readonly ValidationEmail _validationEmail;
		private readonly ValidationNumber _validationNumber;

		public Validation(ValidationText validationText, ValidationEmail validationEmail, ValidationNumber validationNumber)
		{
			_validationText = validationText;
			_validationEmail = validationEmail;
			_validationNumber = validationNumber;
		}

		public string ValidateForm(string firstName, string lastName, string email, string age)
		{
			try
			{
				_validationText.Validate(firstName);
				_validationText.Validate(lastName);
				_validationEmail.Validate(email);
				_validationNumber.Validate(age);

				return "Validation successfully!";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
	}
}