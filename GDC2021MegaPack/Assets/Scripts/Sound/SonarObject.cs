using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarObject : MonoBehaviour
{
    public Transform donutSonar;
    private AudioSource myAudioSource;

    private GameObject sonarAlarm;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();

        // Finder og t�nder for sonar-alarm lyset
        sonarAlarm = GameObject.FindGameObjectWithTag("SonarAlarm");
        if (sonarAlarm != null)
        {
            sonarAlarm.SetActive(false);
        }

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
        // Venter i et halvt sekund
        yield return new WaitForSeconds(0.5f);

        // Slukker for alarm lyset igen
        if (sonarAlarm != null)
        {
            sonarAlarm.SetActive(true);
        }

        // Venter i et halvt sekund
        yield return new WaitForSeconds(0.5f);

        // Fjerner sonaren i verdenen
        Destroy(donutSonar.gameObject);
    }
}
