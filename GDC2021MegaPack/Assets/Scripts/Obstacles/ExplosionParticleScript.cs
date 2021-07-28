using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticleScript : MonoBehaviour
{
    public float deathWait = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DieInASec());
    }

    IEnumerator DieInASec()
    {
        yield return new WaitForSeconds(deathWait);
        Destroy(gameObject);
    }
}
