using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public List<string> inventory = new List<string>();
    public GameObject axeUI;
    public GameObject pickaxeUI;
    public GameObject rockUI;
    public GameObject logUI;
    public GameObject berriesUI;
    public GameObject inventoryUI;
    public GameObject canvas;
    public Camera MainCamera;
    public GameObject Movement;
    public GameObject CameraController;
    public GameObject AnimateAxe;
    public GameObject AnimatePickaxe;

    public int rockCount = 0;
    public bool rockIconActive = false;
    public GameObject rockIcon;

    public int logCount = 0;
    public bool logIconActive = false;
    public GameObject logIcon;

    public int berriesCount = 0;
    public bool berriesIconActive = false;
    public GameObject berriesIcon;
    public GameObject berriesIconText;
    public GameObject berriesUIText;

    public int axeCount = 0;
    public bool axeIconActive = false;
    public GameObject axeIcon;

    public int pickaxeCount = 0;
    public bool pickaxeIconActive = false;
    public GameObject pickaxeIcon;

    public GameObject axeObj;
    public GameObject pickaxeObj;

    public ItemPickup itemScript;
    public GameObject axeItem;
    public GameObject axe;
    public Camera player;

    public bool dropFlag = false;

    public RayCastChop rayCast;

    public GameObject text;

    void Start()
    {
        inventory.Clear();
    }

    void Update()
    {

    
        if(Input.GetButtonDown("Drop"))
        {
            if(axeObj.activeInHierarchy == true)
            {

                itemScript = rayCast.itemScript;
                axe.SetActive(false);
                Instantiate(axeItem, player.transform.position, Quaternion.identity);
                itemScript.DropItem("AxeItem");
                dropFlag = true;

            }
            else if(pickaxeObj.activeInHierarchy == false)
            {
                Destroy(pickaxeIcon);
            }

        }
        
        if(Input.GetButtonDown("Open inventory"))
        {
            if(inventoryUI.activeInHierarchy == false)
            {
                inventoryUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;

                var disableCam = MainCamera.GetComponent<FollowObject>();
                disableCam.enabled = !disableCam.enabled;

                var disableMovement = Movement.GetComponent<MoveControl>();
                disableMovement.enabled = !disableMovement.enabled;

                var disableCamController = CameraController.GetComponent<CameraControl>();
                disableCamController.enabled = !disableCamController.enabled;

                var disableAnimateAxe = AnimateAxe.GetComponent<AnimateAxe>();
                disableAnimateAxe.enabled = !disableAnimateAxe.enabled;
                
                var disableAnimatePickaxe = AnimatePickaxe.GetComponent<AnimateAxe>();
                disableAnimatePickaxe.enabled = !disableAnimatePickaxe.enabled;

                displayItems();


            }
            else if(inventoryUI.activeInHierarchy == true)
            {
                inventoryUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;

                var disableCam = MainCamera.GetComponent<FollowObject>();
                disableCam.enabled = true;

                var disableMovement = Movement.GetComponent<MoveControl>();
                disableMovement.enabled = true;

                var disableCamController = CameraController.GetComponent<CameraControl>();
                disableCamController.enabled = true;

                var disableAnimateAxe = AnimateAxe.GetComponent<AnimateAxe>();
                disableAnimateAxe.enabled = true;

                var disableAnimatePickaxe = AnimatePickaxe.GetComponent<AnimateAxe>();
                disableAnimatePickaxe.enabled = true;

            }

        }


    }

    void displayItems()
    {
        berriesCount = inventory.FindAll(s => s.Equals("BerriesItem")).Count;
        for(int i = 0; i < 8; i++)
        {
            if(inventory[i] == "AxeItem")
            {
                if(axeIconActive && dropFlag == true)
                {
                    axeCount += 1;
                }
                else if(axeIconActive == false && dropFlag == false)
                {
                    var slotPosition = GameObject.Find("InventorySlot"+i).transform.position;
                    axeIcon = Instantiate(axeUI, slotPosition, Quaternion.identity);
                    axeIcon.transform.parent = canvas.transform;
                    axeIconActive = true;
                }
            }
            else if(inventory[i] == "PickaxeItem")
            {
                if(pickaxeIconActive)
                {
                    pickaxeCount += 1;
                }
                else if(pickaxeIconActive == false)
                {
                    var slotPosition = GameObject.Find("InventorySlot"+i).transform.position;
                    pickaxeIcon = Instantiate(pickaxeUI, slotPosition, Quaternion.identity);
                    pickaxeIcon.transform.parent = canvas.transform;
                    pickaxeIconActive = true;
                }
            }
            else if(inventory[i] == "RockItem")
            {

                if(rockIconActive)
                {
                    rockCount += 1;
                }
                else if(rockIconActive == false)
                {
                    var slotPosition = GameObject.Find("InventorySlot"+i).transform.position;
                    rockIcon = Instantiate(rockUI, slotPosition, Quaternion.identity);
                    rockIcon.transform.parent = canvas.transform;
                    rockIconActive = true;
                }
            }
            else if(inventory[i] == "LogItem")
            {
                if(logIconActive)
                {
                    logCount += 1;
                }
                else if(logIconActive == false)
                {
                    var slotPosition = GameObject.Find("InventorySlot"+i).transform.position;
                    logIcon = Instantiate(logUI, slotPosition, Quaternion.identity);
                    logIcon.transform.parent = canvas.transform;
                    logIconActive = true;
                }
            }
            else if(inventory[i] == "BerriesItem")
            {
                if(berriesIconActive)
                {
                    berriesCount += 1;
                }
                else if(berriesIconActive == false)
                {
                    var slotPosition = GameObject.Find("InventorySlot"+i).transform.position;
                    berriesIcon = Instantiate(berriesUI, slotPosition, Quaternion.identity);
                    berriesIcon.transform.parent = canvas.transform;
                    berriesIconActive = true;
                }

            }

        }
    }

}
