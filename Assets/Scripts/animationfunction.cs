using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class animationfunction : MonoBehaviour
{

    [SerializeField]
    GameObject g;

    [SerializeField] Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setEnable()
    {
        g.SetActive(true);
    }
    void setDisable()
    {
        g.SetActive(false);
    }

    void moveBell()
    {
        anim.SetTrigger("moveBell");
    }
    void playBell()
    {
        anim.SetTrigger("playBell");
    }
    void transition()
    {
        StartCoroutine(this.GetComponent<combine>().loadlevelAsync(5, 3));
    }

}
