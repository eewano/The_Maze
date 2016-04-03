using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mz02WallCreator : MonoBehaviour {

    public GameObject prefab = null;

    [SerializeField]
    private GameObject stage2WallContainer;

    private List<Vector3> stage2MapPositionList = new List<Vector3>(){
        new Vector3(-21, 1, 21),
        new Vector3(-19, 1, 21),
        new Vector3(-17, 1, 21),
        new Vector3(-15, 1, 21),
        new Vector3(-13, 1, 21),
        new Vector3(-11, 1, 21),
        new Vector3(-9, 1, 21),
        new Vector3(-7, 1, 21),
        new Vector3(-5, 1, 21),
        new Vector3(-3, 1, 21),
        new Vector3(-1, 1, 21),
        new Vector3(3, 1, 21),
        new Vector3(5, 1, 21),
        new Vector3(7, 1, 21),
        new Vector3(9, 1, 21),
        new Vector3(11, 1, 21),
        new Vector3(13, 1, 21),
        new Vector3(15, 1, 21),
        new Vector3(17, 1, 21),
        new Vector3(19, 1, 21),
        new Vector3(21, 1, 21),
        new Vector3(-21, 1, 19),
        new Vector3(-1, 1, 19),
        new Vector3(3, 1, 19),
        new Vector3(21, 1, 19),
        new Vector3(-21, 1, 17),
        new Vector3(-15, 1, 17),
        new Vector3(-13, 1, 17),
        new Vector3(-11, 1, 17),
        new Vector3(-9, 1, 17),
        new Vector3(-7, 1, 17),
        new Vector3(-5, 1, 17),
        new Vector3(-1, 1, 17),
        new Vector3(3, 1, 17),
        new Vector3(7, 1, 17),
        new Vector3(9, 1, 17),
        new Vector3(13, 1, 17),
        new Vector3(17, 1, 17),
        new Vector3(21, 1, 17),
        new Vector3(-21, 1, 15),
        new Vector3(-19, 1, 15),
        new Vector3(-15, 1, 15),
        new Vector3(-5, 1, 15),
        new Vector3(3, 1, 15),
        new Vector3(7, 1, 15),
        new Vector3(21, 1, 15),
        new Vector3(-21, 1, 13),
        new Vector3(-15, 1, 13),
        new Vector3(-9, 1, 13),
        new Vector3(-5, 1, 13),
        new Vector3(-3, 1, 13),
        new Vector3(-1, 1, 13),
        new Vector3(1, 1, 13),
        new Vector3(3, 1, 13),
        new Vector3(7, 1, 13),
        new Vector3(11, 1, 13),
        new Vector3(15, 1, 13),
        new Vector3(19, 1, 13),
        new Vector3(21, 1, 13),
        new Vector3(-21, 1, 11),
        new Vector3(-17, 1, 11),
        new Vector3(7, 1, 11),
        new Vector3(21, 1, 11),
        new Vector3(-21, 1, 9),
        new Vector3(-15, 1, 9),
        new Vector3(-11, 1, 9),
        new Vector3(-5, 1, 9),
        new Vector3(-3, 1, 9),
        new Vector3(-1, 1, 9),
        new Vector3(1, 1, 9),
        new Vector3(3, 1, 9),
        new Vector3(5, 1, 9),
        new Vector3(7, 1, 9),
        new Vector3(9, 1, 9),
        new Vector3(13, 1, 9),
        new Vector3(17, 1, 9),
        new Vector3(21, 1, 9),
        new Vector3(-21, 1, 7),
        new Vector3(-17, 1, 7),
        new Vector3(-9, 1, 7),
        new Vector3(7, 1, 7),
        new Vector3(21, 1, 7),
        new Vector3(-21, 1, 5),
        new Vector3(-15, 1, 5),
        new Vector3(-5, 1, 5),
        new Vector3(-3, 1, 5),
        new Vector3(3, 1, 5),
        new Vector3(7, 1, 5),
        new Vector3(11, 1, 5),
        new Vector3(15, 1, 5),
        new Vector3(19, 1, 5),
        new Vector3(21, 1, 5),
        new Vector3(-21, 1, 3),
        new Vector3(-13, 1, 3),
        new Vector3(-7, 1, 3),
        new Vector3(-3, 1, 3),
        new Vector3(3, 1, 3),
        new Vector3(5, 1, 3),
        new Vector3(7, 1, 3),
        new Vector3(21, 1, 3),
        new Vector3(-21, 1, 1),
        new Vector3(-15, 1, 1),
        new Vector3(-3, 1, 1),
        new Vector3(3, 1, 1),
        new Vector3(13, 1, 1),
        new Vector3(17, 1, 1),
        new Vector3(21, 1, 1),
        new Vector3(-21, 1, -1),
        new Vector3(-17, 1, -1),
        new Vector3(-11, 1, -1),
        new Vector3(-7, 1, -1),
        new Vector3(-3, 1, -1),
        new Vector3(3, 1, -1),
        new Vector3(7, 1, -1),
        new Vector3(9, 1, -1),
        new Vector3(21, 1, -1),
        new Vector3(-21, 1, -3),
        new Vector3(-3, 1, -3),
        new Vector3(3, 1, -3),
        new Vector3(9, 1, -3),
        new Vector3(13, 1, -3),
        new Vector3(15, 1, -3),
        new Vector3(17, 1, -3),
        new Vector3(19, 1, -3),
        new Vector3(21, 1, -3),
        new Vector3(-21, 1, -5),
        new Vector3(-17, 1, -5),
        new Vector3(-15, 1, -5),
        new Vector3(-13, 1, -5),
        new Vector3(-11, 1, -5),
        new Vector3(-9, 1, -5),
        new Vector3(-7, 1, -5),
        new Vector3(-5, 1, -5),
        new Vector3(-3, 1, -5),
        new Vector3(1, 1, -5),
        new Vector3(3, 1, -5),
        new Vector3(5, 1, -5),
        new Vector3(9, 1, -5),
        new Vector3(13, 1, -5),
        new Vector3(21, 1, -5),
        new Vector3(-21, 1, -7),
        new Vector3(-15, 1, -7),
        new Vector3(-13, 1, -7),
        new Vector3(1, 1, -7),
        new Vector3(9, 1, -7),
        new Vector3(17, 1, -7),
        new Vector3(21, 1, -7),
        new Vector3(-21, 1, -9),
        new Vector3(-15, 1, -9),
        new Vector3(-13, 1, -9),
        new Vector3(-7, 1, -9),
        new Vector3(-3, 1, -9),
        new Vector3(-1, 1, -9),
        new Vector3(1, 1, -9),
        new Vector3(5, 1, -9),
        new Vector3(7, 1, -9),
        new Vector3(9, 1, -9),
        new Vector3(11, 1, -9),
        new Vector3(13, 1, -9),
        new Vector3(15, 1, -9),
        new Vector3(17, 1, -9),
        new Vector3(21, 1, -9),
        new Vector3(-21, 1, -11),
        new Vector3(-7, 1, -11),
        new Vector3(-3, 1, -11),
        new Vector3(5, 1, -11),
        new Vector3(13, 1, -11),
        new Vector3(21, 1, -11),
        new Vector3(-21, 1, -13),
        new Vector3(-17, 1, -13),
        new Vector3(-15, 1, -13),
        new Vector3(-13, 1, -13),
        new Vector3(-11, 1, -13),
        new Vector3(-9, 1, -13),
        new Vector3(-7, 1, -13),
        new Vector3(-3, 1, -13),
        new Vector3(1, 1, -13),
        new Vector3(3, 1, -13),
        new Vector3(5, 1, -13),
        new Vector3(9, 1, -13),
        new Vector3(13, 1, -13),
        new Vector3(15, 1, -13),
        new Vector3(19, 1, -13),
        new Vector3(21, 1, -13),
        new Vector3(-21, 1, -15),
        new Vector3(-15, 1, -15),
        new Vector3(-13, 1, -15),
        new Vector3(-7, 1, -15),
        new Vector3(9, 1, -15),
        new Vector3(13, 1, -15),
        new Vector3(21, 1, -15),
        new Vector3(-21, 1, -17),
        new Vector3(-15, 1, -17),
        new Vector3(-13, 1, -17),
        new Vector3(-7, 1, -17),
        new Vector3(-5, 1, -17),
        new Vector3(-3, 1, -17),
        new Vector3(1, 1, -17),
        new Vector3(3, 1, -17),
        new Vector3(5, 1, -17),
        new Vector3(7, 1, -17),
        new Vector3(9, 1, -17),
        new Vector3(13, 1, -17),
        new Vector3(15, 1, -17),
        new Vector3(19, 1, -17),
        new Vector3(21, 1, -17),
        new Vector3(-21, 1, -19),
        new Vector3(1, 1, -19),
        new Vector3(21, 1, -19),
        new Vector3(-21, 1, -21),
        new Vector3(-19, 1, -21),
        new Vector3(-17, 1, -21),
        new Vector3(-15, 1, -21),
        new Vector3(-13, 1, -21),
        new Vector3(-11, 1, -21),
        new Vector3(-9, 1, -21),
        new Vector3(-7, 1, -21),
        new Vector3(-5, 1, -21),
        new Vector3(-3, 1, -21),
        new Vector3(-1, 1, -21),
        new Vector3(1, 1, -21),
        new Vector3(3, 1, -21),
        new Vector3(5, 1, -21),
        new Vector3(7, 1, -21),
        new Vector3(9, 1, -21),
        new Vector3(11, 1, -21),
        new Vector3(13, 1, -21),
        new Vector3(15, 1, -21),
        new Vector3(17, 1, -21),
        new Vector3(19, 1, -21),
        new Vector3(21, 1, -21)
    };


    void Awake()
    {
        for (int i = 0; i < this.stage2MapPositionList.Count; i++) {
             Vector3 stagePosition = this.stage2MapPositionList[i];
             GameObject wallBlock = Instantiate(this.prefab, stagePosition, Quaternion.identity) as GameObject;
            wallBlock.transform.SetParent(this.stage2WallContainer.transform);
        }

//        Instantiate(this.prefab, new Vector3(-21, 1, 21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-17, 1, 21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-15, 1, 21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-13, 1, 21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-19, 1, 21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-11, 1, 21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-9, 1, 21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-7, 1, 21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-5, 1, 21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-3, 1, 21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-1, 1, 21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(3, 1, 21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(5, 1, 21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(7, 1, 21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(9, 1, 21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(11, 1, 21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(13, 1, 21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(15, 1, 21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(17, 1, 21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(19, 1, 21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(21, 1, 21), Quaternion.identity);
//
//        Instantiate(this.prefab, new Vector3(-21, 1, 19), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-1, 1, 19), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(3, 1, 19), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(21, 1, 19), Quaternion.identity);
//
//        Instantiate(this.prefab, new Vector3(-21, 1, 17), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-15, 1, 17), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-13, 1, 17), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-11, 1, 17), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-9, 1, 17), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-7, 1, 17), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-5, 1, 17), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-1, 1, 17), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(3, 1, 17), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(7, 1, 17), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(9, 1, 17), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(13, 1, 17), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(17, 1, 17), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(21, 1, 17), Quaternion.identity);
//
//        Instantiate(this.prefab, new Vector3(-21, 1, 15), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-19, 1, 15), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-15, 1, 15), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-5, 1, 15), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(3, 1, 15), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(7, 1, 15), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(21, 1, 15), Quaternion.identity);
//
//        Instantiate(this.prefab, new Vector3(-21, 1, 13), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-15, 1, 13), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-9, 1, 13), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-5, 1, 13), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-3, 1, 13), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-1, 1, 13), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(1, 1, 13), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(3, 1, 13), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(7, 1, 13), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(11, 1, 13), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(15, 1, 13), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(19, 1, 13), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(21, 1, 13), Quaternion.identity);
//
//        Instantiate(this.prefab, new Vector3(-21, 1, 11), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-17, 1, 11), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(7, 1, 11), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(21, 1, 11), Quaternion.identity);
//
//        Instantiate(this.prefab, new Vector3(-21, 1, 9), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-15, 1, 9), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-11, 1, 9), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-5, 1, 9), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-3, 1, 9), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-1, 1, 9), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(1, 1, 9), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(3, 1, 9), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(5, 1, 9), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(7, 1, 9), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(9, 1, 9), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(13, 1, 9), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(17, 1, 9), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(21, 1, 9), Quaternion.identity);
//
//        Instantiate(this.prefab, new Vector3(-21, 1, 7), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-17, 1, 7), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-9, 1, 7), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(7, 1, 7), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(21, 1, 7), Quaternion.identity);
//
//        Instantiate(this.prefab, new Vector3(-21, 1, 5), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-15, 1, 5), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-5, 1, 5), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-3, 1, 5), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(3, 1, 5), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(7, 1, 5), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(11, 1, 5), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(15, 1, 5), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(19, 1, 5), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(21, 1, 5), Quaternion.identity);
//
//        Instantiate(this.prefab, new Vector3(-21, 1, 3), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-13, 1, 3), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-7, 1, 3), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-3, 1, 3), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(3, 1, 3), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(5, 1, 3), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(7, 1, 3), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(21, 1, 3), Quaternion.identity);
//
//        Instantiate(this.prefab, new Vector3(-21, 1, 1), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-15, 1, 1), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-3, 1, 1), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(3, 1, 1), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(13, 1, 1), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(17, 1, 1), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(21, 1, 1), Quaternion.identity);
//
//        Instantiate(this.prefab, new Vector3(-21, 1, -1), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-17, 1, -1), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-11, 1, -1), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-7, 1, -1), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-3, 1, -1), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(3, 1, -1), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(7, 1, -1), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(9, 1, -1), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(21, 1, -1), Quaternion.identity);
//
//        Instantiate(this.prefab, new Vector3(-21, 1, -3), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-3, 1, -3), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(3, 1, -3), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(9, 1, -3), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(13, 1, -3), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(15, 1, -3), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(17, 1, -3), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(19, 1, -3), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(21, 1, -3), Quaternion.identity);
//
//        Instantiate(this.prefab, new Vector3(-21, 1, -5), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-17, 1, -5), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-15, 1, -5), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-13, 1, -5), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-11, 1, -5), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-9, 1, -5), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-7, 1, -5), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-5, 1, -5), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-3, 1, -5), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(1, 1, -5), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(3, 1, -5), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(5, 1, -5), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(9, 1, -5), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(13, 1, -5), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(21, 1, -5), Quaternion.identity);
//
//        Instantiate(this.prefab, new Vector3(-21, 1, -7), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-15, 1, -7), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-13, 1, -7), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(1, 1, -7), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(9, 1, -7), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(17, 1, -7), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(21, 1, -7), Quaternion.identity);
//
//        Instantiate(this.prefab, new Vector3(-21, 1, -9), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-15, 1, -9), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-13, 1, -9), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-7, 1, -9), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-3, 1, -9), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-1, 1, -9), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(1, 1, -9), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(5, 1, -9), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(7, 1, -9), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(9, 1, -9), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(11, 1, -9), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(13, 1, -9), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(15, 1, -9), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(17, 1, -9), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(21, 1, -9), Quaternion.identity);
//
//        Instantiate(this.prefab, new Vector3(-21, 1, -11), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-7, 1, -11), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-3, 1, -11), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(5, 1, -11), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(13, 1, -11), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(21, 1, -11), Quaternion.identity);
//
//        Instantiate(this.prefab, new Vector3(-21, 1, -13), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-17, 1, -13), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-15, 1, -13), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-13, 1, -13), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-11, 1, -13), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-9, 1, -13), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-7, 1, -13), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-3, 1, -13), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(1, 1, -13), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(3, 1, -13), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(5, 1, -13), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(9, 1, -13), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(13, 1, -13), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(15, 1, -13), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(19, 1, -13), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(21, 1, -13), Quaternion.identity);
//
//        Instantiate(this.prefab, new Vector3(-21, 1, -15), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-15, 1, -15), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-13, 1, -15), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-7, 1, -15), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(9, 1, -15), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(13, 1, -15), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(21, 1, -15), Quaternion.identity);
//
//        Instantiate(this.prefab, new Vector3(-21, 1, -17), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-15, 1, -17), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-13, 1, -17), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-7, 1, -17), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-5, 1, -17), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-3, 1, -17), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(1, 1, -17), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(3, 1, -17), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(5, 1, -17), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(7, 1, -17), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(9, 1, -17), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(13, 1, -17), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(15, 1, -17), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(19, 1, -17), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(21, 1, -17), Quaternion.identity);
//
//        Instantiate(this.prefab, new Vector3(-21, 1, -19), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(1, 1, -19), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(21, 1, -19), Quaternion.identity);
//
//        Instantiate(this.prefab, new Vector3(-21, 1, -21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-19, 1, -21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-17, 1, -21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-15, 1, -21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-13, 1, -21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-11, 1, -21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-9, 1, -21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-7, 1, -21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-5, 1, -21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-3, 1, -21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(-1, 1, -21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(1, 1, -21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(3, 1, -21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(5, 1, -21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(7, 1, -21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(9, 1, -21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(11, 1, -21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(13, 1, -21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(15, 1, -21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(17, 1, -21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(19, 1, -21), Quaternion.identity);
//        Instantiate(this.prefab, new Vector3(21, 1, -21), Quaternion.identity);
    }
}
