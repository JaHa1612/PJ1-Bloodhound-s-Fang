using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManganer : MonoBehaviour
{
    public static PlayerManganer instance;

    private void Awake()
    {
        instance = this;
    }
}
