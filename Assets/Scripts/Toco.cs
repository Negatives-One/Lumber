using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toco : MonoBehaviour
{
    private float tempo = 2f;
    public Solo solo;
    void Start()
    {
        StartCoroutine(Timer());
    }

    public IEnumerator Timer()
    {
        float t = 0f;
        while (t < tempo)
        {
            t += Time.deltaTime;
            yield return null;
        }
        Mapa a = GameObject.Find("Mapa").GetComponent<Mapa>();
        GameObject arvre = Instantiate(a.arvores[(int)solo.currentCor], transform.position, Quaternion.identity, GameObject.Find("Arvores").transform);
        arvre.GetComponent<Arvore>().solo = solo;
        Destroy(gameObject);
    }
}
