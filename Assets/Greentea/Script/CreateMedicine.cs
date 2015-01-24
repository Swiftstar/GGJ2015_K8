using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateMedicine : MonoBehaviour {

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
        
    }

    public void PlayGame()
    {
        StartCoroutine("CreateTimer");
    }

    void Update()
    {
        if (Main.Instance.status != Main.EGameStatus.Play)
            return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            Level = 1;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Level = 2;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Level = 3;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Level = 4;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Level = 5;
        }
    }

    IEnumerator CreateTimer()
    {
        yield return new WaitForSeconds(CreateTime);
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
        StartCoroutine("Mode",thisPartMode);
    }

    public List<Transform> thisPartPosition = new List<Transform>();

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
        StartCoroutine("CreateTimer");
    }
}

