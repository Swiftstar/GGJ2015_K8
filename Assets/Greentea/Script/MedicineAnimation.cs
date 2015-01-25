using UnityEngine;
using System.Collections;

public class MedicineAnimation : MonoBehaviour {

    public UISprite CrossSprite;

    public void DestroyObject()
    {
        StartCoroutine(DestroyTimer());
    }

    IEnumerator DestroyTimer()
    {
        CrossSprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject.transform.parent.gameObject);
    }
}
