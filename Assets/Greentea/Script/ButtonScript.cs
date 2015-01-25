using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

    public GameObject RestartButton;

    void Start()
    {
        UIEventListener.Get(RestartButton).onClick = RESTART;
    }

    void RESTART(GameObject e)
    {
        PlayerPrefs.DeleteAll();
        Application.LoadLevel("Main");
    }
}
