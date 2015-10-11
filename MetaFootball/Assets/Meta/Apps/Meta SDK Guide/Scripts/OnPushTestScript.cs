using UnityEngine;
using System.Collections;
using Meta.Apps.MetaSDKGuide;

namespace Assets.Meta.Apps.Meta_SDK_Guide.Scripts
{
    class OnPushTestScript : OnTouchEnterTestScript
    {

        Vector3 startPosition;
        float startTime;
        Vector3 stopPosition;
        float stopTime;
        float speed;

        public override void OnTouchEnter()
        {
            base.OnTouchEnter();
            startPosition = base.GetComponent<Renderer>().transform.position;
            startTime = Time.time;
        }

        public override void OnTouchExit()
        {
            base.OnTouchExit();
            stopPosition = base.GetComponent<Renderer>().transform.position;
            float distance = Distance3DCalc(startPosition, stopPosition);
            stopTime = Time.time;
            speed = distance / (stopTime - startTime);
            Debug.LogFormat("This is the speed: " + speed.ToString());

        }
        
        public float Distance3DCalc(Vector3 startPosition, Vector3 stopPosition)
        {
            
            float xDist = Mathf.Pow((stopPosition.x - startPosition.x),2);
            float yDist = Mathf.Pow((stopPosition.y - startPosition.y), 2);
            float zDist = Mathf.Pow((stopPosition.z - startPosition.z), 2);
            return Mathf.Sqrt(xDist + yDist + zDist);

        }
    }
}
