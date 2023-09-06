using System;
using HttpContextSubstitute.Generic;
using NSubstitute;

namespace HttpContextSubstitute
{
    public class ServiceProviderMock : IServiceProvider, IContextMock<IServiceProvider>
    {
        public ServiceProviderMock()
        {
            this.Mock = new Mock<IServiceProvider>();
        }

        public Mock<IServiceProvider> Mock { get; }

        public object GetService(Type serviceType) => this.Mock.Object.GetService(serviceType);
    }
}