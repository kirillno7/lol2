using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    [SerializeField] float MaxHealth = 100;

    public Action<float> HealthChanged;
    private float _currentHealth;

    public float MaxHealthGetter => MaxHealth;
    public float CurrentHealth  => _currentHealth;

    private void Awake()
    {
        _currentHealth = MaxHealth;
    }
   
   
   
    public void GetDamage(float Damage)
    {
        _currentHealth -= Damage;
        HealthChanged?.Invoke(_currentHealth);
        if (_currentHealth<=0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
