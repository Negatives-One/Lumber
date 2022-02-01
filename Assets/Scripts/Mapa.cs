using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mapa : MonoBehaviour
{
    [SerializeField] public Vector2Int mapSize;
    private Vector2Int grassPerAxis;
    [SerializeField] public GameObject grassObject;
    [SerializeField] public List<GameObject> grasses = new List<GameObject>();

    [SerializeField] public List<GameObject> arvores = new List<GameObject>();
    [SerializeField] public GameObject toco;
    [SerializeField] public Player player;

    public enum Cor { Normal, Amarelo, Neve };

    public List<Material> grassTypes;
    public List<Material> groundTypes;

    void Start()
    {
        grassPerAxis = new Vector2Int(mapSize.x/20, mapSize.y/20);
        Vector3 pointer = new Vector3(-mapSize.x / 2f + 10f, 0f, -mapSize.y / 2f + 10f);
        for(int x = 0; x < grassPerAxis.x; x++)
        {
            for (int y = 0; y < grassPerAxis.y; y++)
            {
                GameObject grass = Instantiate(grassObject, GameObject.Find("Grasses").transform);
                grasses.Add(grass);
                grass.transform.position = pointer;

                switch((Cor)Random.Range(0, 3))
                {
                    case (Cor.Normal):
                        SoloNormal solo = grass.AddComponent(typeof(SoloNormal)) as SoloNormal;
                        solo.currentCor = Cor.Normal;
                        solo.mapa = this;
                        break;
                    case (Cor.Amarelo):
                        SoloAmarelo soloA = grass.AddComponent(typeof(SoloAmarelo)) as SoloAmarelo;
                        soloA.currentCor = Cor.Amarelo;
                        soloA.mapa = this;
                        break;
                    case (Cor.Neve):
                        SoloNeve soloN = grass.AddComponent(typeof(SoloNeve)) as SoloNeve;
                        soloN.currentCor = Cor.Neve;
                        soloN.mapa = this;
                        break;
                }
                pointer += Vector3.back * -20;
            }
            pointer = new Vector3(pointer.x, 0f, -mapSize.y / 2f + 10f);
            pointer += Vector3.right * 20;
        }

        StartCoroutine(AumentarVidaMaxArvores(10f));

        //for(int i = 0; i < grasses.Count; i++)
        //{
        //    GameObject a = Instantiate(arvores[Random.Range(0, 3)], grasses[i].transform.position, Quaternion.identity, GameObject.Find("Arvores").transform);
        //    a.GetComponent<Arvore>().player = player;
        //}
    }

    static public IEnumerator AumentarVidaMaxArvores(float duration)
    {
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / duration;

            yield return null;
        }
        Arvore.vidaMax += 1;
        StartCoroutine(AumentarVidaMaxArvores(10f));
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(mapSize.x, 1, mapSize.y));
    }
}