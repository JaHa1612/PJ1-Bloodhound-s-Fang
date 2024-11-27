using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject canvaload;
    [SerializeField] private Slider sliderload;
    [SerializeField] private TextMeshProUGUI textload;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {//Riset lần nhảy.
        
        if (collision.gameObject.tag == "Player")
        {
            
            canvaload.SetActive(true);
            StartCoroutine(Loading());



        }
    }
    IEnumerator Loading()
    {
        var value = 0;
        sliderload.value = value;
        textload.text = value + "%";
        while (true)
        {
            value++;
            sliderload.value = value;
            textload.text = value + "%";
            yield return new WaitForSeconds(0.05f);
            if (value >= 100)
            {
                break;
            }

        }
        var currentIdex = SceneManager.GetActiveScene().buildIndex;
        var nextlever = currentIdex + 1;
        if (nextlever == SceneManager.sceneCountInBuildSettings)
        {
            nextlever = 0;
        }
        SceneManager.LoadScene(nextlever);

    }
}
