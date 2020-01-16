using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.Contracts
{
    public interface IEventService
    {
        Event GetEvents(GetEventModel model);        
    }
}
