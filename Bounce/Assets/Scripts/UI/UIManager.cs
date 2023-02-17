using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject timerDisplay;
    [SerializeField] private GameObject gameOverScreen;

    private float startTime, elapsedTime;
    public bool gamePlaying { get; private set; }
    TimeSpan timePlaying;

    private void Start()
    {
        gamePlaying = true;
    }
}
