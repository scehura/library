using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models
{
    public abstract class BaseModel
    {
        public void Parse<T>(T obj)
        {
            foreach (var prop in obj.GetType().GetProperties())
            {
                if (prop.GetValue(obj) != null)
                {
                    GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(obj));
                }
            }
        }
    }
}
