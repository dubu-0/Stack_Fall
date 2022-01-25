using UnityEngine;

namespace StackFall
{
    public class TubeView : MonoBehaviour
    {
        public void SetLocalScale(SizeInt newLocalScale)
        {
            transform.localScale = new Vector3(newLocalScale.Width, newLocalScale.Height, newLocalScale.Width);
        }
    }
}
