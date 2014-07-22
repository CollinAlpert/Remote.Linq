﻿// Copyright (c) Christof Senn. All rights reserved. See license.txt in the project root for license information.

using Remote.Linq.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Remote.Linq
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Creates an instance of <see cref="IQueryable{T}" /> that utilizes the data provider specified
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource"></param>
        /// <param name="dataProvider"></param>
        /// <returns></returns>
        public static IQueryable<T> AsQueryable<T>(this IEnumerable<T> resource, Func<Expressions.Expression, IEnumerable<DynamicObject>> dataProvider)
        {
            return RemoteQueryable.Create<T>(dataProvider);
        }

        /// <summary>
        /// Applies this query instance to an enumerable
        /// </summary>
        /// <param name="queriable"></param>
        /// <returns></returns>
        public static IEnumerable<TEntity> ApplyQuery<TEntity>(this IEnumerable<TEntity> enumerable, Query<TEntity> query)
        {
            return enumerable
                .AsQueryable()
                .ApplyQuery(query)
                .AsEnumerable();
        }

        /// <summary>
        /// Applies this query instance to an enumerable
        /// </summary>
        /// <param name="queriable"></param>
        /// <returns></returns>
        public static IEnumerable<TEntity> ApplyQuery<TEntity>(this IEnumerable<TEntity> enumerable, Query query)
        {
            return enumerable
                .AsQueryable()
                .ApplyQuery(query)
                .AsEnumerable();
        }
    }
}