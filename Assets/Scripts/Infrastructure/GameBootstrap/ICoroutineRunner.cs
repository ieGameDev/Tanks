using System.Collections;
using UnityEngine;

namespace Infrastructure.GameBootstrap
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}