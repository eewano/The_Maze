using System.Collections.Generic;
using UnityEngine;

public class MzWallCreator : MonoBehaviour {

    [SerializeField]
    private GameObject mapBlockPrefab;
    [SerializeField]
    private string stageName;
    [SerializeField]
    private GameObject mzWallContainer;

    private List<Vector3> mapPositionList = new List<Vector3>();

    void Awake() {
        TextAsset textAsset = Resources.Load(this.stageName) as TextAsset;
        string[] textLines = textAsset.text.Split('\n');
        for (int i = 0; i < textLines.Length; i++) {
            string[] xyz = textLines[i].Split(',');

            this.mapPositionList.Add(new Vector3(
                    float.Parse(xyz[0]),
                    float.Parse(xyz[1]),
                    float.Parse(xyz[2])
            ));
        }

        this.makeMap();
    }

    public void makeMap() {
        for (int i = 0; i < this.mapPositionList.Count; i++) {
            Vector3 stagePosition = this.mapPositionList[i];
            GameObject wallBlock = Instantiate(
                    this.mapBlockPrefab,
                    stagePosition,
                    Quaternion.identity
            ) as GameObject;

            wallBlock.transform.SetParent(this.mzWallContainer.transform);
        }
    }
}