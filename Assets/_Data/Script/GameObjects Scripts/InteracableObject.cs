using System.Collections;
using UnityEngine;
public class InteracableObject: MonoBehaviour {
    [SerializeField] private ObjectType objectType;
    [SerializeField] private ActionType acionType;
    [SerializeField] private int SwitchToCamera ;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "CharSensor") {
            BeginEventDefine(acionType);
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.name == "CharSensor") {
            EndEventDefine(acionType);
        }
    }
    void BeginEventDefine(ActionType type) {
        switch(type) {
            case ActionType.Squat: {
                    UICtrl.instance.ShowActionButton(type);
                    break;
                }
            case ActionType.Jump: {
                    if(!(SwitchToCamera==-1))
                        CamCtrl.instance.SwitchToCamera(SwitchToCamera);
                    PlayerMovement.instance.StopPlayer();
                    PlayerMovement.instance.playerAnimator.SetTrigger("CallJump");
                    PlayerController.instance.TurnOnRigTarget(BodyPart.Spine);
                    StartCoroutine(WaitFor(0.3f));  
                    
                    break;
                }
            case ActionType.Stop: {
                    PlayerMovement.instance.StopPlayer();
                    break;
                }
            default:
                break;
        }
    }
    void EndEventDefine(ActionType type) {
        switch(type) {
            
            case ActionType.Stop: {
                    
               
                    break;
                    
                }
            default:
                break;
        }    
    }
    IEnumerator WaitFor(float t) {
        yield return new WaitForSeconds(t);
        PlayerController.instance.SetRigBuilder(true);
        PlayerMovement.instance.Animationspeed = 0;
        Destroy(gameObject);
    }
    
}
