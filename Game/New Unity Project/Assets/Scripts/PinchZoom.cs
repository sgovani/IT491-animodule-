using UnityEngine;

public class PinchZoom : MonoBehaviour
{
    public float perspectiveZoomSpeed = 0.1f;        // The rate of change of the field of view in perspective mode.
    public float orthoZoomSpeed = 0.5f;        // The rate of change of the orthographic size in orthographic mode.
    public Camera main;

    void Update()
    {
       
        // If there are two touches on the device...
        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;
          //  Debug.Log(prevTouchDeltaMag);
            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
            if (Mathf.Sign(touchZero.position.x - touchZeroPrevPos.x)!= Mathf.Sign(touchOne.position.x-touchOnePrevPos.x) || Mathf.Sign(touchZero.position.y - touchZeroPrevPos.y) != Mathf.Sign(touchOne.position.y - touchOnePrevPos.y))
            {
                // If the camera is orthographic...
                if (main.orthographic)
                {
                    // ... change the orthographic size based on the change in distance between the touches.
                    main.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;

                    // Make sure the orthographic size never drops below zero.
                    main.orthographicSize = Mathf.Max(main.orthographicSize, 0.1f);
                }
                else
                {
                    // Otherwise change the field of view based on the change in distance between the touches.
                    main.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

                    // Clamp the field of view to make sure it's between 0 and 180.
                    main.fieldOfView = Mathf.Clamp(main.fieldOfView, 10f, 90f);
                }
                
            }
            else
            {
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

                
                float x;
                float y;
                //Makes sure camera is inside bounds, if so get the the new X and Y;
                if(main.transform.position.x <4 && main.transform.position.x > -4)
                {
                    x = -touchDeltaPosition.x;
                }
                else if(main.transform.position.x >=4 && -touchDeltaPosition.x < 0)
                {
                    x = -touchDeltaPosition.x;
                }else if(main.transform.position.x <=-4 && -touchDeltaPosition.x > 0)
                {
                    x = -touchDeltaPosition.x;
                }
                else
                {
                    x = 0.0f;
                }

                if (main.transform.position.y < 7 && main.transform.position.y > -7)
                {
                    y = -touchDeltaPosition.y;
                }
                else if (main.transform.position.y >= 7 && -touchDeltaPosition.y < 0)
                {
                    y = -touchDeltaPosition.y;
                }
                else if (main.transform.position.y <= -7 && -touchDeltaPosition.y > 0)
                {
                    y = -touchDeltaPosition.y;
                }
                else
                {
                    y = 0.0f;
                }
                //Moves the camera to the new location
                main.transform.Translate(x * 0.01f, y * 0.01f, 0);
            
                
                

            }
        }
    }
}