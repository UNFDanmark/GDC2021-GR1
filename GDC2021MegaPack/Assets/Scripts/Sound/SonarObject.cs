using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarObject : MonoBehaviour
{
    public Transform donutSonar;
    private AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();

        // Starter SonarSending Coroutine
        StartCoroutine(SonarSending());
    }

    // Update is called once per frame
    void Update()
    {
        // F�r sonaren til at vokse mens den eksisterer
        if (donutSonar != null)
        {
            donutSonar.localScale = donutSonar.localScale + new Vector3(3f, 3f, 3f) * Time.deltaTime;
        }

        // Sletter objektet n�r lyden er f�rdigspillet
        if (!myAudioSource.isPlaying)
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator SonarSending()
    {
        // Venter i et sekund
        yield return new WaitForSeconds(1f);

        // Fjerner sonaren i verdenen
        Destroy(donutSonar.gameObject);
    }
}
