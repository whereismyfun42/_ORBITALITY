using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HPController : MonoBehaviour
{
    public static HPController instance;
    [SerializeField]
    private TextMeshProUGUI HealthText;
    public float HP;
    public GameObject Lost;

    public void Awake()
    {
        HealthText.text = HP.ToString();
        instance = this;
    }
    void Update()
    {
        HealthText.text = HP.ToString();



        HP -= 1f * Time.deltaTime;

        if (HP <= 0)
        {
            Time.timeScale = 0;
            Lost.SetActive(true);
            if (Input.anyKey)
            {
                SceneManager.LoadScene("MAIN SCENE");
            }
        }
        
    }
}
