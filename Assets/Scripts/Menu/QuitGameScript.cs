using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGameScript : MonoBehaviour
{
    public void Quit()
    {
        StartCoroutine(playSoundThenLoad());
    }

    IEnumerator playSoundThenLoad()
    {
        var audioSource = GetComponent<AudioSource>();

        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);

        Application.Quit();
    }
}
