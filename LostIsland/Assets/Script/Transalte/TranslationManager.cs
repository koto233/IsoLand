using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TranslationManager : Singleton<TranslationManager>
{
    [SceneName]
    public string StartScene;

    private bool isFade;

    private bool canTran;

    public CanvasGroup fadeCanvasGroup;

    public float fadeDurtion;

    private void OnEnable()
    {
        EventHandle.GameStateChange += OnGameStateChange;
    }

    private void OnDisable()
    {
        EventHandle.GameStateChange -= OnGameStateChange;
    }

    private void OnGameStateChange(GameState gameState)
    {
        canTran = gameState == GameState.Play;
    }

    // private void Start()
    // {
    //     StartCoroutine(TransitionCor(string.Empty, StartScene));
    // }

    public void Transition(string from, string to)
    {
        if (!isFade && canTran) StartCoroutine(TransitionCor(from, to));
    }

    private IEnumerator TransitionCor(string from, string to)
    {
        yield return Fade(1);

        if (from != string.Empty)
        {
            EventHandle.CallBeforeSceneUnload();
            yield return SceneManager.UnloadSceneAsync(from);
        }
        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);

        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene (newScene);
        EventHandle.CallAfterSceneloaded();
        yield return Fade(0);
    }

    private IEnumerator Fade(float alpha)
    {
        isFade = true;
        fadeCanvasGroup.blocksRaycasts = true;
        float speed = Mathf.Abs(fadeCanvasGroup.alpha - alpha) / fadeDurtion;

        while (!Mathf.Approximately(fadeCanvasGroup.alpha, alpha))
        {
            fadeCanvasGroup.alpha =
                Mathf
                    .MoveTowards(fadeCanvasGroup.alpha,
                    alpha,
                    speed * Time.deltaTime);
            yield return null;
        }

        fadeCanvasGroup.blocksRaycasts = false;
        isFade = false;
    }
}
