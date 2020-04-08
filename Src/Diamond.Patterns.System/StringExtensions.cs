﻿// ***
// *** Copyright(C) 2019-2020, Daniel M. Porrey. All rights reserved.
// *** 
// *** This program is free software: you can redistribute it and/or modify
// *** it under the terms of the GNU Lesser General Public License as published
// *** by the Free Software Foundation, either version 3 of the License, or
// *** (at your option) any later version.
// *** 
// *** This program is distributed in the hope that it will be useful,
// *** but WITHOUT ANY WARRANTY; without even the implied warranty of
// *** MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// *** GNU Lesser General Public License for more details.
// *** 
// *** You should have received a copy of the GNU Lesser General Public License
// *** along with this program. If not, see http://www.gnu.org/licenses/.
// *** 
using System;
using System.Security.Cryptography;
using System.Text;

namespace Diamond.Patterns.System
{
	public static class StringExtensions
	{
		/// <summary>
		/// Limits a string to the given length by truncating characters. If
		/// the string is less than the given length, the string is unmodified.
		/// </summary>
		/// <param name="text">The string to be truncated.</param>
		/// <param name="maxLength">The maximum length in characters of the string.</param>
		/// <returns>A new string that is no longer than maxLength in characters.</returns>
		public static string Limit(this string text, int maxLength)
		{
			string returnValue = String.Empty;

			if (text.Length > maxLength)
			{
				returnValue = text.Substring(0, maxLength);
			}
			else
			{
				returnValue = text;
			}

			return returnValue;
		}

		/// <summary>
		/// Encrypts a string that can only be decrypted on the same computer.
		/// </summary>
		/// <param name="value">The string to be encrypted.</param>
		/// <returns>A Base64 string containing the original string encrypted.</returns>
		public static string ProtectString(this string value, byte[] optionalEntropy = null)
		{
			string returnValue = String.Empty;

			byte[] data = ASCIIEncoding.UTF8.GetBytes(value);
			byte[] encryptedData = ProtectedData.Protect(data, optionalEntropy, DataProtectionScope.LocalMachine);
			returnValue = Convert.ToBase64String(encryptedData);

			return returnValue;
		}

		/// <summary>
		/// Decrypts a string that was encrypted on the same computer.
		/// </summary>
		/// <param name="encryptedValue">A Base64 encrypted string that was the result of a call
		/// to ProtectString().</param>
		/// <returns>The original (decrypted) string value.</returns>
		public static string UnprotectString(this string encryptedValue, byte[] optionalEntropy = null)
		{
			string returnValue = String.Empty;

			byte[] encryptedData = Convert.FromBase64String(encryptedValue);
			byte[] data = ProtectedData.Unprotect(encryptedData, optionalEntropy, DataProtectionScope.LocalMachine);
			returnValue = ASCIIEncoding.UTF8.GetString(data);

			return returnValue;
		}
	}
}
