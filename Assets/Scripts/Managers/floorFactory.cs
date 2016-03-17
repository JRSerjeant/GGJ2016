using UnityEngine;
using System.Collections;

public class floorFactory : MonoBehaviour {
    Vector2 gridSize;
    float gridBlockScale = -0.27f;
    GameObject[][] gridOfGameObjects;
    // Use this for initialization
    void Start () {
        gridSize = new Vector2(10, 10);
        gridOfGameObjects = new GameObject[(int)gridSize.x][];
        for (int x = 0; x < gridSize.x; x++)
        {
            gridOfGameObjects[x] = new GameObject[(int)gridSize.y];
            for (int y = 0; y < gridSize.y; y++)
            {
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                // manipulate gameobject here
                Transform t = go.GetComponent<Transform>();
                t.localScale = new Vector3(gridBlockScale, gridBlockScale,gridBlockScale);
                t.localPosition = new Vector3(x * t.localScale.x + 0.2f, y * t.localScale.y+0.2f);
                go.GetComponent<Renderer>().material.color = Color.green;
                
                gridOfGameObjects[x][y] = go;

            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
