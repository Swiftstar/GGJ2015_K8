using UnityEngine;
using System.Collections;

public class MedicineButtonBig : MonoBehaviour
{
	public GameObject MedicineObj;
	public GameObject MedicineBoom;
	
	public UISprite MedicineSprite;
	public UISprite GetHPAnmiationSprite;
	
	public TweenScale _TweenScale;
	public UIButtonSound _ButtonSound;
	
	public float GetHPTime = 3.5f;

	public const int CLICK_MAX = 5;
	private int ClickNum = 0;
	
	void Start () 
	{
		UIEventListener.Get(MedicineObj).onClick = DestroyAnimation;
		StartCoroutine("GetHPTimer");
		ClickNum = 0;
	}

    void Update()
    {
        if (Main.Instance.status == Main.EGameStatus.StartScreen)
        {
            Destroy(this.gameObject);
            Destroy(GetHPAnmiationSprite.gameObject);
        }
    }
	
	IEnumerator GetHPTimer()
	{

		yield return new WaitForSeconds(GetHPTime);
		Main.UIManager.HealBig();
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
        CreateMedicine.Instance.StartCoroutine("CreateTimer");
		Destroy(this.gameObject);
		Destroy(GetHPAnmiationSprite.gameObject);
	}


    public AudioSource _AudioSource;
    public AudioClip GetHPClip;
    public AudioClip DieClip;

	void DestroyAnimation(GameObject e)
	{
		if ( ClickNum < CLICK_MAX )
		{
			ClickNum ++;
			transform.localScale *= 0.9f;
            _AudioSource.clip = DieClip;
            _AudioSource.Play();
			return;
		} // if
        if(ClickNum == CLICK_MAX)
        {
            StopCoroutine("GetHPTimer");
        }

		MedicineSprite.enabled = false;
		MedicineBoom.SetActive(true);
	}
}
