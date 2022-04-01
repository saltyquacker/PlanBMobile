using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class BallHandler : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject pivotObject;
    [SerializeField] private Rigidbody2D pivot;
    [SerializeField] private float detachDelay;
    [SerializeField] private float respawnDelay;
 

    private Rigidbody2D currentBallRigidbody;
    private CircleCollider2D currentBallCollider;
    private SpringJoint2D currentBallSprintJoint;

    [SerializeField]private GameObject lineObject;
    private LineRenderer linerenderer;
    private Camera mainCamera;
    private bool isDragging;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        linerenderer = lineObject.GetComponent<LineRenderer>();
        SpawnNewBall();
    }

    void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBallRigidbody == null) { return; }

        if (Touch.activeTouches.Count == 0)
        {
            if (isDragging)
            {
                currentBallCollider.enabled = true;
                currentBallRigidbody.constraints = RigidbodyConstraints2D.None;
                LaunchBall();
                linerenderer.SetPosition(0, new Vector3(0f, 0f, 0f));
                linerenderer.SetPosition(1, new Vector3(0f, 0f, 0f));
            }

            isDragging = false;

            return;
        }
      
           
        isDragging = true;
        currentBallRigidbody.isKinematic = true;

        Vector2 touchPosition = new Vector2();

        foreach(Touch touch in Touch.activeTouches)
        {
            touchPosition += touch.screenPosition;
        }

        touchPosition /= Touch.activeTouches.Count;

        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);
        if (worldPosition.x < pivotObject.transform.position.x)
        {
            
            currentBallRigidbody.position = worldPosition;
            currentBallRigidbody.constraints = RigidbodyConstraints2D.None;

            linerenderer.SetPosition(0, new Vector3(pivotObject.transform.position.x, pivotObject.transform.position.y, 0f));
            linerenderer.SetPosition(1, new Vector3(currentBallRigidbody.position.x, currentBallRigidbody.position.y, 0f));

        }
        else
        {
            currentBallRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            
        }

    }

    private void SpawnNewBall()
    {
        GameObject ballInstance = Instantiate(ballPrefab, pivot.position, Quaternion.identity);

        currentBallRigidbody = ballInstance.GetComponent<Rigidbody2D>();
        currentBallSprintJoint = ballInstance.GetComponent<SpringJoint2D>();
        currentBallCollider = ballInstance.GetComponent<CircleCollider2D>();

        currentBallCollider.enabled = false;
        currentBallSprintJoint.connectedBody = pivot;
    }

    private void LaunchBall()
    {
        currentBallRigidbody.isKinematic = false;
        currentBallRigidbody = null;

        Invoke(nameof(DetachBall), detachDelay);
    }

    private void DetachBall()
    {
        currentBallSprintJoint.enabled = false;
        currentBallSprintJoint = null;

        Invoke(nameof(SpawnNewBall), respawnDelay);
    }

 

 
}
