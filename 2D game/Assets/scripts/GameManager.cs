using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool hasKey;
    public bool isDoorLocked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hasKey && !isDoorLocked)
        {
            print("you exit out the door another room! enemy ans emerged from the shadows");
        }
    }
}
