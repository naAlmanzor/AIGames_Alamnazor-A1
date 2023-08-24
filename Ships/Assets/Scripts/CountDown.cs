using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    public string levelLoad;
    public float currentTime;
    [SerializeField] TextMeshProUGUI countDownText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        countDownText.text = currentTime.ToString("0"); 

        if(currentTime <= 0){
            SceneManager.LoadScene(levelLoad);
        } 
    }
}
