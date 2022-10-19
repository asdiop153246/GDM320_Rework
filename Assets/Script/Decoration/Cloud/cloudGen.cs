using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudGen : MonoBehaviour
{
    public GameObject Cloud;
    GameObject cloneCloud;

    public Vector2 cloudSpawnPosition = new Vector2(0 , 0);
    public Vector2 endPosition = new Vector2(0, 0);
    public float delaySpawnBySecond = 1;
    private bool isGenAble = true;
    void Update()
    {
        StartCoroutine("GenerateCloud");
    }
    private IEnumerator GenerateCloud()
    {
        if (isGenAble == true)
        {
            isGenAble = false;
            cloneCloud = Instantiate(Cloud, cloudSpawnPosition, Quaternion.identity);
            cloneCloud.transform.DOMove(endPosition, Random.Range(10, 30));
            yield return new WaitForSeconds(delaySpawnBySecond);
            isGenAble = true;
        }
    }


}
