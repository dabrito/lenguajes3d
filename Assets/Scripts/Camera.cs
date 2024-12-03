using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
  // public GameObject Target;
  public Transform Target;
  public float SmoothSpeed = 0.125f;
  private Vector3 offset;
  // Start is called before the first frame update
  void Start()
  {
    offset = transform.position - Target.transform.position;
  }

  // Update is called once per frame
  // void Update()
  // {
  //   transform.position = Target.transform.position + offset;
  // }
  void Update()
  {
    // Vector3 desiredPosition = Target.transform.position + offset;
    Vector3 desiredPosition = Target.TransformPoint(offset);
    Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);
    transform.position = smoothedPosition;

    transform.LookAt(Target);
  }
}