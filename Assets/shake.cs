using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake : MonoBehaviour
{

    Vector3 originalPos;
    // Start is called before the first frame update

    [SerializeField]
    GameObject temp;
    void Start()
    {
        originalPos = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {

        

        float elapsed = 0.0f;

        if (temp.GetComponent<temperature>().temperaturePosition > 0.6)
        {

            float z = Random.Range(originalPos.z - 2, originalPos.z + 2);
            //float y = Random.Range(-1f, 1f) * magnitude;

            transform.eulerAngles = new Vector3(originalPos.x, originalPos.y, z);




        }
        else
        {

            transform.eulerAngles = originalPos;
        }
    }
}
