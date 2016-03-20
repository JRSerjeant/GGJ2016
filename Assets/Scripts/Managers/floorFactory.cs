using UnityEngine;
using System.Collections;

public class floorFactory : MonoBehaviour {
    Vector2 gridSize;
    Vector2 startPosition;
    float gridBlockScale = -0.27f;
    GameObject[][] gridOfGameObjects;


    Vector3 topLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));
    Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
    Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
    Vector3 bottomRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));

    // Use this for initialization
    void Start () {
        gridSize = new Vector2(70, 15);
        startPosition = new Vector2(0,0);
        gridOfGameObjects = new GameObject[(int)gridSize.x][];
        for (int x = 0; x < gridSize.x; x++)
        {
            gridOfGameObjects[x] = new GameObject[(int)gridSize.y];
            for (int y = 0; y < gridSize.y; y++)
            {
                GameObject go = Instantiate(objectFactory.pfb_Block) as GameObject;
                Transform t = go.GetComponent<Transform>();
                Renderer r = go.GetComponent<Renderer>();
                t.position = new Vector3(-9.463f + (x * r.bounds.size.x), -1.603f - ( y * r.bounds.size.y));
                //t.localScale = new Vector3(gridBlockScale, gridBlockScale,gridBlockScale);
                //t.localPosition = new Vector3(x * t.localScale.x + 0.2f, y * t.localScale.y+0.2f);
                r.material.color = Color.green;
                go.GetComponent<Rigidbody2D>().isKinematic = true;
                gridOfGameObjects[x][y] = go;

            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
