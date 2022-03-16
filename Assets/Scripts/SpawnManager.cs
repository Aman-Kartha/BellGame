using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> cubes;
    [SerializeField]
    private GameObject leftSpawner;
    [SerializeField]
    private Material brokenMat;
    [SerializeField]
    private GameObject rightSpawner;

    private int count = 1;
    private bool gameDone = false;
    private GameObject currentCube;
    private Vector3 correctPlacement;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<ParticleSystem>().Pause();
        currentCube = cubes[count - 1];
        correctPlacement = currentCube.transform.localPosition;
        currentCube.transform.position = new Vector3(currentCube.transform.position.x, currentCube.transform.position.y, leftSpawner.transform.position.z + 1);
        currentCube.GetComponent<CubeManager>().isLeft();
        currentCube.GetComponent<MeshRenderer>().enabled = true;
        count++;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameDone)
        {
            StartCoroutine(nextScene());
        }
        else
        {
            if (currentCube.GetComponent<CubeManager>().isDone())
            {
                this.GetComponent<HealthSystem>().removeHealth(Mathf.Abs(currentCube.transform.localPosition.x - 0));
                if(Mathf.Abs(currentCube.transform.localPosition.x - 0) > 0.05)
                {
                    currentCube.GetComponent<MeshRenderer>().material = brokenMat;
                }
                currentCube.transform.localPosition = correctPlacement;
                if (!(count > cubes.Count))
                {
                    currentCube = cubes[count - 1];
                    correctPlacement.y = currentCube.transform.localPosition.y;
                    if (count % 2 == 0)
                    {
                        currentCube.transform.position = new Vector3(currentCube.transform.position.x, currentCube.transform.position.y, rightSpawner.transform.position.z - 2);
                        currentCube.GetComponent<CubeManager>().isRight();
                    }
                    else
                    {
                        currentCube.transform.position = new Vector3(currentCube.transform.position.x, currentCube.transform.position.y, leftSpawner.transform.position.z + 1);
                        currentCube.GetComponent<CubeManager>().isLeft();
                    }
                    currentCube.GetComponent<MeshRenderer>().enabled = true;
                    currentCube.GetComponent<CubeManager>().clicked = false;
                    count++;
                }
                else
                {
                    gameDone = true;
                }
            }
        }
    }

    IEnumerator nextScene()
    {
        this.gameObject.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
