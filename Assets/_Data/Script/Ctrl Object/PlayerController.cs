using DG.Tweening;
using System.Collections;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerController: MonoBehaviour {
    [Description("File for character rig solve")]
    public static PlayerController instance;
    [Tooltip("RigBuilder Inside PlayerObject")]
    [SerializeField] RigBuilder rigBuilder;
  
    //[SerializeField] TwoBoneIKConstraint[] boneIKConstraints;
    [SerializeField] RigControler rigControler;

    [SerializeField] Animator playerAnimator;
    private void Awake() {
        if (instance == null) {
        instance = this;
        }
    }

    public void SetRigBuilder(bool set) {
        if(!set) {
            rigControler.SafeTurnOffRigBuild();
        }
        else {
            rigBuilder.enabled = set;
        }
        
    }
    public void TurnOffTargeting() {
        rigControler.TurnOffAlLTarget();
    }

    public void CheckEndAnimation() {
        if(!CheckDoneProcess()) 
            return;
        playerAnimator.SetTrigger("CallSquat");
        StartCoroutine(DelayOffRig() );
        StartCoroutine(DelayshowUI());

    }

    IEnumerator DelayOffRig() {
        yield return new WaitForSeconds(0.2f);
        SetRigBuilder(false);
    }
    IEnumerator DelayshowUI() {
        yield return new WaitForSeconds(3f);
       

    }
    public bool CheckDoneProcess() {
        //foreach (var bone in boneIKConstraints) {
        //    if(bone.gameObject.GetComponent<BoneIKController>())
        //        if(bone.gameObject.GetComponent<BoneIKController>().Process==false) return false;
        
        //}
        return true;
    }
    public void ChangePlayerFaceCamera() {
        float duration = 1f;
        transform.DORotate(new Vector3(0, 180, 0), duration, RotateMode.Fast);

    }
    public void TurnOnRigTarget(BodyPart part) {
        rigControler.TurnOnTarget(part);
    }
}
