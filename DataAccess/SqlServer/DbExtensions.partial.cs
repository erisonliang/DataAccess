﻿using System.Data.Common;
using System.Data.SqlClient;

namespace DbParallel.DataAccess
{
	static partial class DbExtensions
	{
		public static SqlBulkCopyColumnMapping Add(this SqlBulkCopyColumnMappingCollection columnMappings, string destinationColumn)
		{
			return columnMappings.Add(columnMappings.Count, destinationColumn);
		}

		public static SqlParameter AsSqlParameter(this DbParameter sqlParameter)
		{
			return sqlParameter as SqlParameter;
		}
	}
}

////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Copyright 2012 Abel Cheng
//	This source code is subject to terms and conditions of the Apache License, Version 2.0.
//	See http://www.apache.org/licenses/LICENSE-2.0.
//	All other rights reserved.
//	You must not remove this notice, or any other, from this software.
//
//	Original Author:	Abel Cheng <abelcys@gmail.com>
//	Created Date:		2013-08-06
//	Original Host:		http://dbParallel.codeplex.com
//	Primary Host:		http://DataBooster.codeplex.com
//	Updated Host:		https://github.com/DataBooster/DataAccess
//	Change Log:
//	Author				Date			Comment
//
//
//
//
//	(Keep code clean rather than complicated code plus long comments.)
//
////////////////////////////////////////////////////////////////////////////////////////////////////
