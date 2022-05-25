using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    public class BackgroundPartView : MonoBehaviour
    {
        [SerializeField] private float _leftBorder;
        [SerializeField] private float _rightBorder;
        [SerializeField] private float _relativeSpeedRate;

        public void Move(float value)
        {
            transform.position += _relativeSpeedRate * value * Vector3.left;
            if (transform.position.x < _leftBorder) 
                transform.position = new Vector3(_rightBorder - (_leftBorder - transform.position.x), 
                    transform.position.y, transform.position.z);
            else if (transform.position.x > _rightBorder)
                transform.position = new Vector3(_leftBorder - (_rightBorder - transform.position.x),
                    transform.position.y, transform.position.z);
        }
    }
}
