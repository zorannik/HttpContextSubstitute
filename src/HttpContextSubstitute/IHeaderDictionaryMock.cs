using HttpContextSubstitute.Generic;
using Microsoft.AspNetCore.Http;

namespace HttpContextSubstitute
{
    public interface IHeaderDictionaryMock : IHeaderDictionary, IContextMock<IHeaderDictionary>
    {
    }
}
