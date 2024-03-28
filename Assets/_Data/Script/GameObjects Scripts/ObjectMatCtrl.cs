using UnityEngine;

public class ObjectMatCtrl: MonoBehaviour {
   
 
    [SerializeField] private ObjectType objectType;
    [SerializeField] private ActionType acionType;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "CharSensor") {
            BeginEventDefine(acionType);
        }

    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.name == "CharSensor") {
            UICtrl.instance.HideActionButton();
        }
    }

    void BeginEventDefine(ActionType type) {
        switch(type) {
            case ActionType.Squat: {
                    UICtrl.instance.ShowActionButton(type);
                    break;
                }
            default : break;
        }
    }

}
