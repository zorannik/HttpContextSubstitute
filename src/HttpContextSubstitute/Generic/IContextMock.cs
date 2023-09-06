using NSubstitute;

namespace HttpContextSubstitute.Generic
{
    public interface IContextMock<TMock> where TMock: class
    {
        public TMock Mock { get; }
    }
}
