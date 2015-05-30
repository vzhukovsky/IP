using System;
using System.Collections.Generic;
using System.Linq;

namespace SecantMethod.TableServices
{
    public static class CloneableExtension
    {
        public static IList<T> Clone<T>(this IList<T> list) where T : ICloneable
        {
            return list.Select(item => (T)item.Clone()).ToList();

        }
    }
}