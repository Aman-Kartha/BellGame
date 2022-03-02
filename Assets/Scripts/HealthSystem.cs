using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private float health;
    [SerializeField]
    private Image healthBar;
    private float originalHealth;
    // Start is called before the first frame update
    void Start()
    {
        originalHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void removeHealth(float loss)
    {
        health -= loss;
        healthBar.fillAmount = health / originalHealth;
        if (health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }    
}
