﻿// Copyright (c) Christof Senn. All rights reserved. See license.txt in the project root for license information.

using Remote.Linq.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Remote.Linq
{
    internal sealed partial class AsyncRemoteQueryable<T> : RemoteQueryable, IAsyncQueryable<T>
    {
        internal AsyncRemoteQueryable(Func<Expressions.Expression, Task<IEnumerable<DynamicObject>>> dataProvider)
            : base(typeof(T), dataProvider)
        {
        }

        internal AsyncRemoteQueryable(IAsyncQueryProvider provider, Expression expression)
            : base(typeof(T), provider, expression)
        {
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (_provider.Execute<IEnumerable<T>>(_expression)).GetEnumerator();
        }

        public async Task<IEnumerable<T>> ExecuteAsync()
        {
            return await ((IAsyncQueryProvider)_provider).ExecuteAsync<IEnumerable<T>>(_expression);
        }
    }
}
