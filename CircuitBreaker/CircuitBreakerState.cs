﻿using System;
using System.Threading.Tasks;

namespace CircuitBreaker
{
    public abstract class CircuitBreakerState
    {
        protected readonly CircuitBreaker CircuitBreaker;

        protected CircuitBreakerState(CircuitBreaker circuitBreaker) => CircuitBreaker = circuitBreaker;
        
        public virtual CircuitBreakerState InvocationSucceeds() => this;

        public virtual CircuitBreakerState InvocationFails(Exception e) => this;

        public abstract void Execute(Action action);
        public abstract T Execute<T>(Func<T> func);

        public abstract Task ExecuteAsync(Func<Task> func);
        public abstract Task<T> ExecuteAsync<T>(Func<Task<T>> func);
    }
}