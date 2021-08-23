using System;
using System.Collections;
using System.Collections.Generic;
using TankDemo;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class UIController : MonoBehaviour
{
    [Inject(Id = "TankHealth")]
    private IHealth tankHealth;

    [Inject(Id = "TankHealthChangedEvent")]
    private UnityEvent tankHealthChangedEvent;

    [Inject(Id = "GameOverEvent")]
    private UnityEvent gameOverEvent;

    [Inject(Id = "RestartGameEvent")]
    private UnityEvent resartGameEvent;

    [SerializeField]
    private TMP_Text hpText;

    [SerializeField]
    private GameObject gameOverStatus;

    private void Awake()
    {
        tankHealthChangedEvent.AddListener(UpdateHP);
        gameOverEvent.AddListener(OnGameOver);
    }

    private void OnGameOver()
    {
        gameOverStatus.SetActive(true);
    }

    private void UpdateHP()
    {
        hpText.SetText($"HP: {tankHealth.Health}");
    }

    private void Update()
    {
        if (gameOverStatus.activeSelf && Input.anyKeyDown)
        {
            resartGameEvent.Invoke();
        } 
    }
}
