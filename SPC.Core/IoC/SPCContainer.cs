using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Documents;

namespace SPC.Core
{
    public static class SPCContainer
    {
        private static SPC Instance;

        private static readonly Dictionary<Type, object> _Sigletons = new Dictionary<Type, object>();

        public static SPC GetSPC()
        {
            return Instance;
        }

        public static T GetSPC<T>()
            where T : SPC
        {
            //TODO: SPC 타입별로 관리
            return (T)Instance;
        }

        public static void SetSPC(SPC spc)
        {
            Instance = spc;
        }

        public static void AddSingleton<T>(T data = null)
            where T : class, new()
        {
            lock (_Sigletons)
            {
                var dataType = typeof(T);
                if (data == null)
                    data = (T)Activator.CreateInstance(dataType);

                _Sigletons.Add(dataType, data);
            }
        }

        public static T GetSingleton<T>()
            where T : class, new()
        {
            var data = GetSingleton(typeof(T));
            if (data != null)
                return (T)data;
            else
                return null;
        }

        public static object GetSingleton(Type type)
        {
            lock (_Sigletons)
            {
                if (_Sigletons.TryGetValue(type, out object data))
                    return data;
                else
                    return null;
            }
        }


    }
}
