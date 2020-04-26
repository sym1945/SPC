using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Documents;

namespace SPC.Core
{
    public static class SPCContainer
    {
        private static readonly Dictionary<Type, SPCBase> _SPCs = new Dictionary<Type, SPCBase>();

        private static readonly Dictionary<Type, object> _Sigletons = new Dictionary<Type, object>();
        

        public static T GetSPC<T>()
            where T : SPCBase
        {
            lock (_SPCs)
            {
                var spcType = typeof(T);
                if (_SPCs.TryGetValue(spcType, out SPCBase spc))
                    return (T)spc;
                else
                    return null;
            }
        }

        public static void SetSPC(SPCBase spc)
        {
            lock (_SPCs)
            {
                var spcType = spc.GetType();
                if (_SPCs.ContainsKey(spcType))
                    _SPCs[spcType] = spc;
                else
                    _SPCs.Add(spcType, spc);
            }
        }

        public static void AddSingleton<T>(T data = null)
            where T : class, new()
        {
            lock (_Sigletons)
            {
                var dataType = typeof(T);
                if (data == null)
                    data = (T)Activator.CreateInstance(dataType);

                if (_Sigletons.ContainsKey(dataType))
                    _Sigletons[dataType] = data;
                else
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
