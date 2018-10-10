﻿using System;

namespace SIS.HTTP.Cookies
{
    using Common;

    public class HttpCookie
    {
        private const int HttpCookieDefaultExpirationDays = 3;
        private const string DefaultPath = "/";

        public HttpCookie(string key, string value, int expires = HttpCookieDefaultExpirationDays)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CoreValidator.ThrowIfNullOrEmpty(value, nameof(value));

            this.Key = key;
            this.Value = value;
            this.IsNew = true;
            this.Expires = DateTime.UtcNow.AddDays(expires);
            this.Path = DefaultPath;
        }

        public HttpCookie(string key, string value, bool isNew, int expires = HttpCookieDefaultExpirationDays)
            : this(key, value, expires)
        {
            this.IsNew = isNew;
        }

        public string Key { get; }

        public string Value { get; }

        public string Path { get; set; }

        public DateTime Expires { get; private set; }

        public bool IsNew { get; }

        public bool HttpOnly { get; set; } = true;

        public void Delete()
        {
            this.Expires = DateTime.UtcNow.AddDays(-1);
        }

        public override string ToString()
        {
            var str = $"{this.Key}={this.Value}; Expires={this.Expires:R}";
            if (this.HttpOnly)
            {
                str += "; HttpOnly";
            }

            str += $"; Path={this.Path}";

            return str;
        }
    }
}
