using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float shakeLength;
    private float shakeDuration = 0f;
    private float shakeMagnitude = 0.7f;
    private float dampingSpeed = 1.0f;
    private Vector3 initialPos;
    private GameObject myCamera;
    private spawner[] spawners;
    private int spawnerIndex;
    private spawner currentSpawner;
    public float speed = 1f;
    // Start is called before the first frame update
     void Awake()
    {
        spawners = FindObjectsOfType<spawner>();
      


    }
    private void Start()
    {
        spawners[0].SpawnCube();
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
        if (Input.GetButtonDown("Fire1"))
        {
            if (movingCube.currentCube != null)
            {
                movingCube.currentCube.Stop();
                if (movingCube.currentCube.getShaking())
                {
                    startShake();
                }
            }
            if (!gameDone())
            {
                spawnerIndex = spawnerIndex == 0 ? 1 : 0;
                currentSpawner = spawners[spawnerIndex];


                currentSpawner.SpawnCube();
            }
        }
    }

    private bool gameDone()
    {
        foreach (spawner spawn in spawners)
        {
            if(!spawn.isDone())
            {
                return false;
            }
        }
        print("Game Done!");
        this.GetComponent<ParticleSystem>().Play();
        return true;
    }
    private void startShake()
    {
        print("Shake");
        shakeDuration = shakeLength;
    }
}
