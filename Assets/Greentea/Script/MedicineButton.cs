using UnityEngine;
using System.Collections;

public class MedicineButton : MonoBehaviour
{
    public GameObject MedicineObj;
    public GameObject MedicineBoom;

    public UISprite MedicineSprite;
    public UISprite GetHPAnmiationSprite;

    public TweenScale _TweenScale;

    public float GetHPTime = 1;

	void Start () 
    {
        UIEventListener.Get(MedicineObj).onClick = DestroyAnimation;
        StartCoroutine("GetHPTimer");
	}

    void Update()
    {
        if (Main.Instance.status == Main.EGameStatus.StartScreen )
        {
            Destroy(this.gameObject);
            Destroy(GetHPAnmiationSprite.gameObject);
        }
    }

    IEnumerator GetHPTimer()
    {
        yield return new WaitForSeconds(GetHPTime);
        Main.UIManager.Heal();
        _AudioSource.clip = GetHPClip;
        _AudioSource.Play();
        GetHPAnmiationSprite.enabled = true;
        this.gameObject.GetComponent<TweenAlpha>().enabled = true;
        GetHPAnmiationSprite.spriteName = "02";
        yield return new WaitForSeconds(0.1f);
        GetHPAnmiationSprite.spriteName = "03";
        yield return new WaitForSeconds(0.1f);
        GetHPAnmiationSprite.spriteName = "04";
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
        Destroy(GetHPAnmiationSprite.gameObject);
    }

    public AudioSource _AudioSource;
    public AudioClip GetHPClip;
    public AudioClip DieClip;
    void DestroyAnimation(GameObject e)
    {
        StopCoroutine("GetHPTimer");
        _AudioSource.clip = DieClip;
        _AudioSource.Play();
        MedicineSprite.enabled = false;
        MedicineBoom.SetActive(true);
    }
}
