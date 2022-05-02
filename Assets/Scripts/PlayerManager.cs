using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Text _playerHealthText;
             
    private static int _playerHealth;
    private static bool _gameOver;
    
    void Start()
    {
        _playerHealth = 100;
        _gameOver = false;
    }

    private void CheckGameOver()
    {
        if (_gameOver)
            SceneManager.LoadScene("TestLevel");
    }

    private void ViewTextHealth(int health)
    {
        _playerHealthText.text = health.ToString();
    }

    void Update()
    {
        CheckGameOver();
        ViewTextHealth(_playerHealth);
    }

    public static void SetDamage(int damageCount)
    {
        _playerHealth -= damageCount;

        if (_playerHealth <= 0)
            _gameOver = true;
    }
}
