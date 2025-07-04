using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;

    public Dash_Kill dash {  get; private set; }

    public Clone_Skill clone { get; private set; }

    private void Awake()
    {
        if(instance !=   null)
            Destroy(instance.gameObject);
        else
            instance = this;

    }

    private void Start()
    {
        dash = GetComponent<Dash_Kill>();
        clone = GetComponent<Clone_Skill>();
    }
}
