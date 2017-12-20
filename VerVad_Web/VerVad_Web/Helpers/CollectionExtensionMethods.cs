using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerVad_Web.Helpers
{
    public static class CollectionExtensionMethods 
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> genericEnumerable)
        {
            return ((genericEnumerable == null) || (!genericEnumerable.Any()));
        }        
    }
}