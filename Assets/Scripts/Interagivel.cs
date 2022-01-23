using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interagivel : MonoBehaviour
{
    public Player player;

    void Start()
    {
        
    }

    void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        if (distance < 3.5f) {
            onCloseDistance();
        }
    }

    public virtual void onCloseDistance() {
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 3.5f);
    }
}
