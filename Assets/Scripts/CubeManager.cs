using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private bool left = false;
    public bool clicked = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!clicked)
        {
            if (left)
            {
                this.transform.position -= transform.right * Time.deltaTime * speed;
            }
            else
            {
                this.transform.position += transform.right * Time.deltaTime * speed;
            }
        }
        
        if(Input.GetKeyDown(KeyCode.W))
        {
            clicked = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Spawner")
        {
            left = !left;
        }
    }
    public void isLeft()
    {
        left = true;
    }

    public void isRight()
    {
        left = false;
    }

    public bool isDone()
    {
        return clicked;
    }
}
