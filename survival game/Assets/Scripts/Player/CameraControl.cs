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

    private RaycastHit hit;

    public GameObject bullet;

    void Update()
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

        var player = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();

        if (Input.GetKeyDown(KeyCode.E))
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Ray ray = new Ray(transform.position, transform.rotation * Vector3.forward);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.Log("Did Hit " + hit.transform.tag);

                if (hit.transform.tag.Equals("Item"))
                {
                    //debug to visualise ray when in editor
                    Debug.DrawRay(transform.position, ray.direction * hit.distance, Color.yellow);

                    //adds the item hit by the raycast to the players inventory;

                    var item = hit.transform.GetComponent<ItemObject>();
                    if (item.Tags.Length > 0)
                    {
                        if (item.Tags[0].Item2.Equals("Weapon"))
                        {
                            int Damage = 0;
                            string Ammo = "";
                            int MagSize = 0;
                            foreach (var a in item.Tags)
                            {
                                if (a.Item1.Equals("Damage")) { Damage = int.Parse(a.Item2); }
                                else if (a.Item1.Equals("Ammo")) { Ammo = a.Item2; }
                                else if (a.Item1.Equals("Magazine")) { MagSize = int.Parse(a.Item2); }
                            }
                            player.player.addWeapon(new Weapon(item.ID, item.name, item.Description, item.Tags, Damage, Ammo, MagSize));
                        }
                    }
                    else
                    {
                        player.player.addItem(item.item, item.Count);
                    }

                    Debug.Log(player.player.invToStr());

                    //destorys the object hit by the raycast
                    Destroy(hit.transform.gameObject);
                }
            }
            else
            {
                Debug.DrawRay(transform.position, ray.direction * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
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
        }
    }
}
