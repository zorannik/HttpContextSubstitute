﻿using Microsoft.AspNetCore.Http;

namespace HttpContextSubstitute
{
    public class HttpContextAccessorMock : IHttpContextAccessor
    {
        public HttpContextAccessorMock()
         : this(new HttpContextMock())
        {
        }

        public HttpContextAccessorMock(HttpContext context)
        {
            this.HttpContext = context;
        }

        public HttpContextMock HttpContextMock
        {
            get => this.HttpContext as HttpContextMock;
            set
            {
                this.HttpContext = value;
            }
        }

        public HttpContext HttpContext { get; set; }
    }
}
