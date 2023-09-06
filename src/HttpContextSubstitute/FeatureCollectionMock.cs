using System;
using System.Collections;
using System.Collections.Generic;
using HttpContextSubstitute.Generic;
using Microsoft.AspNetCore.Http.Features;
using NSubstitute;

namespace HttpContextSubstitute
{
    public class FeatureCollectionMock : IFeatureCollection, IContextMock<IFeatureCollection>
    {
        public FeatureCollectionMock()
        {
            this.Mock = Substitute.For<IFeatureCollection>();
        }

        public IFeatureCollection Mock { get; }

        public object this[Type key]
        {
            get => this.Mock.Object[key];
            set => this.Mock.Object[key] = value;
        }

        public bool IsReadOnly => this.Mock.IsReadOnly;

        public int Revision => this.Mock.Revision;

        public TFeature Get<TFeature>() => this.Mock.Get<TFeature>();

        public IEnumerator<KeyValuePair<Type, object>> GetEnumerator() => this.Mock.GetEnumerator();

        public void Set<TFeature>(TFeature instance) => this.Mock.Get<TFeature>().Returns(instance);

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this.Mock).GetEnumerator();
    }
}