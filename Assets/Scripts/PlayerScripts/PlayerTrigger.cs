using UnityEngine;

public class PlayerTrigger
{ 
    public static void CheckObstacle(GameObject obstacle, Player player, Canvas _statistics, Canvas gameOver)
    {
        if (obstacle.CompareTag("Obstacle"))
        {
            /// Stop time
            Time.timeScale = 0;

            /// Disable player controlls
            player.enabled = false;

            ///Disable statistics canvas and enable gameover canvas
            _statistics.enabled = false;
            gameOver.enabled = true;
        }
    }
}
