using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class Teleport : MonoBehaviour
{
    public Transform[] destinos;

    [Space]
    public bool destroyTeleport = false;
    bool rotinaIniciada = false;

    void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (destinos.Length > 0 && !rotinaIniciada)
        {
            int positions = Random.Range(0, destinos.Length);
            if (destinos[positions])
            {
                other.transform.position = destinos[positions].position;
                other.transform.rotation = destinos[positions].rotation;
                if (destroyTeleport)
                {
                    StartCoroutine(DestoyTeleportCoroutine());
                }
            }
        }
    }

    IEnumerator DestoyTeleportCoroutine()
    {
        rotinaIniciada = true;
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        if (mesh)
        {
            mesh.enabled = false;
        }

        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
