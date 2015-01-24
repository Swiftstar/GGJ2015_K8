using UnityEngine;
using System.Collections;

public class MedicineAnimation : MonoBehaviour {

    public void DestroyObject()
    {
        Destroy(this.gameObject.transform.parent.gameObject);
    }
}
