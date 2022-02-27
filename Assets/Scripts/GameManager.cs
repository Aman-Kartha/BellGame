using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           
            if (movingCube.currentCube != null )
            {
                movingCube.currentCube.Stop();
                
            }
            spawnerIndex = spawnerIndex == 0 ? 1 : 0;
            currentSpawner = spawners[spawnerIndex];


            currentSpawner.SpawnCube();
        }
    }
}
