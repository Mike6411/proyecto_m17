﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor_Script : MonoBehaviour
{
    public bool activated;
    // Start is called before the first frame update
    void Start()
    {
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
