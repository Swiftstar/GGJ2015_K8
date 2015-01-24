using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateMedicine : MonoBehaviour {

    public GameObject MedicineObj;
    public Transform[] MedicinePosition;

    private float EveryMedicineCreateTime = 0.3f;
    private float CreateTime = 1f;
    private int Level = 1;

    void Start()
    {
        StartCoroutine("CreateTimer");
    }

    void Update()
    {
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
        Debug.Log(thisPartMode);
        pastPartMode = thisPartMode;
        StartCoroutine("CreateTimer");
    }

    public List<Transform> thisPartPosition = new List<Transform>();


}
