﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Framework
{
    public interface IAggregateRoot
    {
        List<object> GetEvents();

        void ClearEvents();

        void Apply(object e);

        Guid Id { get; }

        int Version { get; }
    }
}
