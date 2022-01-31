using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoloNeve : Solo
{
    void Start()
    {
        GameObject a = Instantiate(mapa.arvores[(int)currentCor], transform.position, Quaternion.identity, GameObject.Find("Arvores").transform);
        a.GetComponent<Arvore>().player = mapa.player;
        a.GetComponent<Arvore>().solo = this;
        Material[] materials = new Material[2];
        materials[0] = mapa.groundTypes[(int)currentCor];
        materials[1] = mapa.grassTypes[(int)currentCor];
        GetComponent<MeshRenderer>().materials = materials;
    }

    void Update()
    {

    }
}
