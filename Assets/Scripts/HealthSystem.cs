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
    [SerializeField]
    private Image healthBorder;
    [SerializeField]
    private Sprite halfHealth;
    [SerializeField]
    private Sprite lowHealth;
    [SerializeField]
    private Sprite lowBar;
    [SerializeField]
    private Sprite halfBar;
    [SerializeField]
    private ParticleSystem particleSystem;
    [SerializeField]
    private float shakeLength;
    private float shakeDuration = 0f;
    private float shakeMagnitude = 0.7f;
    private float dampingSpeed = 1.0f;
    private Vector3 initialPos;
    private GameObject myCamera;
    private float originalHealth;
    // Start is called before the first frame update
    void Start()
    {
        originalHealth = health;
        myCamera = GameObject.FindGameObjectWithTag("MainCamera");
        initialPos = myCamera.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeDuration > 0)
        {
            myCamera.transform.localPosition = initialPos + UnityEngine.Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            myCamera.transform.localPosition = initialPos;
        }
    }
    public void removeHealth(float loss)
    {
        particleSystem.Play();
        if (loss > 0.05)
        {
            startShake();
            health -= loss;
            healthBar.fillAmount = health / originalHealth;
            if(health <= 0.3)
            {
                healthBar.sprite = lowHealth;
                healthBorder.sprite = lowBar;
                
            }
            else if(health <= 0.5)
            {
                healthBar.sprite = halfHealth;
                healthBorder.sprite = halfBar;
            }
            if (health <= 0)
            {
                StartCoroutine(this.GetComponent<combine>().loadlevelAsync(4,2));
            }
            particleSystem.startColor = Color.red;
        }
        else
        {
            particleSystem.startColor = Color.green;
        }
        particleSystem.Play();
    }
    private void startShake()
    {
        shakeDuration = shakeLength;
    }
}
