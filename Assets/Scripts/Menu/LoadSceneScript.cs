using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour {

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(playSoundThenLoad(sceneName));
    }

    IEnumerator playSoundThenLoad(string sceneName)
    {
        var audioSource = GetComponent<AudioSource>();

        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);

        SceneManager.LoadScene(sceneName);
        if (string.Equals(sceneName, "main", StringComparison.CurrentCultureIgnoreCase))
        {
            TimeControllerScript._startGameTime = Time.time;
        }
    }
}
