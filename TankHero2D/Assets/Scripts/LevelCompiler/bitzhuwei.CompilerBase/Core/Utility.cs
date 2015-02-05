using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    /// <summary>
    /// 
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// 判断给定的类型（或其父类型）是否实现了给定的接口
        /// </summary>
        /// <param name="checkingType"></param>
        /// <param name="interfaceType"></param>
        /// <returns></returns>
        public static bool ImplementedInterface(Type checkingType, Type interfaceType)
        {
            if (checkingType == null || interfaceType == null) return false;
            for (; checkingType != typeof(object); checkingType = checkingType.BaseType)
            {
                var interfaces = checkingType.GetInterfaces();
                if (interfaces != null && interfaces.Contains(interfaceType, _interfaceComparerInstance))
                    return true;
            }
            return false;
        }

        static InterfaceComparer _interfaceComparerInstance = new InterfaceComparer();
        
        class InterfaceComparer : IEqualityComparer<Type>
        {
            public bool Equals(Type x, Type y)
            {
                if (x == null && y == null) return true;
                if (x == null || y == null) return false;
                //if (x.FullName == y.FullName) return true;
                if (x.FullName.StartsWith(y.FullName)) return true;
                return false;
            }

            public int GetHashCode(Type obj)
            {
                return this.ToString().GetHashCode();
            }
        }
    }
