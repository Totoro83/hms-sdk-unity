namespace HuaweiMobileServices.Utils
{
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class JavaObjectWrapper
    {
        
        public JavaObjectWrapper(AndroidJavaObject javaObject)
        {
            JavaObject = javaObject;
        }

        internal protected JavaObjectWrapper(string javaObjectCanonicalName, params object[] args)
        {
            JavaObject = new AndroidJavaObject(javaObjectCanonicalName, args);
        }

        private static object[] AsAutoParams(object[] args)
        {
            var newArgs = new object[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                var arg = args[i];
                if (arg is JavaObjectWrapper)
                {
                    newArgs[i] = (arg as JavaObjectWrapper).JavaObject;
                }
                else if (arg is string)
                {
                    newArgs[i] = (arg as string).AsJavaString();
                }
                else
                {
                    newArgs[i] = arg;
                }
            }
            return newArgs;
        }

        internal protected virtual AndroidJavaObject JavaObject { get; set; }

        internal protected T Call<T>(string methodName, params object[] args) => JavaObject.Call<T>(methodName, AsAutoParams(args));

        internal protected void Call(string methodName, params object[] args) => JavaObject.Call(methodName, AsAutoParams(args));

        internal protected string CallAsString(string methodName, params object[] args) =>
            Call<AndroidJavaObject>(methodName, args).AsString();

        internal protected T CallAsWrapper<T>(string methodName, params object[] args) where T : JavaObjectWrapper =>
            Call<AndroidJavaObject>(methodName, args).AsWrapper<T>();

        internal protected string CallAsUriString(string methodName, params object[] args) =>
            Call<AndroidJavaObject>(methodName, args).Call<AndroidJavaObject>("toString").AsString();

        internal protected IList<T> CallAsWrapperList<T>(string methodName, params object[] args) where T : JavaObjectWrapper =>
            Call<AndroidJavaObject>(methodName, args).AsListFromWrappable<T>();

        internal protected T[] CallAsWrapperArray<T>(string methodName, params object[] args) where T : JavaObjectWrapper =>
            Call<AndroidJavaObject>(methodName, args).AsArray<T>();
    }
}
