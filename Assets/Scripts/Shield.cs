using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] int maxHealth = 10;
    [SerializeField] int currentHealth;
    [SerializeField] float regenerationRate = 2f;
    [SerializeField] int regenerationAmount = 1;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        InvokeRepeating("Regenerate", regenerationRate, regenerationRate);
    }

    void Regenerate() {
        if (currentHealth < maxHealth)
            currentHealth += regenerationAmount;
        
        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }

        EventManager.TakeDamage(currentHealth / (float)maxHealth);
    }

    public void TakeDamage(int damage = 1) {
        currentHealth -= damage;

        if (currentHealth < 0) currentHealth = 0;

        EventManager.TakeDamage(currentHealth / (float)maxHealth);

        if (currentHealth < 1)
            GetComponent<Explosion>().BlowUp();
    }
}
