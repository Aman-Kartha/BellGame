using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movingCube : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float moveSpeed = 1f;
   
    public static movingCube currentCube { get; private set; }
    public static movingCube LastCube { get; private set; }
    public spawner.MoveDirection moveDirection { get; internal set; }

    private void OnEnable()
    {
        
        if (LastCube == null)
        {
            LastCube = GameObject.Find("Start").GetComponent<movingCube>();
        }
        else
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().speed += 1;
            moveSpeed = LastCube.moveSpeed + GameObject.Find("GameManager").GetComponent<GameManager>().speed;
        }
        currentCube = this;
        GetComponent<Renderer>().material.color = new Color32(192, 178, 128,100);
        Debug.Log(LastCube.transform.localScale.z);
        // LastCube.transform.localScale = new Vector3(LastCube.transform.localScale.x, transform.localScale.y, LastCube.transform.localScale.z - 0.5);
        transform.localScale = new Vector3 (LastCube.transform.localScale.x, transform.localScale.y, LastCube.transform.localScale.z - 1f);
       
        //transform.localScale = Vector3.one * 0.5f;
    }

   

    void Start()
    {
        
    }

    internal void Stop()
    {
        moveSpeed = 0;
        float hangover = transform.position.z - LastCube.transform.position.z;

        if (Mathf.Abs(hangover) >= LastCube.transform.localScale.z )
        {
            LastCube = null;
            currentCube = null;
            SceneManager.LoadScene(0);
        }

        float direction = hangover > 0 ? 1f : -1f;

        SplitCubeOnZ(hangover,direction);

        //transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z - 2);
        //LastCube = this;

    }

    private void SplitCubeOnZ(float hangover,float direction)
    {
        float newZSize;
        Debug.Log(LastCube.transform.localScale.z);
        if (hangover < 0)
        {
            newZSize = LastCube.transform.localScale.z -1f;
        }
        else
        {
            newZSize = LastCube.transform.localScale.z - Mathf.Abs(hangover + 1f);
        }
        float fallingBlockSize = transform.localScale.z - newZSize;

        float newZPosition = LastCube.transform.position.z + (hangover/2);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newZSize );
        transform.position = new Vector3(transform.position.x, transform.position.y, newZPosition);

        float cubeEdge = transform.position.z + (newZSize / 2f * direction);
        float fallingBlockZPosition = cubeEdge + fallingBlockSize / 2f * direction;

        SpawnDropCube(fallingBlockZPosition, fallingBlockSize);
        //transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z - 2);
        LastCube = this;

    }

    
    private void SpawnDropCube(float fallingBlockZPosition, float fallingBlockSize)
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, fallingBlockSize);
        cube.transform.position = new Vector3(transform.position.x, transform.position.y, fallingBlockZPosition);

        cube.AddComponent<Rigidbody>();
        cube.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;
        Destroy(cube.gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {

        if (moveDirection == spawner.MoveDirection.X2)
        {
            if (Vector3.Distance(this.transform.position, GameObject.Find("SpawnerRight").transform.position) > 15)
            {
                moveDirection = spawner.MoveDirection.X;
            }
            transform.position -= transform.forward * Time.deltaTime * moveSpeed;
        }
        else
        {

            if (Vector3.Distance(this.transform.position, GameObject.Find("Spawner").transform.position) > 15)
            {
                moveDirection = spawner.MoveDirection.X2;
            }
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
    }
}
