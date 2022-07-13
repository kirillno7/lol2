using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBAr : MonoBehaviour
{
    [SerializeField] HealthController HealthController;
    [SerializeField] Text Text;
    [SerializeField] Image Image;

    private float _maxHealth; 
    void Start()
    {
        _maxHealth = HealthController.MaxHealthGetter;
        HealthController.HealthChanged += OnHealthChanged;
        OnHealthChanged(HealthController.CurrentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnHealthChanged(float health)
    {
        Image.fillAmount = health / _maxHealth;
        Text.text = health.ToString();
    }
}
