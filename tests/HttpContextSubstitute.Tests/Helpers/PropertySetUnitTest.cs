using System;
using HttpContextSubstitute.Generic;
using NSubstitute;
using NSubstitute.ReceivedExtensions;

namespace HttpContextSubstitute.Tests
{
    public class PropertySetUnitTest<TContextMock, TContext> : UnitTest<TContextMock>
        where TContext : class
        where TContextMock : class, IContextMock<TContext>, TContext
    {
        private readonly Action<TContext> _setterExpression;
        private readonly Func<Quantity> _times;

        public PropertySetUnitTest(Action<TContext> setterExpression, Func<Quantity> times = null)
        {
            _setterExpression = setterExpression;
            _times = times;
        }

        public override void Run(Func<TContextMock> targetFactory)
        {
            // Arrange
            var target = targetFactory.Invoke();

            // Act
            _setterExpression.Invoke(target);

            // Assert
            target.Mock.Received(_times() ?? Quantity.Exactly(1));
        }
    }
}
