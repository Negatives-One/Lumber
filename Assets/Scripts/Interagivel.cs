using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interagivel : MonoBehaviour
{
    protected Player player;
    [SerializeField] protected Inventario inventario;
    void Start()
    {
        player = GameObject.Find("Capsule").GetComponent<Player>();
        inventario = player.gameObject.GetComponent<Inventario>();
    }

    void Update()
    {
        CheckDistance();
    }
    protected void CheckDistance()
    {
        float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        if (distance < 3.5f)
        {
            OnCloseDistance();
        }
    }

    public virtual void OnCloseDistance()
    {
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 3.5f);
    }
}
