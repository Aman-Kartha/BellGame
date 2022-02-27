using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class spawner : MonoBehaviour
{
    [SerializeField]
    private movingCube cubePrefab;
    [SerializeField]
    GameObject starter;
    [SerializeField]
    MoveDirection moveDirection;
    
    public void SpawnCube()
    {
        var cube = Instantiate(cubePrefab);
        
        if (movingCube.LastCube != null && movingCube.LastCube.gameObject != GameObject.Find("Starter"))
        {

            
            cube.transform.position = new Vector3(transform.position.x,
                movingCube.LastCube.transform.position.y + cubePrefab.transform.localScale.y,
                transform.position.z);

         

        }
        else
        {
            
            cube.transform.position = transform.position;
        }

        cube.moveDirection = moveDirection;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, cubePrefab.transform.localScale);

    }
    void Update()
    {
        
    }
}
