using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Resources;

namespace Empires.Engine.Factories
{
    public class ResourceFactory
    {
        public Resource CreateResource(ResourceType type)
        {
            switch (type)
            {
                case ResourceType.Gold:
                    return new Gold();
                case ResourceType.Steel:
                    return new Steel();
                default:
                    throw new NotSupportedException("Unit type not supported.");
            }
        }
    }
}
