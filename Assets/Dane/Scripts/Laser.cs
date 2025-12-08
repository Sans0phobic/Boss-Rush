using System.Buffers;
using System.Collections;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private MeshRenderer mesh;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.enabled = false;
    }

    public void SubLaser() 
    {
        StartCoroutine(LaserCounterA());
    }

    IEnumerator LaserCounterA() 
    {
        yield return new WaitForSeconds(0.8f);
        mesh.enabled = true;
        yield return new WaitForSeconds(1.1f);
        mesh.enabled = false;
    }
}
