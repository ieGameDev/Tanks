using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.GameBootstrap
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutine;

        public SceneLoader(ICoroutineRunner coroutine) =>
            _coroutine = coroutine;

        public void Load(string name, Action onLoaded = null) =>
            _coroutine.StartCoroutine(LoadScene(name, onLoaded));

        public IEnumerator LoadScene(string nextScene, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

            while (!waitNextScene.isDone)
                yield return null;

            onLoaded?.Invoke();
        }
    }
}