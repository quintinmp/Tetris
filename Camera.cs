using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tetris
{
    public class Camera
    {

        private int _screenWidth, _screenHeight;
        private float _fieldOfView;
        private Vector3 _position, _target;

        private Matrix _view, _projection;

        private const float nearPlane = 0.01f;
        private const float farPlane = 100f;


        public Camera(Vector3 position, Vector3 target, int screenWidth, int screenHeight, float fieldOfView)
        {
            _position = position;
            _target = target;
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
            _fieldOfView = fieldOfView;

            CalculateMatrices();
        }

        private void CalculateMatrices()
        {
            _view = Matrix.CreateLookAt(_position, _target, Vector3.Up);
            float aspect = (float)_screenWidth/(float)_screenHeight;
            _projection = Matrix.CreatePerspectiveFieldOfView(_fieldOfView, aspect, nearPlane, farPlane);
        }

        public Matrix View
        {
            get { return _view; }
        }

        public Matrix Projection
        {
            get { return _projection; }
        }

        public void SetCameraPosition(Vector3 position)
        {
            _position = position;
            CalculateMatrices ();
        }

        public void SetCameraTarget(Vector3 target)
        {
            _target = target;
            CalculateMatrices ();
        }
    }
}
