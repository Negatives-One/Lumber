using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toco : MonoBehaviour
{
    public float tempo = 2f;
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
        Instantiate(a.arvores[Random.Range(0, 2)], transform.position, Quaternion.identity, GameObject.Find("Arvores").transform);
        Destroy(gameObject);
    }
}
