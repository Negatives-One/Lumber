using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa : MonoBehaviour
{
    [SerializeField] public Vector2Int mapSize;
    [SerializeField] public Vector2Int grassPerAxis;
    [SerializeField] public GameObject grassObject;
    void Start()
    {
        grassPerAxis = new Vector2Int(mapSize.x/20, mapSize.y/20);
        Vector3 pointer = new Vector3(-mapSize.x / 2f + 10f, 0f, -mapSize.y / 2f + 10f);
        for(int x = 0; x < grassPerAxis.x; x++)
        {
            for (int y = 0; y < grassPerAxis.y; y++)
            {
                GameObject grass = Instantiate(grassObject, GameObject.Find("Grasses").transform);
                grass.transform.position = pointer;
                pointer += Vector3.back * -20;
            }
            pointer = new Vector3(pointer.x, 0f, -mapSize.y / 2f + 10f);
            pointer += Vector3.right * 20;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(mapSize.x, 1, mapSize.y));
    }
}
