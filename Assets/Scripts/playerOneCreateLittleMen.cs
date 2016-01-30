using UnityEngine;
using System.Collections;

public class playerOneCreateLittleMen : MonoBehaviour
{
    public GameObject men;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1.0f);
        Instantiate(men, new Vector2(8.0f, -1.3f), new Quaternion());
        yield return new WaitForSeconds(1.0f);
    }
}
