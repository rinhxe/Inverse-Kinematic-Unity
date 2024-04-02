using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;
public class RigControler: MonoBehaviour {
    [SerializeField] private GameObject hipsTarget;

    [SerializeField] private Rig rigTarget;
    public void TurnOffAlLTarget() {
        hipsTarget.SetActive(false);
    }
    public void TurnOnTarget(BodyPart part) {
        TurnOffAlLTarget();
        switch(part) {
            case BodyPart.Hand: {
                    break;
                }
            case BodyPart.Head: {
                    break;
                }
            case BodyPart.Spine: {
                    hipsTarget.SetActive(true);
                    break;
                }
            case BodyPart.Leg: {
                    break;
                }
        }
    }
    public void SafeTurnOffRigBuild() {
        float rigBuildTime = 1;
        StartCoroutine(WaitToTurnOffRigBuild(rigBuildTime));
        DOTween.To(() => rigTarget.weight, x => rigTarget.weight = x, 0, rigBuildTime);
    }

    IEnumerator WaitToTurnOffRigBuild(float t) {
        yield return new WaitForSeconds(t);
        PlayerController.instance.SetRigBuilder(false);
    }
}
