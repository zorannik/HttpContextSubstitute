using System.Collections.Generic;
using HttpContextSubstitute.Generic;

namespace HttpContextSubstitute
{
    public interface IItemsDictionaryMock : IDictionary<object, object>, IContextMock<IDictionary<object, object>>
    {
    }
}
