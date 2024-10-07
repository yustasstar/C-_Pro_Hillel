﻿namespace SingleResponsibilityPrinciple.Validation
{
	public class ValidationNumber
	{
		public void Validate(string numberField)
		{
			if (!int.TryParse(numberField, out int result))
			{
				throw new Exception("The number is invalid!");
			}
		}
	}
}
