using FluentAssertions;
using HttpContextSubstitute.Extensions;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using Xunit;

namespace HttpContextSubstitute.Samples;

public class RequestUrlSamples
{
    private const string scheme = "https";
    private const string host = "localhost";
    private const string path = "mocks";
    private const string query = "?assert=true";
    private readonly string url = $"{scheme}://{host}/{path}{query}";

    [Fact]
    public void MockEntireRequestUrl()
    {
        // Act
        var context = new HttpContextMock().SetupUrl(url);

        // Assert
        context.Request.Host.Host.Should().Be(host);
        context.Request.QueryString.ToString().Should().Be(query);
    }

    [Fact]
    public void MockRequestUrlProperties()
    {
        // Arrange
        var context = new HttpContextMock();

        // Act
        context.RequestMock.Scheme.Returns(scheme);
        context.RequestMock.Host.Returns(new HostString(host));

        // Assert
        context.Request.Scheme.Should().Be(scheme);
        context.Request.Host.ToString().Should().Be(host);
    }
}
