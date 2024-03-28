using UnityEngine;

public class TargetFinder: MonoBehaviour {
    [SerializeField] private Transform target;
    [SerializeField] private BoneIKController BIC;
    private void Update() {
        float distance = Vector3.Distance(transform.position, target.position);
      //  Debug.Log(distance);
        if(distance < 0.25f) {
            BIC.Process = true;
            BIC.DoneEvent();
        }
            
    }
}
