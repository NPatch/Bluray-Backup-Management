using System.Collections;
using System.Runtime.InteropServices;
using System;

namespace BlurayBackupManagement.Entities
{
    public class Singleton<T> where T : new()
    {
        private static T _Instance;

        private static object _Lock = new object();

        protected static bool _ApplicationQuitting = false;

        public static T Instance
        {
            get
            {
                if (_ApplicationQuitting)
                {
                    System.Diagnostics.Debug.WriteLine("Application in the process of quiting.This reference should never have been.");
                }

                lock (_Lock)
                {
                    if (_Instance == null)
                    {
                        _Instance = (T)(new T());
                    }

                    return _Instance;
                }
            }
        }
    }
}