using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private UIManager uiManager;
    [Header("Game Over")]
    public GameObject gameOverScreen;
    public Text finishTime;

    [Header("Time")]
    public GameObject timerScreen;
    public Text timerText;
    private float startTime;
    private bool timer = false;
    private string minutes, seconds;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        //Timer
        if (timer)
        {
            float t = Time.time - startTime;
            minutes = ((int)t / 60).ToString();
            seconds = (t % 60).ToString("f2");

            timerText.text = "Time " + minutes + ":" + seconds;
        }
        else
            finishTime.text = "Time " + minutes + ":" + seconds;
    }
    private void OnCollisionExit(Collision collision)
    {
        //Start time when not touching the start platform
        if (collision.transform.tag == "Start")
        {
            timer = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //End time when touching the finsish platform
        if (collision.transform.tag == "Finish")
        {
            timer = false;
            EndGame();
        }
    }

    private void EndGame()
    {
        Invoke("ShowGameOverScreen", 1.25f);
    }

    private void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        timerScreen.SetActive(false);
    }
}
