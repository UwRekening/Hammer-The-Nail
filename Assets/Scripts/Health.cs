using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public float health = 100;
    private float currentHealth;
    
    void Start() => currentHealth = health;

    public void ReceiveDamage(float amount) {
        currentHealth -= amount;
        if (currentHealth <= 0) {
            currentHealth = 0;
            return;
        }
        Debug.Log($"<color=red>{amount} damage taken for {gameObject.name}</color>");
    }
    
    public float GetHealth => currentHealth;
}
