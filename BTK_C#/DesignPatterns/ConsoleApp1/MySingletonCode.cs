﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDesignPattern
{
    public class MySingletonCode<T> where T : class, new()
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                return _instance ??= new T();
            }
        }
    }
}
