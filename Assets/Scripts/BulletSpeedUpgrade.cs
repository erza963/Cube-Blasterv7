using UnityEngine;

public class BulletSpeedUpgrade : MonoBehaviour
{
    public PlayerShooting playerShooting;

    public void UpgradeBulletSpeed()
    {
        if (playerShooting != null)
        {
            playerShooting.bulletSpeed *= 2f; // You can adjust multiplier
            Debug.Log("Bullet Speed is now: " + playerShooting.bulletSpeed);
        }
    }
}
