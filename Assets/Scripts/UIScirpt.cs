using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScirpt : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;
    [Header("Score Keeper")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {
        healthSlider.maxValue = playerHealth.GetCurrentHealth();
        scoreKeeper.ResetScore();
        scoreText.text = scoreKeeper.GetCurrentScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = playerHealth.GetCurrentHealth();
        scoreText.text = scoreKeeper.GetCurrentScore().ToString("0000000");
    }
}
