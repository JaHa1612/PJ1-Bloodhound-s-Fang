using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{

    [SerializeField] private GameObject characterUI;
    [SerializeField] private GameObject skillTreeUI;
    [SerializeField] private GameObject craftUI;
    [SerializeField] private GameObject optionsUI;


    public UI_SkillTookTip skillTookTip;
    // Start is called before the first frame update
    void Start()
    {
        SwitchTo(null);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SwitchWithKeyTo(characterUI);

        if(Input.GetKeyDown(KeyCode.Alpha3))
            SwitchWithKeyTo(craftUI);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            SwitchWithKeyTo(skillTreeUI);

        if (Input.GetKeyDown(KeyCode.Alpha4))
            SwitchWithKeyTo(optionsUI);

    }

    public void SwitchTo(GameObject _menu)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        if (_menu != null)
            _menu.SetActive(true);
    }

    public void SwitchWithKeyTo(GameObject _menu)
    {
        if (_menu != null && _menu.activeSelf)
        {

            _menu.SetActive(false);
            return;
        }

        SwitchTo(_menu);
    }
}
