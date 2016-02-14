using UnityEngine;
using System.Collections;

public class audioFactory : MonoBehaviour
{
    public static AudioClip Create1;
    public static AudioClip Create2;
    public static AudioClip Create3;
    public static AudioClip Thud1;
    public static AudioClip Thud2;
    public static AudioClip Squash1;
    public static AudioClip Squash2;
    public static AudioClip Scream1;
    public static AudioClip Scream2;

    void Start()
    {
        Create1 = (AudioClip)Resources.Load("Audio/Create1");
        Create2 = (AudioClip)Resources.Load("Audio/Create2");
        Create3 = (AudioClip)Resources.Load("Audio/Create3");
        Thud1 = (AudioClip)Resources.Load("Audio/Thud1");
        Thud2 = (AudioClip)Resources.Load("Audio/Thud2");
        Squash1 = (AudioClip)Resources.Load("Audio/Squash1");
        Squash2 = (AudioClip)Resources.Load("Audio/Squash2");
        Scream1 = (AudioClip)Resources.Load("Audio/Scream1");
        Scream2 = (AudioClip)Resources.Load("Audio/Scream2");
    }
}