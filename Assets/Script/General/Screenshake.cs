using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshake : MonoBehaviour
{
    private float shakeTimeRemaining, shakePower, shakefadetime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Startshake(1f, 3f);
        }
    }
    private void LateUpdate()
    {
        if (shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;

            float XAmount = Random.Range(-1f, 1f) * shakePower;
            float YAmount = Random.Range(-1f, 1f) * shakePower;
            transform.position += new Vector3(XAmount, YAmount, 0f);

            shakePower = Mathf.MoveTowards(shakePower, 0f, shakefadetime * Time.deltaTime);
        }
    }
    public void Startshake(float length, float power)
    {
        shakeTimeRemaining = length;
        shakePower = power;

        shakefadetime = power / length;
    }
}
