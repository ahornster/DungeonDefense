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

    public GameObject defenderHealthUI;
    public TextMeshProUGUI defenderHealthText;
    public float currentDefenderHealth = 100;
    public float totalDefenderHealth = 100;

    public GameObject moneyUI;
    public TextMeshProUGUI moneyText;
    public int moneyCount = 0;

    public GameObject directionalPromptUI;
    public TextMeshProUGUI directionalPromptText;

    public WaveController waveController;

    private void Awake()
    {
        
            waveText = waveUI.GetComponentInChildren<TextMeshProUGUI>();
            defenderHealthText = defenderHealthUI.GetComponentInChildren<TextMeshProUGUI>();
            moneyText = moneyUI.GetComponentInChildren<TextMeshProUGUI>();
            directionalPromptText = directionalPromptUI.GetComponentInChildren<TextMeshProUGUI>();

            if (waveController == null && this.GetComponent<WaveController>() != null)
            {
                waveController = this.GetComponent<WaveController>();
            }
        
    }
    // Start is called before the first frame update
    void Start() { }
    

    // Update is called once per frame
    void Update()
    {
        waveCount = waveController.currentWaveCount;
        waveTotal = waveController.totalWaveCount;

        UpdateUI();
    }

    void UpdateUI()
    {
        waveText.text = waveCount + " / " + waveTotal;

        defenderHealthText.text = currentDefenderHealth + " / " + totalDefenderHealth;

        moneyText.text = moneyCount.ToString();
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
