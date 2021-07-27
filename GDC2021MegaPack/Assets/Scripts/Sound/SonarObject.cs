using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SonarObject : MonoBehaviour
{
    public Transform donutSonar;
    private AudioSource myAudioSource;

    private Image sonarAlarm;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        StartCoroutine(SonarSending());
    }

    // Update is called once per frame
    void Update()
    {
        donutSonar.localScale = donutSonar.localScale + new Vector3(2f, 2f, 2f) * Time.deltaTime;
        if (!myAudioSource.isPlaying)
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator SonarSending()
    {
        yield return new WaitForSeconds(1f);
        Destroy(donutSonar.gameObject);
    }
}
