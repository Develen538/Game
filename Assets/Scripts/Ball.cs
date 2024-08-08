using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class Ball : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private int _numberScene;

    private Rigidbody _rigidbody;
    private AudioSource _audio;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _audio.Play();
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(Vector3.up * _force, ForceMode.Impulse);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = new Ray(transform.position, Vector3.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if(hitInfo.collider.TryGetComponent(out Segment segment))
                {
                    _rigidbody.isKinematic = true;
                    _rigidbody.velocity = Vector3.zero;
                }

                if(hitInfo.collider.TryGetComponent(out Finish finish))
                {
                    SceneManager.LoadScene(_numberScene);
                }
            }
        }
    }
}
