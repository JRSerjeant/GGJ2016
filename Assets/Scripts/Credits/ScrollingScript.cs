using UnityEngine;
using UnityEngine.UI;

public class ScrollingScript : MonoBehaviour
{

    private RectTransform text;
    private float _moveSpeed = 20.0f;

    void Start()
    {
        text = this.GetComponent<RectTransform>();
    }

    void Update()
    {
        text.Translate(Vector3.up * _moveSpeed * Time.deltaTime);
    }
}
