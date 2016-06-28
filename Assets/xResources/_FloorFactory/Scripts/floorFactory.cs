using UnityEngine;
using System.Collections;

public class floorFactory : MonoBehaviour {
    Vector2 gridSize;
    //Vector2 startPosition;
    #region Sprite vars 
    public Sprite A1;
    public Sprite A2;
    public Sprite B1;
    public Sprite B2;
    public Sprite B3;
    public Sprite B4;
    public Sprite C1;
    public Sprite C2;
    public Sprite C3;
    public Sprite R1;
    public Sprite R2;
    public Sprite R3;
    public Sprite L;
    #endregion

    int a_hp = 2;
    int b_hp = 4;
    int c_hp = 6;
    int r_hp = 8;
    int l_hp = 99;


    GameObject[][] gridOfGameObjects;

    // Use this for initialization
    void Start () {
        gridSize = new Vector2(64, 13);
        //startPosition = new Vector2(0,0);
        gridOfGameObjects = new GameObject[(int)gridSize.x][];
        for (int x = 0; x < gridSize.x; x++)
        {
            gridOfGameObjects[x] = new GameObject[(int)gridSize.y];
            for (int y = 0; y < gridSize.y; y++)
            {
                GameObject go = Instantiate(objectFactory.pfb_ground) as GameObject;
                Transform t = go.GetComponent<Transform>();
                SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
                scr_ground scr = go.GetComponent<scr_ground>();
                t.position = new Vector3(-9.463f + (x * sr.bounds.size.x), -1.603f - ( y * sr.bounds.size.y));
                scr.currentState = scr_ground.groundState.Static;
                gridOfGameObjects[x][y] = go;

                switch (y)
                {
                    case 0:
                        sr.sprite = A1;
                        scr.InitializeGroundHP = a_hp;
                        break;
                    case 1:
                        sr.sprite = A2;
                        scr.InitializeGroundHP = a_hp;
                        break;
                    case 2:
                        sr.sprite = B1;
                        scr.InitializeGroundHP = b_hp;
                        break;
                    case 3:
                        sr.sprite = B2;
                        scr.InitializeGroundHP = b_hp;
                        break;
                    case 4:
                        sr.sprite = B3;
                        scr.InitializeGroundHP = b_hp;
                        break;
                    case 5:
                        sr.sprite = B4;
                        scr.InitializeGroundHP = b_hp;
                        break;
                    case 6:
                        sr.sprite = C1;
                        scr.InitializeGroundHP = c_hp;
                        break;
                    case 7:
                        sr.sprite = C2;
                        scr.InitializeGroundHP = c_hp;

                        break;
                    case 8:
                        sr.sprite = C3;
                        scr.InitializeGroundHP = c_hp;

                        break;
                    case 9:
                        sr.sprite = R1;
                        scr.InitializeGroundHP = r_hp;
                        break;
                    case 10:
                        sr.sprite = R2;
                        scr.InitializeGroundHP = r_hp;
                        break;
                    case 11:
                        sr.sprite = R3;
                        scr.InitializeGroundHP = r_hp;
                        break;
                    case 12:
                        sr.sprite = L;
                        scr.InitializeGroundHP = l_hp;
                        break;
                    default:
                        break;
                }

            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
