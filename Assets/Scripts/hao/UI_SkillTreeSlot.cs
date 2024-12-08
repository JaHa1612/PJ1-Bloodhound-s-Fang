using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_SkillTreeSlot : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    private UI ui;

    private Image skillImage;

    [SerializeField] private string skillName;
    [TextArea]
    [SerializeField] private string skillDescription;
    [SerializeField] private Color lockedSkillcolor;

    public bool unlocked;

    [SerializeField] private UI_SkillTreeSlot[] shouldBeUnlocked;
    [SerializeField] private UI_SkillTreeSlot[] shouldBelocked;


    private void OnValidate()
    {
        gameObject.name = "SkillTreeSlot_UI - " + skillName;
    }

    private void Start()
    {
        skillImage = GetComponent<Image>();

        ui = GetComponentInParent<UI>();
        
        skillImage.color = lockedSkillcolor;

        GetComponent<Button>().onClick.AddListener(() => UnlockSkillSlot());


    }

    public void UnlockSkillSlot()
    {
        for (int i = 0; i < shouldBeUnlocked.Length; i++)
        {
            if (shouldBeUnlocked[i].unlocked == false)
            {
                Debug.Log("Cannot unlock skill");

                return;
            }
        }


        for (int i = 0; i < shouldBelocked.Length; i++)
        {
            if (shouldBelocked[i].unlocked == true)
            {
                Debug.Log("Cannot unlock skill");
                return;
            }
        }

        unlocked = true;
        skillImage.color = Color.white;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        ui.skillTookTip.ShowToolTip(skillDescription, skillName);

        Vector2 mousePosition = Input.mousePosition;
        Debug.Log(mousePosition);

        float xOffset = 0;
        float yOffset = 0;

        if (mousePosition.x > 600)
            xOffset = -150;

        else
            xOffset = 150;

        if (mousePosition.y > 320)
            yOffset = -150;
        else
            yOffset = 150;

            ui.skillTookTip.transform.position = new Vector2(mousePosition.x + xOffset , mousePosition.y + yOffset);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ui.skillTookTip.HideToolTip();
    }

}
