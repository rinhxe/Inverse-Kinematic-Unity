using UnityEngine;
public class RigControler: MonoBehaviour {
    [SerializeField] private GameObject hipsTarget;
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
}
