using System.Collections.Generic;

namespace Mvvm.Services
{
    public class Scope 
    {
        private static Dictionary<string, object> scope = new Dictionary<string, object>();

        private Scope()
        {}

        public static Scope Current = new Scope();

        public object this[string index]
        {
            get { return scope[index]; }
            set { scope[index] = value; }
        }
    }
}
