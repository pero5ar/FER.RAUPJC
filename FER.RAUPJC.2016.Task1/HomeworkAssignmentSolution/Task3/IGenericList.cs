using System.Collections.Generic;

namespace Task3
{
    public interface IGenericList<X> : Task2.IGenericList<X>, IEnumerable<X>
    {
    }
}
