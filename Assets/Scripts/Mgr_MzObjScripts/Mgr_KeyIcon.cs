using UnityEngine;

public class Mgr_KeyIcon : MonoBehaviour {

    [SerializeField]
    private GameObject[] keyIcons;

    public void UpdateKeyValue(int keyValue) {
        for (int i = 0; i < keyIcons.Length; i++) {
            if (i < keyValue)
            {
                keyIcons[i].SetActive(true);
            }
            else
            {
                keyIcons[i].SetActive(false);
            }
        }
    }
}