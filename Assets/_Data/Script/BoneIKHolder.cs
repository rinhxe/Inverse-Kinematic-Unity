using System.Collections.Generic;
using UnityEngine;

public class BoneIKHolder: MonoBehaviour {

    [SerializeField] private GameObject PrefabForSquat;
    [SerializeField] private GameObject PrefabForEvade;

    List<GameObject> listPref;

    private void Start() {
        listPref = new List<GameObject>();
    }
    void SpanwnRigForAction(string action) {
        switch (action) {
            case "Squat" :  {
                    listPref.Clear();
                    foreach(GameObject pref in listPref) {
                        Instantiate(pref,transform);
                        listPref.Add(pref);
                    }
                    break;
                }
            default : {  
                    Debug.Log("No Action command found");
                    break;
                }
              
        }
    }
    void ClearRig() {
        for(int i = 0;i < transform.childCount;i++) {
            if(transform.GetChild(i))
            Destroy(transform.GetChild(i));
        }
        listPref.Clear();

    }
}
