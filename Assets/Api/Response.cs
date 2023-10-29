using System;
using UnityEngine;
using System.Collections;
namespace Duelno.Api
{

    public class Response<T> : CustomYieldInstruction where T : new()
    {
        private T _data;
        internal IEnumerator _coroutineRef;


        protected event System.Action onDone;

        public override bool keepWaiting => !isDone;

        public string message { get; internal set; }
        public bool isFail { get; internal set; }
        public bool isSuccess => !isFail;

        public bool isDone { get; internal set; }

        /// <summary>
        /// Only available if the response is done and the request is successful
        /// </summary>
        public T data
        {
            get
            {
                if (!isDone)
                    throw new System.Exception("Data is not ready yet");
                if (isFail)
                    throw new System.Exception("the request is failed");
                return _data;
            }
            set
            {
                _data = value;
            }
        }



        internal void _InvokeOnDone()
        {
            onDone?.Invoke();
        }

        public Response<T> OnDone(Action<Response<T>> action)
        {
            onDone += () => action(this);
            return this;
        }


    }

}