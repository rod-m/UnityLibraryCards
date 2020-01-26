using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace UnityLibraryCards
{
    public static class EnumUtil {
        // easy grab a list of enum values
        public static IEnumerable<T> GetValues<T>() {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
    
   
}