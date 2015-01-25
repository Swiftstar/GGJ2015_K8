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

    public void BigPillDestroyObject()
    {
        StartCoroutine(BigPillDestroyTimer());
    }

    IEnumerator BigPillDestroyTimer()
    {
        CrossSprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        CreateMedicine.Instance.StartCoroutine("CreateTimer");
        Destroy(this.gameObject.transform.parent.gameObject);

    }
}
