using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Zenject;

namespace TankDemo
{
    public class GameManager : MonoBehaviour
    {
        [Inject(Id = "RestartGameEvent")]
        private UnityEvent resartGameEvent;

        private void Awake()
        {
            resartGameEvent.AddListener(OnRestartGame);
        }

        private void OnRestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
