using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData singleton;
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject[] gd = GameObject.FindGameObjectsWithTag("GameData");
        if (gd.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        singleton = this;
    }
}
