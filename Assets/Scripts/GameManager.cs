using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    [SerializeField] GameObject secondElapsedText;
    private TextMeshProUGUI secondElapsedTMP;
    [SerializeField] private int alertRemainingSeconds = 60;
    [SerializeField] GameObject canvasGameOver;
    [SerializeField] GameObject player;
    private Vector3 amount = new Vector3(.5f, .5f, .5f);
    private float time = 1.5f;
    private bool animationStarted = false;
    public bool IsGameOver { get; set; } = false;
    private bool gameOverInitiated = false;
    public bool IsBrushTaken { get; set; } = false;
    [SerializeField] private int remainingSeconds = 180;
    public static GameManager Instance {get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            secondElapsedTMP = secondElapsedText.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void Start()
    {
       
        UpdateElapsedTimeText();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverInitiated)
            return;
        if (IsGameOver)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SceneParametersStatic.AutoSkipDialogsBegin = false;
        gameOverInitiated = true;
        Debug.Log("Game Over");
        Time.timeScale = 0;
        canvasGameOver.SetActive(true);
       // 
    }
    
    
    public IEnumerator StartElapsedTime()
    {
        while (!IsGameOver && !IsBrushTaken)
        {
            yield return new WaitForSeconds(1f);
            remainingSeconds--;
            UpdateElapsedTimeText();
            if (remainingSeconds <= 0)
            {
                IsGameOver = true;
            }
        }
        Debug.Log("Time : " + GetElapsedTimeText());
    }

    private string GetElapsedTimeText()
    {
        if(remainingSeconds < 60)
            return remainingSeconds.ToString("00");
        else
        {
            float minutes = remainingSeconds / 60;
            float seconds = remainingSeconds % 60;
            return minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void UpdateElapsedTimeText()
    {
        secondElapsedTMP.text = GetElapsedTimeText();
        if (remainingSeconds < alertRemainingSeconds)
        {
            secondElapsedTMP.color = Color.red;
            if(!animationStarted)
                AnimateElapsedTime();
        }
    }

    private void AnimateElapsedTime()
    {
        //float randomTime = Random.Range(time - 0.5f, time + 0.5f);
        iTween.PunchScale(secondElapsedText, iTween.Hash(
            "amount", amount,
            "time", 1f,
            "looptype", iTween.LoopType.loop
        ));
        animationStarted = true;
    }
}
