﻿namespace HuaweiMobileServices.Utils
{
    using UnityEngine;

    // Wrapper for android.accounts.Account
    public class AndroidAccountWrapper : JavaObjectWrapper
    {

        internal AndroidAccountWrapper(AndroidJavaObject javaObject) : base(javaObject) { }

        public virtual AndroidJavaObject Account
        {
            get => JavaObject;
        }
    }
}
