﻿using System;
using System.Collections.Generic;

namespace HuaweiMobileServices.Utils
{
    static class ListUtils
    {

        public static IList<U> Map<T, U>(this IList<T> list, Func<T, U> action)
        {
            var newList = new List<U>();
            foreach(T element in list)
            {
                newList.Add(action.Invoke(element));
            }
            return newList;
        }
    }
}