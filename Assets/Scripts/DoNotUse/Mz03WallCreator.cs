using UnityEngine;
using System.Collections;

public class Mz03WallCreator : MonoBehaviour {

    public GameObject prefab = null;

    void Awake()
    {
        for(int i = 0; i < 52; i += 2)
        {
            GameObject mzFloor = Instantiate(prefab) as GameObject;
            mzFloor.transform.position = new Vector3(
                    -25.0f + i,
                    1.0f,
                    25.0f);
        }

        for(int i = 0; i < 52; i += 2)
        {
            GameObject mzFloor = Instantiate(prefab) as GameObject;
            mzFloor.transform.position = new Vector3(
                    -25.0f,
                    1.0f,
                    25.0f - i);
        }

        for(int i = 0; i < 52; i += 2)
        {
            GameObject mzFloor = Instantiate(prefab) as GameObject;
            mzFloor.transform.position = new Vector3(
                    25.0f,
                    1.0f,
                    25.0f - i);
        }

        for(int i = 0; i < 48; i += 2)
        {
            GameObject mzFloor = Instantiate(prefab) as GameObject;
            mzFloor.transform.position = new Vector3(
                    -21.0f + i,
                    1.0f,
                    -25.0f);
        }

        Instantiate(this.prefab, new Vector3(-21, 1, 23), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-21, 1, 21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-17, 1, 21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-15, 1, 21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-13, 1, 21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-11, 1, 21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-9, 1, 21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-7, 1, 21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-5, 1, 21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-3, 1, 21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-1, 1, 21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(1, 1, 21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(3, 1, 21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(5, 1, 21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(7, 1, 21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(9, 1, 21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(13, 1, 21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(15, 1, 21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(17, 1, 21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(19, 1, 21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(21, 1, 21), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-21, 1, 19), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-17, 1, 19), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(9, 1, 19), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(13, 1, 19), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(19, 1, 19), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-17, 1, 17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-15, 1, 17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-13, 1, 17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-11, 1, 17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-7, 1, 17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-5, 1, 17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-3, 1, 17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-1, 1, 17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(1, 1, 17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(3, 1, 17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(5, 1, 17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(7, 1, 17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(9, 1, 17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(13, 1, 17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(15, 1, 17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(19, 1, 17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(21, 1, 17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(23, 1, 17), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-23, 1, 15), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-21, 1, 15), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(5, 1, 15), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(9, 1, 15), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(15, 1, 15), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-21, 1, 13), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(1, 1, 13), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(5, 1, 13), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(9, 1, 13), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(11, 1, 13), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(15, 1, 13), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(19, 1, 13), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(21, 1, 13), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-21, 1, 11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(1, 1, 11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(15, 1, 11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(17, 1, 11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(19, 1, 11), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-21, 1, 9), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(1, 1, 9), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(3, 1, 9), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(5, 1, 9), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(7, 1, 9), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(9, 1, 9), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(11, 1, 9), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(19, 1, 9), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(23, 1, 9), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-21, 1, 7), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-19, 1, 7), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-17, 1, 7), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(1, 1, 7), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(11, 1, 7), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(13, 1, 7), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(15, 1, 7), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(19, 1, 7), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-21, 1, 5), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-17, 1, 5), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(1, 1, 5), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(7, 1, 5), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(15, 1, 5), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(19, 1, 5), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-21, 1, 3), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-17, 1, 3), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(1, 1, 3), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(7, 1, 3), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(9, 1, 3), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(11, 1, 3), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(15, 1, 3), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(19, 1, 3), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-21, 1, 1), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(7, 1, 1), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(11, 1, 1), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(19, 1, 1), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-21, 1, -1), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-17, 1, -1), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-15, 1, -1), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-13, 1, -1), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-11, 1, -1), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-9, 1, -1), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-7, 1, -1), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-5, 1, -1), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-3, 1, -1), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-1, 1, -1), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(1, 1, -1), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(3, 1, -1), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(5, 1, -1), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(7, 1, -1), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(11, 1, -1), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(13, 1, -1), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(19, 1, -1), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-21, 1, -3), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-17, 1, -3), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-15, 1, -3), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-7, 1, -3), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-5, 1, -3), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-3, 1, -3), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(7, 1, -3), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(11, 1, -3), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(13, 1, -3), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(15, 1, -3), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(17, 1, -3), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(19, 1, -3), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-21, 1, -5), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-19, 1, -5), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-17, 1, -5), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-11, 1, -5), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-3, 1, -5), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-1, 1, -5), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(1, 1, -5), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(3, 1, -5), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(7, 1, -5), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(11, 1, -5), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(15, 1, -5), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(17, 1, -5), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-21, 1, -7), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-17, 1, -7), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-13, 1, -7), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-11, 1, -7), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-9, 1, -7), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-7, 1, -7), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(3, 1, -7), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(7, 1, -7), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(11, 1, -7), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(15, 1, -7), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(23, 1, -7), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-21, 1, -9), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-17, 1, -9), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-11, 1, -9), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(7, 1, -9), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(11, 1, -9), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(21, 1, -9), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(23, 1, -9), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-21, 1, -11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-17, 1, -11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-15, 1, -11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-7, 1, -11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(3, 1, -11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(7, 1, -11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(11, 1, -11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(13, 1, -11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(19, 1, -11), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(21, 1, -11), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-21, 1, -13), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-17, 1, -13), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-15, 1, -13), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-13, 1, -13), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-11, 1, -13), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-9, 1, -13), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-7, 1, -13), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(3, 1, -13), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(5, 1, -13), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(7, 1, -13), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(11, 1, -13), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-21, 1, -15), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(11, 1, -15), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(17, 1, -15), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(21, 1, -15), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-21, 1, -17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-19, 1, -17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-17, 1, -17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-15, 1, -17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-13, 1, -17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-11, 1, -17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-9, 1, -17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-7, 1, -17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-5, 1, -17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-3, 1, -17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-1, 1, -17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(1, 1, -17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(3, 1, -17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(5, 1, -17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(7, 1, -17), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(11, 1, -17), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(11, 1, -19), Quaternion.identity);

        Instantiate(this.prefab, new Vector3(-23, 1, -21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-21, 1, -21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-19, 1, -21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-17, 1, -21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-15, 1, -21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-13, 1, -21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-11, 1, -21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-9, 1, -21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-7, 1, -21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-5, 1, -21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-3, 1, -21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(-1, 1, -21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(1, 1, -21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(3, 1, -21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(5, 1, -21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(7, 1, -21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(9, 1, -21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(11, 1, -21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(13, 1, -21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(15, 1, -21), Quaternion.identity);
        Instantiate(this.prefab, new Vector3(17, 1, -21), Quaternion.identity);
    }
}