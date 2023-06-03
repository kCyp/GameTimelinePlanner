using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTimelinePlanner.Shared.Domain.Interface
{
    public interface IIdentifiable<TypeId>
    {
        TypeId Id { get; }
    }
}
