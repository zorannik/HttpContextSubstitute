using System;
using System.Linq.Expressions;
using HttpContextSubstitute.Generic;
using NSubstitute;
using NSubstitute.ReceivedExtensions;

namespace HttpContextSubstitute.Tests
{
    public class PropertyGetUnitTest<TContextMock, TContext, TProperty> : UnitTest<TContextMock>
        where TContext : class
        where TContextMock : class, IContextMock<TContext>, TContext
    {
        private readonly Expression<Func<TContext, TProperty>> _getterExpression;
        private readonly Func<Quantity> _times;

        public PropertyGetUnitTest(Expression<Func<TContext, TProperty>> getterExpression, Func<Quantity> times = null)
        {
            _getterExpression = getterExpression;
            _times = times;
        }

        public override void Run(Func<TContextMock> targetFactory)
        {
            // Arrange
            var target = targetFactory.Invoke();

            // Act
            var x = _getterExpression.Compile().Invoke(target);

            // Assert
            x.Received(_times() ?? Quantity.Exactly(1));
        }
    }
}
