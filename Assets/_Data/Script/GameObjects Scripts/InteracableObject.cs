using UnityEngine;
public class InteracableObject: MonoBehaviour {
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
            case ActionType.Jump: {

                    //call jump

                    //drive animator.speed

                    break;
                }
            case ActionType.Stop: {
                    GameManager.instance.StopPlayer();
                    break;
                }
            default:
                break;
        }
    }
}
