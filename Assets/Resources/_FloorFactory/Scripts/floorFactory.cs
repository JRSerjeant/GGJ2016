using UnityEngine;
using System.Collections;

public class floorFactory : MonoBehaviour {
    Vector2 gridSize;
    //Vector2 startPosition;
    #region Sprite vars 
    private Sprite A1;
    private Sprite A2;
    private Sprite B1;
    private Sprite B2;
    private Sprite B3;
    private Sprite B4;
    private Sprite C1;
    private Sprite C2;
    private Sprite C3;
    private Sprite R1;
    private Sprite R2;
    private Sprite R3;
    private Sprite L;
    #endregion

    int a_hp = 1;
    int b_hp = 2;
    int c_hp = 3;
    int r_hp = 4;
    int l_hp = 9;


    GameObject[][] gridOfGameObjects;

    // Use this for initialization
    void Start () {
        loadSprits();
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
                //go.GetComponent<Rigidbody2D>().isKinematic = true;
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

    void loadSprits()
    {
        A1 = Resources.Load<Sprite>("_Ground/Sprites/A1");
        A2 = Resources.Load<Sprite>("_Ground/Sprites/A2");
        B1 = Resources.Load<Sprite>("_Ground/Sprites/B1");
        B2 = Resources.Load<Sprite>("_Ground/Sprites/B2");
        B3 = Resources.Load<Sprite>("_Ground/Sprites/B3");
        B4 = Resources.Load<Sprite>("_Ground/Sprites/B4");
        C1 = Resources.Load<Sprite>("_Ground/Sprites/C1");
        C2 = Resources.Load<Sprite>("_Ground/Sprites/C2");
        C3 = Resources.Load<Sprite>("_Ground/Sprites/C3");
        R1 = Resources.Load<Sprite>("_Ground/Sprites/R1");
        R2 = Resources.Load<Sprite>("_Ground/Sprites/R2");
        R3 = Resources.Load<Sprite>("_Ground/Sprites/R3");
        L = Resources.Load<Sprite>("_Ground/Sprites/L");
    }
}
