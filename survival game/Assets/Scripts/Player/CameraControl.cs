using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 1, 0);
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 10F;
    public float sensitivityY = 10F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationY = 0F;


    void Update()
    {
        if (!Player.instance.isPaused)
        {
            if (axes == RotationAxes.MouseXAndY)
            {
                float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            }
            else if (axes == RotationAxes.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
            }
            else
            {
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
            }
        }

        /*if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (player.weapon != null)
            {
                string ShotType = "Single";
                int ShotCount = 1;
                int Size = 1;
                int Speed = 1;

                if (player.weapon.AmmoCount > 0)
                {

                    foreach (var a in player.weapon.Tags)
                    {
                        if (a.Item1.Equals("ShotType")) { ShotType = a.Item2; }
                        else if (a.Item1.Equals("ShotCount")) { ShotCount = int.Parse(a.Item2); }
                        else if (a.Item1.Equals("Size")) { Size = int.Parse(a.Item2); }
                        else if (a.Item1.Equals("Speed")) { Speed = int.Parse(a.Item2); }
                    }


                    if (ShotType.Equals("Single"))
                    {
                        var obj = (GameObject)Instantiate(bullet, transform.position + transform.rotation * Vector3.forward, Quaternion.identity);
                        obj.GetComponent<Rigidbody>().velocity = transform.rotation * Vector3.forward * Speed;
                    }

                    else if (ShotType.Equals("Spread"))
                    {
                        for (int i = 0; i < ShotCount; i++)
                        {
                            var obj = (GameObject)Instantiate(
                                bullet,
                                transform.position + transform.rotation * Vector3.forward,
                                Quaternion.Euler(
                                    Random.Range(-7, 7) + transform.rotation.eulerAngles.x,
                                    Random.Range(-7, 7) + transform.rotation.eulerAngles.y,
                                    transform.rotation.eulerAngles.z)
                                );
                            obj.GetComponent<Rigidbody>().velocity = obj.transform.rotation * Vector3.forward * Speed;
                        }
                    }

                    player.weapon.AmmoCount--;
                }

                else
                {
                    Debug.Log("Out Of Ammo");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (player.weapon.AmmoCount >= 1)
            {
                //play anim 1
                if (player.player.hasItem(player.weapon.Ammo, (player.weapon.Magazine + 1) - player.weapon.AmmoCount))
                {
                    player.player.removeItem(player.weapon.Ammo, (player.weapon.Magazine + 1) - player.weapon.AmmoCount);
                    player.weapon.AmmoCount = player.weapon.Magazine + 1;
                }
                else
                {
                    Debug.Log("Out of ammo");
                }
            }
            else
            {
                //play anim 2
                if (player.player.hasItem(player.weapon.Ammo, player.weapon.Magazine))
                {
                    player.player.removeItem(player.weapon.Ammo, player.weapon.Magazine);
                    player.weapon.AmmoCount = player.weapon.Magazine;
                }
                else
                {
                    Debug.Log("Out of ammo");
                }
            }
        }*/
    }
}
