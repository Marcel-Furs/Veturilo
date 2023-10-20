using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veturilo.Application.Exceptions
{
    public class ItemNotExistsException : Exception
    {
        public ItemNotExistsException(int id, string type) : base($"Item of type {type} with id {id} not exists")
        {
        }
    }
}
