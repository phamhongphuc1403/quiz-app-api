﻿using System.Collections;

namespace quiz_app_api.src.Core.Ultils
{
    public class Optional
    {
        private dynamic _instance;
        private Optional(dynamic instance)
        {
            _instance = instance;
        }
        public static Optional Of(dynamic? instance)
        {
            return new Optional(instance);
        }
        public void ThrowIfPresent(Exception exception)
        {
            if ((this._instance is IEnumerable && this._instance.Count > 0) || (this._instance is not IEnumerable && this._instance != null))
            {
                throw exception;
            }
        }
        public Optional ThrowIfNotPresent(Exception exception)
        {
            if ((this._instance is IEnumerable && this._instance.Count == 0) || (this._instance is not IEnumerable && this._instance == null))
            {
                throw exception;
            }
            return this;
        }
        public dynamic Get()
        {
            return this._instance;
        }
    }
}
