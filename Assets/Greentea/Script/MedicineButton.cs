using UnityEngine;
using System.Collections;

public class MedicineButton : MonoBehaviour
{
    public GameObject MedicineObj;

    public float GetHPTime = 2;

	void Start () 
    {
        UIEventListener.Get(MedicineObj).onClick = DestroyAnimation;
        StartCoroutine("GetHPTimer");
	}

    IEnumerator GetHPTimer()
    {
        yield return new WaitForSeconds(GetHPTime);
        Debug.Log("I got HP");
        //GetHPAnimationPlay;
    }

    void DestroyAnimation(GameObject e)
    {
        Debug.Log("This Medicine is be destroyed");
        //DestroyAnimationPlay
    }
}
