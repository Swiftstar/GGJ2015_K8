using UnityEngine;
using System.Collections;

public class MedicineButton : MonoBehaviour
{
    public GameObject MedicineObj;
    public GameObject MedicineBoom;

    public UISprite MedicineSprite;
    public UISprite GetHPAnmiationSprite;

    public TweenScale _TweenScale;
    public UIButtonSound _ButtonSound;

    public float GetHPTime = 1;

	void Start () 
    {
        UIEventListener.Get(MedicineObj).onClick = DestroyAnimation;
        StartCoroutine("GetHPTimer");
	}

    IEnumerator GetHPTimer()
    {
        yield return new WaitForSeconds(GetHPTime);
        Main.UIManager.Heal();
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

    void DestroyAnimation(GameObject e)
    {
        StopCoroutine("GetHPTimer");
        if (PlayerPrefs.GetInt("LevelSound") == 0)
        {

        }
        if (PlayerPrefs.GetInt("LevelSound") < 7)
        {
            PlayerPrefs.SetInt("LevelSound", PlayerPrefs.GetInt("LevelSound") + 1);
        }
        _ButtonSound.audioClip = Resources.Load("Sound/do0" + PlayerPrefs.GetInt("LevelSound")) as AudioClip;
        MedicineSprite.enabled = false;
        MedicineBoom.SetActive(true);
    }
}
