﻿// Copyright (c) Christof Senn. All rights reserved. See license.txt in the project root for license information.

using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Remote.Linq
{
    internal interface IAsyncQueryProvider : IQueryProvider
    {
        Task<TResult> ExecuteAsync<TResult>(Expression expression);
    }
}
