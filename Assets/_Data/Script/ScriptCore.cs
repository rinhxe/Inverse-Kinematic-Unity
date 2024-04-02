using DG.Tweening;
using System.Collections;
using UnityEngine;

public class ScriptCore: MonoBehaviour {
    //
    bool isInTrueZone = false;
    private void Update() {
        if(Input.GetMouseButtonUp(0)) {
            Debug.Log("Clicked");
            JumpAction();
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.name == "CharSensor") {
            //call done event move rigg
            //  Debug.Log("Enter");
            isInTrueZone = true;
        }

    }

    private void OnTriggerExit(Collider other) {
        if(other.name == "CharSensor") {
            //   Debug.Log("Exit");
            //call done event move rigg
            isInTrueZone = false;
        }
    }
    
  

    void JumpAction() {
        if(isInTrueZone) {
            //Debug.Log("Run event");
            //Run Event here

            //
            //PlayerMovement.instance.animationSpeed.
            // turn off rigbuilder            StartCoroutine(WaitOffRB());
            PlayerController.instance.SetRigBuilder(false);
            PlayerController.instance.TurnOffTargeting();

            //counteniue to walk            StartCoroutine(WaitToWalk());

            StartCoroutine(WaitForContinuePlayAnimation());

        }
        else {
            Debug.Log("Trigger");
        }
    }
    IEnumerator WaitForContinuePlayAnimation() {
        yield return new WaitForSeconds(1f);
        DOTween.To(() => PlayerMovement.instance.Animationspeed, x => PlayerMovement.instance.Animationspeed = x, 1, 2);
        yield return new WaitForSeconds(2f);
        PlayerMovement.instance.ResumePlayer();
    }


}
