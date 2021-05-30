using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [Header("GAME OVER UI")]
    [SerializeField] private Canvas gameOverCanvas;
    [SerializeField] private Text   gameOverText;
    [SerializeField] private CanvasGroup gameOverMainContent;
    private CanvasGroup a;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        InitializeUI();
    }

    private void InitializeUI() {
        gameOverCanvas.enabled = false;
        gameOverText.CrossFadeAlpha(0.0f, 0.01f, true);
        gameOverMainContent.alpha = 0;
    }

    public IEnumerator GameOver(bool playerWin, float delay) {
        if (playerWin) {
            PlayerWin();
        }
        else {
            PlayerLose();
        }

        yield return new WaitForSeconds(delay);

        gameOverCanvas.enabled = true;
        gameOverText.CrossFadeAlpha(1.0f, 1.0f, true);

        yield return new WaitForSeconds(delay);
        yield return FadeAlpha(gameOverMainContent, 1.0f, delay);

        PlayerController.instance.LockCursor(false);
    }

    private void PlayerWin() {
        gameOverText.text = "You Win";
    }

    private void PlayerLose() {
        gameOverText.text = "You Lost";
    }

    private IEnumerator FadeAlpha(CanvasGroup canvasGroup, float targetAlpha, float duration) {
        float time = 0;

        while (time <= duration) {
            float t = time / duration;
            canvasGroup.alpha = t;
            time += Time.deltaTime;
            yield return null;
        }
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        InputManager.EnableInput(true);
    }
}
