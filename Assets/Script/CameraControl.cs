using UnityEngine;

public class CameraControl : MonoBehaviour
{
    
    public float panSpeed = 30f;
    public float windowEdgeBorder = 10f;
    public float rotationPivotFactor = 70f;
    public float rotationSpeedPerFrame = .01f;

    [Header("CameraLimits")]
    public float leftLimit = 0f;
    public float rightLimit = 70f;
    public float upLimit = 65f;
    public float downLimit = -4f;
    public float zoomInLimit = 8f;
    public float zoomOutLimit = 55f;


    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.mousePosition.y;
        float mouseX = Input.mousePosition.x;

        /*
            Camera controls in this next condition after we
                check that the mouse is within the window
         */
        if (mouseX >= 0 && mouseX <= Screen.width &&
            mouseY >= 0 && mouseY <= Screen.height)
        {
            /* 
                Below we are checking that
                A.) a specific key is pressed
                B.) in some cases (left, right, back, forward) that the mouse is within the
                        edges of the screen via the border and Screen attributes
                C.) the camera's current position is not past the set limits

                Then we Translate that camera toward a certain direction relative to the 
                    World Space
             */



            // up with 'w'
            if ((Input.GetKey("w") || mouseY >= Screen.height - windowEdgeBorder) &&
                transform.position.z < upLimit) {
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime,
                                    Space.World);
            }

            // left with 'a'
            if ((Input.GetKey("a") || mouseX <= windowEdgeBorder) &&
                transform.position.x > leftLimit) {
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime,
                                    Space.World);
            }
            
            // down with 's'
            if ((Input.GetKey("s") || mouseY <= windowEdgeBorder) &&
                transform.position.z > downLimit) {
                transform.Translate(Vector3.back * panSpeed * Time.deltaTime,
                                    Space.World);
            }
            
            // right with 'd'
            if ((Input.GetKey("d") || mouseX >= Screen.width - windowEdgeBorder) &&
                transform.position.x < rightLimit) {
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime,
                                    Space.World);
            }
            
            // zoom in
            if (Input.GetKey("r") && transform.position.y > zoomInLimit) {
                transform.Translate(Vector3.down, Space.World);
                transform.Rotate(-rotationPivotFactor* rotationSpeedPerFrame, 0f, 0f, Space.Self);
            }
            
            // zoom out
            if (Input.GetKey("f") && transform.position.y < zoomOutLimit) {
                transform.Translate(Vector3.up, Space.World);
                transform.Rotate(rotationPivotFactor* rotationSpeedPerFrame, 0f, 0f, Space.Self);
            }
        }
    }
}
