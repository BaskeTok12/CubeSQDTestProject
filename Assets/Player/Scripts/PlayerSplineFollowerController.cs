using Spline;

namespace Player.Scripts
{
    public class PlayerSplineFollowerController : SplineFollowerController
    {
        private void OnEnable()
        {
            PlayerController.OnPlayerRunning += StartFollowing;
        }

        private void OnDisable()
        {
            PlayerController.OnPlayerRunning -= StartFollowing;
        }
    }
}