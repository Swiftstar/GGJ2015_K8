using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour {


    public void StopCreate()
    {
        CreateMedicine.Instance.StopAllCoroutines();
    }

    public void Active()
    {
        this.gameObject.transform.parent.gameObject.SetActive(false);
    }
}
