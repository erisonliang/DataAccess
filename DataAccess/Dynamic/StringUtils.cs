﻿using System.Globalization;

namespace DbParallel.DataAccess
{
	public static class StringUtils
	{
		public static string DeunderscoreFieldName(this string fieldName, bool camelCase = false)
		{
			if (string.IsNullOrEmpty(fieldName))
				return fieldName;

			if (fieldName.Length == 1)
				if (camelCase && char.IsUpper(fieldName[0]))
					return fieldName.ToLower(CultureInfo.InvariantCulture);
				else
					return fieldName;

			char[] pascalChars = new char[fieldName.Length];
			int cntUpper = 0, cntLower = 0, lenFragment = 0, lenPascal = 0;

			foreach (char c in fieldName)
			{
				if (char.IsUpper(c))
				{
					pascalChars[lenPascal] = (lenFragment == 0) ? c : char.ToLower(c, CultureInfo.InvariantCulture);
					lenPascal++;
					lenFragment++;
					cntUpper++;
				}
				else if (char.IsLower(c))
				{
					pascalChars[lenPascal] = (lenFragment == 0) ? char.ToUpper(c, CultureInfo.InvariantCulture) : c;
					lenPascal++;
					lenFragment++;
					cntLower++;
				}
				else if (char.IsPunctuation(c) || char.IsWhiteSpace(c))
				{
					lenFragment = 0;
				}
				else
				{
					pascalChars[lenPascal] = c;
					lenPascal++;
					lenFragment = 0;
				}
			}

			if (lenPascal == 0)
				return string.Empty;
			else
				if (camelCase)
				{
					if (char.IsUpper(pascalChars[0]))
						pascalChars[0] = char.ToLower(pascalChars[0], CultureInfo.InvariantCulture);

					return new string(pascalChars, 0, lenPascal);
				}
				else
					return (cntUpper > 0 && cntLower > 0) ? fieldName : new string(pascalChars, 0, lenPascal);
		}

		internal static string CompactFieldName(this string fieldName, bool toUpper = false, bool toLower = false)
		{
			if (string.IsNullOrEmpty(fieldName))
				return fieldName;

			char[] compactedChars = new char[fieldName.Length];
			int compactedLength = 0;

			foreach (char c in fieldName)
				if (char.IsPunctuation(c) || char.IsWhiteSpace(c))
					continue;
				else
				{
					if (toUpper && char.IsLower(c))
						compactedChars[compactedLength] = char.ToUpper(c, CultureInfo.InvariantCulture);
					else if (toLower && char.IsUpper(c))
						compactedChars[compactedLength] = char.ToLower(c, CultureInfo.InvariantCulture);
					else
						compactedChars[compactedLength] = c;

					compactedLength++;
				}

			return (compactedLength == 0) ? string.Empty : new string(compactedChars, 0, compactedLength);
		}
	}
}

////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Copyright 2015 Abel Cheng
//	This source code is subject to terms and conditions of the Apache License, Version 2.0.
//	See http://www.apache.org/licenses/LICENSE-2.0.
//	All other rights reserved.
//	You must not remove this notice, or any other, from this software.
//
//	Original Author:	Abel Cheng <abelcys@gmail.com>
//	Created Date:		2015-03-09
//	Original Host:		http://dbParallel.codeplex.com
//	Primary Host:		http://DataBooster.codeplex.com
//	Change Log:
//	Author				Date			Comment
//
//
//
//
//	(Keep code clean rather than complicated code plus long comments.)
//
////////////////////////////////////////////////////////////////////////////////////////////////////