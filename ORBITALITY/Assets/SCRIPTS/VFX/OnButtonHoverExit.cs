using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OnButtonHoverExit : MonoBehaviour
{

    public GameObject VFX;
    // Start is called before the first frame update
    void Start()
    {
        VFX.SetActive(false);
    }

    void OnMouseExit()
    {
        VFX.SetActive(false);
    }

    void OnMouseOver()
    {

        VFX.SetActive(true);
    }

    void OnMouseDown(){
        Application.Quit();
    }

}
