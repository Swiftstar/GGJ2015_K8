using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateMedicine : MonoBehaviour
{

    private static CreateMedicine instance;
    public static CreateMedicine Instance
    {
        get
        {
            if (instance == null)
                instance = Object.FindObjectOfType<CreateMedicine>();
            return instance;
        } // get
    } // +Instance

    public GameObject MedicineObj;
    public Transform MedicineParent;
    public Transform[] MedicinePosition;

    private float EveryMedicineCreateTime = 0.3f;
    public float CreateTime = 1.5f;
    private int Level = 1;

    void Start()
    {
        PlayerPrefs.DeleteAll();
        StartCoroutine("GameTimer");
    }

    public void PlayGame()
    {
        StartCoroutine("CreateTimer");
    }

    public void ExitGame()
    {
        StopCoroutine("CreateTimer");
    }

    public GameObject[] Cancer;
    public GameObject[] spreadAnimation;
    public UISprite[] SpreadSprite;
    void Update()
    {
        if (Main.Instance.status != Main.EGameStatus.Play)
            return;

        switch (UIManage.Instance.tempI)
        {
            case 0:
                SpreadSprite[0].enabled = false;
                spreadAnimation[0].SetActive(true);
                break;
            case 1:
            case 2:
                SpreadSprite[0].enabled = true;
                spreadAnimation[0].SetActive(false);
                Cancer[0].SetActive(true);
                Cancer[1].SetActive(false);
                Cancer[2].SetActive(false);
                break;
            case 3:
                SpreadSprite[1].enabled = false;
                spreadAnimation[1].SetActive(true);
                break;
            case 4:
            case 5:
            case 6:
                spreadAnimation[1].SetActive(false);
                SpreadSprite[1].enabled = true;
                Cancer[0].SetActive(true);
                Cancer[1].SetActive(true);
                Cancer[2].SetActive(false);
                break;
            case 7:
                SpreadSprite[2].enabled = false;
                spreadAnimation[2].SetActive(true);
                break;
            case 8:
            case 9:
            case 10:
                spreadAnimation[2].SetActive(false);
                SpreadSprite[2].enabled = true;
                Cancer[0].SetActive(true);
                Cancer[1].SetActive(true);
                Cancer[2].SetActive(true);
                break;
        }
    }

    private int PartCount = 0;
    IEnumerator CreateTimer()
    {
        yield return new WaitForSeconds(CreateTime);

        if (PartCount < 8)
        {
            PartCount++;
            Debug.Log(PartCount);
        }
        ChoiceMode();
    }

    private int ModeCount = 0;

    private int pastPartMode = 0;
    private int thisPartMode = 0;

    public List<int> thisModeRandom = new List<int>();

    void ChoiceMode()
    {
        thisPartPosition.Clear();
        ModeCount = Level * 4;

        thisPartMode = Random.Range(1, ModeCount + 1);
        pastPartMode = thisPartMode;
        StartCoroutine("Mode", thisPartMode);
    }

    public List<Transform> thisPartPosition = new List<Transform>();
    public Transform[] BigPillPosition;
    public Transform BigPillParent;

    IEnumerator Mode(int mode)
    {
        switch (mode)
        { 
            case 1:
                thisPartPosition.Add(MedicinePosition[1]);
                thisPartPosition.Add(MedicinePosition[2]);
                thisPartPosition.Add(MedicinePosition[3]);
                break;
            case 2:
                thisPartPosition.Add(MedicinePosition[4]);
                thisPartPosition.Add(MedicinePosition[9]);
                thisPartPosition.Add(MedicinePosition[12]);
                break;
            case 3:
                thisPartPosition.Add(MedicinePosition[14]);
                thisPartPosition.Add(MedicinePosition[11]);
                thisPartPosition.Add(MedicinePosition[6]);
                break;
            case 4:
                thisPartPosition.Add(MedicinePosition[12]);
                thisPartPosition.Add(MedicinePosition[13]);
                thisPartPosition.Add(MedicinePosition[8]);
                break;
            case 5:
                thisPartPosition.Add(MedicinePosition[6]);
                thisPartPosition.Add(MedicinePosition[7]);
                thisPartPosition.Add(MedicinePosition[8]);
                thisPartPosition.Add(MedicinePosition[3]);
                break;
            case 6:
                thisPartPosition.Add(MedicinePosition[1]);
                thisPartPosition.Add(MedicinePosition[12]);
                thisPartPosition.Add(MedicinePosition[3]);
                thisPartPosition.Add(MedicinePosition[10]);
                break;
            case 7:
                thisPartPosition.Add(MedicinePosition[2]);
                thisPartPosition.Add(MedicinePosition[7]);
                thisPartPosition.Add(MedicinePosition[4]);
                thisPartPosition.Add(MedicinePosition[9]);
                break;
            case 8:
                thisPartPosition.Add(MedicinePosition[8]);
                thisPartPosition.Add(MedicinePosition[13]);
                thisPartPosition.Add(MedicinePosition[10]);
                thisPartPosition.Add(MedicinePosition[4]);
                break;
            case 9:
                thisPartPosition.Add(MedicinePosition[14]);
                thisPartPosition.Add(MedicinePosition[12]);
                thisPartPosition.Add(MedicinePosition[8]);
                thisPartPosition.Add(MedicinePosition[2]);
                thisPartPosition.Add(MedicinePosition[1]);
                break;
            case 10:
                thisPartPosition.Add(MedicinePosition[2]);
                thisPartPosition.Add(MedicinePosition[3]);
                thisPartPosition.Add(MedicinePosition[8]);
                thisPartPosition.Add(MedicinePosition[7]);
                thisPartPosition.Add(MedicinePosition[13]);
                break;
            case 11:
                thisPartPosition.Add(MedicinePosition[5]);
                thisPartPosition.Add(MedicinePosition[10]);
                thisPartPosition.Add(MedicinePosition[14]);
                thisPartPosition.Add(MedicinePosition[11]);
                thisPartPosition.Add(MedicinePosition[6]);
                break;
            case 12:
                thisPartPosition.Add(MedicinePosition[3]);
                thisPartPosition.Add(MedicinePosition[6]);
                thisPartPosition.Add(MedicinePosition[14]);
                thisPartPosition.Add(MedicinePosition[10]);
                thisPartPosition.Add(MedicinePosition[5]);
                break;
            case 13:
                thisPartPosition.Add(MedicinePosition[7]);
                thisPartPosition.Add(MedicinePosition[11]);
                thisPartPosition.Add(MedicinePosition[13]);
                thisPartPosition.Add(MedicinePosition[1]);
                thisPartPosition.Add(MedicinePosition[14]);
                thisPartPosition.Add(MedicinePosition[7]);
                break;
            case 14:
                thisPartPosition.Add(MedicinePosition[4]);
                thisPartPosition.Add(MedicinePosition[3]);
                thisPartPosition.Add(MedicinePosition[2]);
                thisPartPosition.Add(MedicinePosition[14]);
                thisPartPosition.Add(MedicinePosition[13]);
                thisPartPosition.Add(MedicinePosition[9]);
                break;
            case 15:
                thisPartPosition.Add(MedicinePosition[10]);
                thisPartPosition.Add(MedicinePosition[11]);
                thisPartPosition.Add(MedicinePosition[1]);
                thisPartPosition.Add(MedicinePosition[8]);
                thisPartPosition.Add(MedicinePosition[4]);
                thisPartPosition.Add(MedicinePosition[5]);
                break;
            case 16:
                thisPartPosition.Add(MedicinePosition[13]);
                thisPartPosition.Add(MedicinePosition[10]);
                thisPartPosition.Add(MedicinePosition[9]);
                thisPartPosition.Add(MedicinePosition[8]);
                thisPartPosition.Add(MedicinePosition[3]);
                thisPartPosition.Add(MedicinePosition[2]);
                break;
            case 17:
                thisPartPosition.Add(MedicinePosition[9]);
                thisPartPosition.Add(MedicinePosition[8]);
                thisPartPosition.Add(MedicinePosition[7]);
                thisPartPosition.Add(MedicinePosition[6]);
                thisPartPosition.Add(MedicinePosition[11]);
                thisPartPosition.Add(MedicinePosition[14]);
                thisPartPosition.Add(MedicinePosition[12]);
                break;
            case 18:
                thisPartPosition.Add(MedicinePosition[5]);
                thisPartPosition.Add(MedicinePosition[1]);
                thisPartPosition.Add(MedicinePosition[7]);
                thisPartPosition.Add(MedicinePosition[6]);
                thisPartPosition.Add(MedicinePosition[12]);
                thisPartPosition.Add(MedicinePosition[11]);
                thisPartPosition.Add(MedicinePosition[14]);
                break;
            case 19:
                thisPartPosition.Add(MedicinePosition[13]);
                thisPartPosition.Add(MedicinePosition[7]);
                thisPartPosition.Add(MedicinePosition[2]);
                thisPartPosition.Add(MedicinePosition[3]);
                thisPartPosition.Add(MedicinePosition[9]);
                thisPartPosition.Add(MedicinePosition[13]);
                thisPartPosition.Add(MedicinePosition[8]);
                break;
            case 20:
                thisPartPosition.Add(MedicinePosition[11]);
                thisPartPosition.Add(MedicinePosition[12]);
                thisPartPosition.Add(MedicinePosition[13]);
                thisPartPosition.Add(MedicinePosition[9]);
                thisPartPosition.Add(MedicinePosition[4]);
                thisPartPosition.Add(MedicinePosition[11]);
                thisPartPosition.Add(MedicinePosition[14]);
                break;
        }

        for (int i = 0; i < thisPartPosition.Count; i++)
        {
            GameObject go = Instantiate(Resources.Load("Prefabs/Medicine"), thisPartPosition[i].position, thisPartPosition[i].rotation) as GameObject;
            go.name = thisPartPosition[i].name;
            go.transform.parent = MedicineParent;
            go.transform.localScale = new Vector2(24.95498f, 32.76141f);
            yield return new WaitForSeconds(EveryMedicineCreateTime);
        }

        if (PartCount == 8)
        {
            yield return new WaitForSeconds(EveryMedicineCreateTime + 1.2f);
            GameObject go = Instantiate(Resources.Load("Prefabs/MedicineBig"), Vector3.zero, Quaternion.identity) as GameObject;
            go.name = "1";
            go.transform.parent = BigPillParent;
            go.transform.localScale = new Vector2(90, 120);

            PartCount = 0;
            StopCoroutine("CreateTimer");
        }
        else
        {
            StartCoroutine("CreateTimer");
        }
    }

    private int GameTime;
    IEnumerator GameTimer()
    {
        yield return new WaitForSeconds(1f);
        GameTime++;
        if (GameTime < 10) { Level = 1; }
        else if (GameTime < 30) { Level = 2; }
        else if (GameTime < 50) { Level = 3; }
        else if (GameTime < 85) { Level = 4; }
        else { Level = 5; }

        StartCoroutine("GameTimer");
    }
}

