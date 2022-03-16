using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class temperature : MonoBehaviour
{
    [SerializeField] Transform top;
    [SerializeField] Transform bot;
    [SerializeField] Sprite one;
    [SerializeField] Sprite two;
    [SerializeField] Sprite three;
    [SerializeField] Sprite four;
    [SerializeField] GameObject TARGETIMAGE;
    [SerializeField] float progressMultiplier;

    [SerializeField] GameObject lava;

    [SerializeField] Light fire;

    [SerializeField] Image health;

    [SerializeField] Image Temp;

    Renderer lavaMat;

    public float temperaturePosition;
    [SerializeField] float temperatuerSize = 0.1f;
    [SerializeField] float TemperaturePower = 5f;
    float hookProgress;
    float hookPullVelocity;
    [SerializeField] float TemperatureGravityPower = 0.005f;
    [SerializeField] float DegredationPower = 0.1f;

    [SerializeField] Transform target;

    [SerializeField] GameObject render;
    float progress = 0;
    float targetPosition;
    float targetDestination;
    float targetTimer;

    [SerializeField] float timerMultiplicator = 3f;
    float speed;
    [SerializeField] float smoothMotion = 1f;
    void Start()
    {
        targetPosition = 1f;
        progress = 0f;
        /*
        Bounds b = render.GetComponent<UnityEngine.UI.Image>(;
        float ySize = b.size.y;
        Vector3 ls = Temp.localScale;
        float distance = Vector3.Distance(top.position, bot.position);
        ls.y = (distance / ySize * temperatuerSize);
        Temp.localScale = ls;*/
        lavaMat = lava.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(progress);
        progressCheck();

        fire.intensity = temperaturePosition * 20f;

        if (Input.GetKeyDown(KeyCode.Q) )
        {

            heat();

        }

        targetTimer -= Time.deltaTime;
        if(targetTimer < 0f) {
            targetTimer = UnityEngine.Random.value * timerMultiplicator;
            targetDestination = UnityEngine.Random.value;
        }

        targetPosition = Mathf.SmoothDamp(targetPosition, targetDestination, ref speed, smoothMotion);
        target.position = Vector3.Lerp(bot.position, top.position, targetPosition);

        hookPullVelocity -= TemperatureGravityPower * Time.deltaTime;
        hookPullVelocity = Mathf.Clamp(hookPullVelocity, -10, 10);
        tempe();
    }


    void tempe()
    {
        
        temperaturePosition += hookPullVelocity;
        temperaturePosition = Mathf.Clamp(temperaturePosition, temperatuerSize/2, 1 - temperatuerSize/2 );
        Temp.fillAmount = temperaturePosition;

        Temp.color = Color.Lerp(Color.blue,Color.red, Temp.fillAmount);

        lavaMat.material.SetColor("_BaseColor",Temp.color);
        
        
    }
    public void highCool()
    {
        hookPullVelocity -=   TemperaturePower * Time.deltaTime;
    }
    public void Cool()
    {
        hookPullVelocity -= 0.5f * TemperaturePower * Time.deltaTime;
    }
    public void heat()
    {
        hookPullVelocity += 0.1f*TemperaturePower * Time.deltaTime;
        Debug.Log("pressed");
    }
    public void highHeat()
    {
        hookPullVelocity +=   TemperaturePower * Time.deltaTime;
    }

    void progressCheck()
    {
        float min = temperaturePosition - temperatuerSize / 2  - 0.05f;
        float max = temperaturePosition + temperatuerSize / 2  + 0.05f;

        if (min < targetPosition && targetPosition < max)
        {
            //Debug.Log(temperaturePosition);
            progress += progressMultiplier * Time.deltaTime;

        }
        else
        {
            progress -= DegredationPower * Time.deltaTime;
        }
        progress = Mathf.Clamp(progress, 0f, 1f);

        health.fillAmount = Mathf.Lerp(health.fillAmount, progress, 5f*Time.deltaTime) ;
    }
}
