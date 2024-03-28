using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerController: MonoBehaviour {
    
    public static PlayerController instance;
    
    
    [Tooltip("RigBuilder Inside PlayerObject")]
    [SerializeField] RigBuilder rigBuilder;
    [Tooltip("RigBuilder Rig 1 Object")]
    [SerializeField] Rig rigHandle;
    [Tooltip("Bone IK Contraints Holder")]
    [SerializeField] BoneIKHolder boneIKHolder;
    //[SerializeField] TwoBoneIKConstraint[] boneIKConstraints;
    [SerializeField] Animator playerAnimator;
    private void Awake() {
        if (instance == null) {
        instance = this;
        }
    }

    public void SetRigStatus(bool set) {
        rigHandle.gameObject.SetActive(set);
        //foreach (var bone in boneIKConstraints) {
            
        //    bone.gameObject.SetActive(true);
        //}
    }

    public void SetRigBuilder(bool set) {
        rigBuilder.enabled = set;
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
        UICtrl.instance.EndSquat();

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
}
