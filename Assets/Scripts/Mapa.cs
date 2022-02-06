using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Mapa : MonoBehaviour
{
    [SerializeField] private Vector2Int mapSize;
    private Vector2Int grassPerAxis;
    [SerializeField] private GameObject grassObject;
    [SerializeField] public List<GameObject> grasses = new List<GameObject>();

    [SerializeField] public List<GameObject> arvores = new List<GameObject>();
    [SerializeField] public GameObject toco;
    [SerializeField] public Player player;
    private float damageTimerRate = 8f;

    public enum Cor { Normal, Amarelo, Neve };

    public List<Material> grassTypes;
    public List<Material> groundTypes;

    void Start()
    {
        GenerateMap();

        Coroutine a = StartCoroutine(AumentarVidaMaxArvores(damageTimerRate));

        //for(int i = 0; i < grasses.Count; i++)
        //{
        //    GameObject a = Instantiate(arvores[Random.Range(0, 3)], grasses[i].transform.position, Quaternion.identity, GameObject.Find("Arvores").transform);
        //    a.GetComponent<Arvore>().player = player;
        //}
    }

    private void GenerateMap()
    {
        grassPerAxis = new Vector2Int(mapSize.x / 20, mapSize.y / 20);
        Vector3 pointer = new Vector3(-mapSize.x / 2f + 10f, 0f, -mapSize.y / 2f + 10f);
        for (int x = 0; x < grassPerAxis.x; x++)
        {
            for (int y = 0; y < grassPerAxis.y; y++)
            {
                GameObject grass = Instantiate(grassObject, GameObject.Find("Grasses").transform);
                grasses.Add(grass);
                grass.transform.position = pointer;

                switch ((Cor)Random.Range(0, 3))
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
    }

    private void Update()
    {
        if (player.life <= 0f && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(0);
            Arvore.vidaMax = 3;
        }

    }

    public IEnumerator AumentarVidaMaxArvores(float duration)
    {
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / duration;

            yield return null;
        }
        Arvore.UpdateArvoreHealth();
        player.UpdateDamageRate();
        StartCoroutine(AumentarVidaMaxArvores(damageTimerRate));
    }
  
    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(mapSize.x, 1, mapSize.y));
    }


    
}