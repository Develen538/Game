using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Segment _segmentTemplet;
    [SerializeField] private Block _blockTemplate;
    [SerializeField] private Finish _finishTamplate;

    private void Start()
    {
        BuildTower();
    }

    private void BuildTower()
    {
        GameObject CurrenPoint = gameObject;
        int towerSize = Random.Range(5,20);

        for (int i = 0; i < towerSize; i++)
        {
            CurrenPoint = BuildGame(CurrenPoint, _segmentTemplet.gameObject);

            CurrenPoint = BuildGame(CurrenPoint, _blockTemplate.gameObject);
        }

        BuildGame(CurrenPoint,_finishTamplate.gameObject);
    }

    private GameObject BuildGame(GameObject currenPoint, GameObject nextPoint)
    {
        return Instantiate(nextPoint,GetBuildPoint(currenPoint.transform,nextPoint.transform), Quaternion.identity,transform);
    }

    private Vector3 GetBuildPoint(Transform currenPoint, Transform nextPoint)
    {
        return new Vector3(transform.position.x,currenPoint.position.y + currenPoint.localScale.y / 2 + nextPoint.localScale.y /2, transform.position.z);
    }
}
