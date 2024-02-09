using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
Vector2 firstPressPos;
Vector2 secondPressPos;
Vector2 currentSwipe;
float allowedGap = 0.2f;
 
    void Update()
    {
        SwipeClick();
    }

    public void SwipeClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        }
        if(Input.GetMouseButtonUp(0))
        {
                //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        
                //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            
            //normalize the 2d vector
            currentSwipe.Normalize();
    
            //swipe upwards
            if(currentSwipe.y > 0 && currentSwipe.x > -allowedGap && currentSwipe.x < allowedGap)
            {
                OnSwipeUp();
            }
            //swipe down
            if(currentSwipe.y < 0 && currentSwipe.x > -allowedGap && currentSwipe.x < allowedGap)
            {
                OnSwipeDown();
            }
            //swipe left
            if(currentSwipe.x < 0 && currentSwipe.y > -allowedGap && currentSwipe.y < allowedGap)
            {
                OnSwipeLeft();
            }
            //swipe right
            if(currentSwipe.x > 0 && currentSwipe.y > -allowedGap && currentSwipe.y < allowedGap)
            {
                OnSwipeRight();
            }
        }
    }

	void OnSwipeUp ()
	{	
		Debug.Log("UP !");
	}

	void OnSwipeDown ()
	{
		Debug.Log("DOWN !");
	}

	void OnSwipeLeft ()
	{
		Debug.Log("LEFT !");
	}

	void OnSwipeRight ()
	{
		Debug.Log("RIGHT !");
	}
}
