﻿using UnityEngine;
using System.Collections;

public class Mz00WallDelete : MonoBehaviour {

    void Update() {
        if (Mz00Manager.Mz00Goal == true)
            Destroy(gameObject);
    }
}