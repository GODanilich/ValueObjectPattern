using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Value_Object
{
    public class Storage
    {
        public Dictionary<Name, Password> AuthorizationDict;
        public Dictionary<Name, Address> AdressDict;


        public Dictionary<string, string> StorageDictW; //without pattern

        public static Storage Instance {  get; private set; }
        
        public Storage() 
        {
            if (Instance != null) { throw new Exception(); }
            Instance = this;
            AuthorizationDict = new Dictionary<Name, Password>();
            AdressDict = new Dictionary<Name, Address>();
            StorageDictW = new Dictionary<string, string>();
        }
    }
}
