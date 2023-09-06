using System;
using System.Linq.Expressions;
using HttpContextSubstitute.Generic;
using NSubstitute;
using NSubstitute.ReceivedExtensions;

namespace HttpContextSubstitute.Tests
{
    public class MethodInvokeUnitTest<TContextMock, TContext> : UnitTest<TContextMock>
        where TContext : class
        where TContextMock : class, IContextMock<TContext>, TContext
    {
        private readonly Expression<Action<TContext>> _invokeExpression;
        private readonly Func<Quantity> _times;

        public MethodInvokeUnitTest(Expression<Action<TContext>> invokeExpression, Func<Quantity> times = null)
        {
            _invokeExpression = invokeExpression;
            _times = times;
        }

        public override void Run(Func<TContextMock> targetFactory)
        {
            // Arrange
            var target = targetFactory.Invoke();

            // Act
            _invokeExpression.Compile().Invoke(target);

            // Assert
            target.Mock.Verify(_invokeExpression, _times ?? Times.Once);
        }
    }
}
