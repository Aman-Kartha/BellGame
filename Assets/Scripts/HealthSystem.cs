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
        if (loss > 0.05)
        {
            startShake();
            health -= loss;
            healthBar.fillAmount = health / originalHealth;
            if (health <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    private void startShake()
    {
        shakeDuration = shakeLength;
    }
}
