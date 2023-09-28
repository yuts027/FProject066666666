using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace FProjectCamping.Models.Infra
{
	public class PasswordHelper
	{
		public bool IsPasswordValid(string password)
		{
			string pattern = @"^(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
			return Regex.IsMatch(password, pattern);
		}

	}
}