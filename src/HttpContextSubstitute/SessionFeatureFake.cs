using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace HttpContextSubstitute
{
    public class SessionFeatureFake : ISessionFeature
    {
        public ISession Session { get; set; }
    }
}
