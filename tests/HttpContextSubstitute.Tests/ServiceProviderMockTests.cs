using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using Xunit;

namespace HttpContextSubstitute.Tests
{
    public class ServiceProviderMockTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void ServiceProviderMock_WhenRun_AssertTrue(UnitTest<ServiceProviderMock> unitTest)
        {
            unitTest.Run(() => new ServiceProviderMock());
        }

        public static IEnumerable<object[]> Data =>
            new UnitTest<ServiceProviderMock>[]
            {
                //Class
                new ContextMockUnitTest<ServiceProviderMock, IServiceProvider>(),
                //Methods
                new MethodInvokeUnitTest<ServiceProviderMock, IServiceProvider>(
                    t => t.GetService(Fakes.Type)
                ),
            }.ToData();
    }
}
