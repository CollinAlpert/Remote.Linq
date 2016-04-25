﻿// Copyright (c) Christof Senn. All rights reserved. See license.txt in the project root for license information.

#if !NET35

namespace Remote.Linq
{
    public interface IAsyncRemoteQueryable : IRemoteQueryable
    {
    }

    public interface IOrderedAsyncRemoteQueryable : IAsyncRemoteQueryable, IOrderedRemoteQueryable
    {
    }
}

#endif