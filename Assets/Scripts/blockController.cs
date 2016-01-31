using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class blockController : MonoBehaviour
{
    public GameObject block;
    public GameObject bluePlayerTop;
    public GameObject redPlayerTop;
    public int redPlayerBlockCount;
    public int bluePlayerBlockCount;
    public int blockCount;
    private float _lastBlockRefreshTime;
    

    // Use this for initialization
    void Start()
    {
        blockCount = Configuration.InitialBlockCount;
        redPlayerBlockCount = 0;
        bluePlayerBlockCount = 0;
        _lastBlockRefreshTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        RefreshBlocks();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bluePlayerBlockCount < blockCount)
            {
                Debug.Log(string.Format("Blue player block count used {0}", ++bluePlayerBlockCount));
                GameObject go = Instantiate(block, new Vector2(bluePlayerTop.GetComponent<Renderer>().transform.position.x, bluePlayerTop.GetComponent<Renderer>().transform.position.y -0.5f), new Quaternion()) as GameObject;

            }
        }
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            if (redPlayerBlockCount < blockCount)
            {
                Debug.Log(string.Format("Red player block count used {0}", ++redPlayerBlockCount));
                GameObject go = Instantiate(block, (bluePlayerTop.GetComponent<Renderer>().transform.position.x, bluePlayerTop.GetComponent<Renderer>().transform.position.y - 0.5f), new Quaternion()) as GameObject;
            }
        }
    }

    private void RefreshBlocks()
    {
        if (Time.time - _lastBlockRefreshTime >= Configuration.BlockRegenerationPerSecond)
        {
            Debug.Log(string.Format("Block count incrementing from {0} to {1}", blockCount, ++blockCount));
            _lastBlockRefreshTime = Time.time;
        }
    }
}
