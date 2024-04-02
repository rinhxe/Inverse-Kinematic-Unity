using UnityEngine;

public class InputCtrl: MonoBehaviour {
    public static InputCtrl instance;
    [SerializeField] private Joytick Joytick;

    private void Awake() {
        if(instance == null) {
            instance = this;
        }


    }

    public void HideJoytick() {
        Joytick.SafeTurnOffJoytick();
        Joytick.gameObject.SetActive(false);

    }
    public void ShowJoytick() {
        Joytick.SafeTurnOnJoytick();
        Joytick.gameObject.SetActive(true);
    }

}
