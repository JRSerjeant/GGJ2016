using UnityEngine;
using System.Collections;

public class scr_DirtMagic : MonoBehaviour {

    Animator ani;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {

    }

    public void settransform(Transform t)
    {
        this.transform.position = t.position;
        this.transform.rotation = t.rotation;
    }

    public void playAnimation()
    {
        ani = GetComponent<Animator>();
        ani.Play("Dirt_Magic");
    }


}
