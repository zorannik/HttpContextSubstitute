using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HttpContextSubstitute.Generic;
using Microsoft.AspNetCore.Http;
using NSubstitute;

namespace HttpContextSubstitute
{
    public class SessionMock : ISession, IContextMock<ISession>
    {
        public SessionMock()
        {
            this.Mock = Substitute.For<ISession>();
        }

        public ISession Mock { get; }

        public string Id => this.Mock.Id;

        public bool IsAvailable => this.Mock.IsAvailable;

        public IEnumerable<string> Keys => this.Mock.Keys;

        public void Clear() => this.Mock.Clear();

        public Task CommitAsync(CancellationToken cancellationToken = default) => this.Mock.CommitAsync(cancellationToken);

        public Task LoadAsync(CancellationToken cancellationToken = default) => this.Mock.LoadAsync(cancellationToken);

        public void Remove(string key) => this.Mock.Remove(key);

        public void Set(string key, byte[] value) => this.Mock.Set(key, value);

        public bool TryGetValue(string key, out byte[] value) => this.Mock.TryGetValue(key, out value);
    }
}