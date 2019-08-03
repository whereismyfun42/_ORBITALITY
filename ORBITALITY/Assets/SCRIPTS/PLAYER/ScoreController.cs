using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;
    [SerializeField]
    private TextMeshProUGUI ScoreText;
    public float Score;
    public GameObject Win;

    public void Awake()
    {
        ScoreText.text = Score.ToString();
        instance = this;
    }
    void Update()
    {
        ScoreText.text = Score.ToString();


        if (Score >= 20)
        {
            Time.timeScale = 0;
            Win.SetActive(true);
            if (Input.anyKey)
            {
                SceneManager.LoadScene("MAIN SCENE");
            }
        }

    }
}
