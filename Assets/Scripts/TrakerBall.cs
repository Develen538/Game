using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrakerBall : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private int _speed;

    private void FixedUpdate()
    {
        Vector3 vector = new Vector3(transform.position.x, _ball.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, vector, _speed * Time.fixedDeltaTime);
    }
}
