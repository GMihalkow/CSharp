﻿namespace SIS.MvcFramework
{
    using SIS.HTTP.Enums;
    using System;

    public abstract class HttpAttribute : Attribute
    {
        protected HttpAttribute(string path)
        {
            this.Path = path;
        }

        public string Path { get; }

        public abstract HttpRequestMethod Method { get; }
    }
}