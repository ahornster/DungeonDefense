using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    public GameObject waveUI;
    public TextMeshProUGUI waveText;
    public int waveCount = 1;
    public int waveTotal = 10;

    public GameObject enemyCountUI;
    public TextMeshProUGUI enemyCountText;
    public int enemyCount;

    public GameObject defenderChest;
    public GameObject defenderHealthUI;
    public TextMeshProUGUI defenderHealthText;
    public Slider healthSlider;
    public float currentDefenderHealth = 100;
    public float totalDefenderHealth = 100;

    public GameObject moneyUI;
    public TextMeshProUGUI moneyText;
    public int moneyCount = 0;

    public GameObject directionalPromptUI;
    public TextMeshProUGUI directionalPromptText;

    public WaveController waveController;
    public SceneController sceneController;

    public float endGameDelay = 5;
    private float endCountDown;
    public bool endTimerStarted = false;

    private void Awake()
    {
        
            waveText = waveUI.GetComponentInChildren<TextMeshProUGUI>();
            defenderHealthText = defenderHealthUI.GetComponentInChildren<TextMeshProUGUI>();
            moneyText = moneyUI.GetComponentInChildren<TextMeshProUGUI>();
            directionalPromptText = directionalPromptUI.GetComponentInChildren<TextMeshProUGUI>();
            enemyCountText = enemyCountUI.GetComponentInChildren<TextMeshProUGUI>();

        if (waveController == null && this.GetComponent<WaveController>() != null)
            {
                waveController = this.GetComponent<WaveController>();
            }
        
    }
    // Start is called before the first frame update
    void Start() 
    {
        sceneController = GameObject.FindWithTag("SceneManager").GetComponent<SceneController>();

        currentDefenderHealth = totalDefenderHealth;
        healthSlider.maxValue = totalDefenderHealth;
        healthSlider.value = currentDefenderHealth;

    }
    

    // Update is called once per frame
    void Update()
    {
        waveCount = waveController.currentWaveCount;
        waveTotal = waveController.totalWaveCount;
        enemyCount = waveController.currentEnemyCount;

        if (currentDefenderHealth <= 0)
        {
            currentDefenderHealth = 0;

            if(defenderChest != null)
            {
                Destroy(defenderChest);
            }
            

            if (!endTimerStarted)
            {
                endCountDown = Time.time;
                endTimerStarted = true;
            }

            DisplayDirectionalPrompt("Your chest has been broken and treasures stolen, game will end in: " + (endGameDelay - (Time.time - endCountDown)).ToString("0.00"));

            if (endTimerStarted && (endGameDelay - (Time.time - endCountDown)) <= 0)
            {
                sceneController.LoadLose();
            }
        }

        if (waveController.currentWaveCount == waveController.totalWaveCount && waveController.currentEnemyCount == 0)
        {
            if (!endTimerStarted)
            {
                endCountDown = Time.time;
                endTimerStarted = true;
            }

            DisplayDirectionalPrompt("All waves defeated, game will end in: " + (endGameDelay - (Time.time - endCountDown)).ToString("0.00"));

            if (endTimerStarted && (endGameDelay - (Time.time - endCountDown)) <= 0)
            {
                sceneController.LoadWin();
            }
        }


        UpdateUI();
    }

    void UpdateUI()
    {
        waveText.text = waveCount + " / " + waveTotal;

        defenderHealthText.text = currentDefenderHealth + " / " + totalDefenderHealth;

        moneyText.text = moneyCount.ToString();

        enemyCountText.text = "Enemies Remaining: " +enemyCount;

        healthSlider.value = currentDefenderHealth;
    }

    public void UpdateWaveCount()
    {
        waveCount++;
    }

    public void AddMoney(int addAmount)
    {
        moneyCount += addAmount;
    }

    public void SubtractMoney(int subtractAmount)
    {
        moneyCount -= subtractAmount;
    }

    public void DamageDefenderHealth(int damage)
    {
        currentDefenderHealth -= damage;
    }

    public void DisplayDirectionalPrompt(string promptContents)
    {
        directionalPromptUI.SetActive(true);
        directionalPromptText.text = promptContents;
    }

    public void HideDirectionalPrompt()
    {
        directionalPromptUI.SetActive(false);
    }
}
