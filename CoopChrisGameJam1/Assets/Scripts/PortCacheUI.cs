using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public enum PortButtonTypes
{
    SellPortInventory,
    PortInventoryIncrease,
    DepositTruckInventory,
    WithdrawBoatInventory,
    BuyPirateMedallion,
    Exit
}

public class PortCacheUI : MonoBehaviour
{
	public int SellPortInventoryPrice = 10;
    public int PortInventoryIncreasePrice = 150;
    public int BuyPirateMedallionPrice = 9999;
    

	public Button SellPortInventoryButton;
	public Button PortInventoryIncreaseButton;
	public Button DepositTruckInventoryButton;
    public Button WithdrawBoatInventoryButton;
    public Button BuyPirateMedallionButton;

    public Button ExitButton;

    public Text PortInventoryText;
    public Text TruckInventoryText;
    public Text BoatInventoryText;

    public Text storeMessage;

    public GameObject Truck;
    public GameObject TruckPortUI;
    public GameObject PortCacheZone;

    private float timeToAppear = 2f;
    private float timeWhenDisappear;

    private static bool isInventoryIncreaseMaxed = false;


	void Start()
    {
        SellPortInventoryButton.onClick.AddListener(delegate {TaskWithParameters(PortButtonTypes.SellPortInventory); });
        PortInventoryIncreaseButton.onClick.AddListener(delegate {TaskWithParameters(PortButtonTypes.PortInventoryIncrease); });
        DepositTruckInventoryButton.onClick.AddListener(delegate {TaskWithParameters(PortButtonTypes.DepositTruckInventory); });
    	WithdrawBoatInventoryButton.onClick.AddListener(delegate {TaskWithParameters(PortButtonTypes.WithdrawBoatInventory); });
    	BuyPirateMedallionButton.onClick.AddListener(delegate {TaskWithParameters(PortButtonTypes.BuyPirateMedallion); });
    	ExitButton.onClick.AddListener(delegate {TaskWithParameters(PortButtonTypes.Exit); });

    	SellPortInventoryButton.GetComponentInChildren<Text>().text = "+$"+SellPortInventoryPrice;
    	PortInventoryIncreaseButton.GetComponentInChildren<Text>().text = "$"+PortInventoryIncreasePrice;
    	DepositTruckInventoryButton.GetComponentInChildren<Text>().text = "-1 T";
    	WithdrawBoatInventoryButton.GetComponentInChildren<Text>().text = "+1 B";
    	BuyPirateMedallionButton.GetComponentInChildren<Text>().text = "$"+BuyPirateMedallionPrice;

        PortInventoryText.text = PlayerStats.truckPortInventory + ":" + PlayerStats.TRUCK_PORT_MAX_INVENTORY;
        TruckInventoryText.text = PlayerStats.truckInventory + ":" + PlayerStats.TRUCK_MAX_INVENTORY;
        BoatInventoryText.text = PlayerStats.boatInventory + ":" + PlayerStats.BOAT_MAX_INVENTORY;
        storeMessage.text = "";
    }


    void Update()
    {
        PortInventoryText.text = PlayerStats.truckPortInventory + ":" + PlayerStats.TRUCK_PORT_MAX_INVENTORY;
        TruckInventoryText.text = PlayerStats.truckInventory + ":" + PlayerStats.TRUCK_MAX_INVENTORY;
        BoatInventoryText.text = PlayerStats.boatInventory + ":" + PlayerStats.BOAT_MAX_INVENTORY;

        if(storeMessage.text != "" && (Time.time >= timeWhenDisappear))
        {
            storeMessage.text = "";
        }
    }

    void SetStoreText(string text)
    {
        storeMessage.text = text;
        timeWhenDisappear = Time.time + timeToAppear;
    }

	public void TaskWithParameters(PortButtonTypes tbt)
    {
        //Output this to console when the Button2 is clicked
        switch(tbt)
        {
        	case PortButtonTypes.SellPortInventory:
        		{
                    if(PlayerStats.truckPortInventoryHas(1))
                    {
                        --PlayerStats.truckPortInventory;
                        PlayerStats.money += SellPortInventoryPrice;
                    }
                    else
                    {
                        SetStoreText("PORT INVENTORY EMPTY");
                    }
        		}
        		break;
        	case PortButtonTypes.PortInventoryIncrease:
        		{
        			if(!isInventoryIncreaseMaxed)
                    {
                        if(PlayerStats.money >= PortInventoryIncreasePrice)
                        {
                            PlayerStats.money -= PortInventoryIncreasePrice;
                            PlayerStats.TRUCK_PORT_MAX_INVENTORY += 5;
                            ++PlayerStats.amountTruckPortInventoryUpgrades;
                            PortInventoryIncreasePrice += 100;
                            if(PlayerStats.amountTruckPortInventoryUpgrades == PlayerStats.MAX_AMOUNT_TRUCK_PORT_INVENTORY_UPGRADES)
                            {
                                isInventoryIncreaseMaxed = true;
                                PortInventoryIncreaseButton.GetComponent<Image>().color = new Color32(255,0,0,100);
                                PortInventoryIncreaseButton.GetComponentInChildren<Text>().text = "DONE";
                            }
                        }
                        else
                        {
                            SetStoreText("NOT ENOUGH MONEY");
                        }
                    }
                    else
                    {
                        SetStoreText("MAX PORT INVENTORY");
                    }
        		}
        		break;
        	case PortButtonTypes.DepositTruckInventory:
        		{
                    if(PlayerStats.truckInventoryHas(1) && PlayerStats.truckPortInventory < PlayerStats.TRUCK_PORT_MAX_INVENTORY)
                    {
                        PlayerStats.updateTruckInventory(-1);
                        ++PlayerStats.truckPortInventory;
                    }
                    else
                    {
                        if(PlayerStats.truckInventoryHas(1))
                        {
                            SetStoreText("PORT INVENTORY FULL");
                        }
                        else
                        {
                            SetStoreText("TRUCK INVENTORY EMPTY");
                        }
                    }
        		}
        		break;
    		case PortButtonTypes.WithdrawBoatInventory:
        		{
                    if(PlayerStats.truckPortInventoryHas(1) && !PlayerStats.isBoatInventoryFull())
                    {
                        PlayerStats.updateBoatInventory(1);
                        --PlayerStats.truckPortInventory;
                    }
                    else
                    {
                        if(PlayerStats.isBoatInventoryFull())
                        {
                            SetStoreText("BOAT INVENTORY FULL");
                        }
                        else
                        {
                            SetStoreText("PORT INVENTORY EMPTY");
                        }
                    }
        		}
    			break;
    		case PortButtonTypes.BuyPirateMedallion:
        		{
        			Debug.Log("BuyPirateMedallion purchased");
        		}
    			break;
    		case PortButtonTypes.Exit:
    			{

    				Truck.SetActive(true); //maybe not set truck to inactive but just re-enable Movement script
    				TruckPortUI.SetActive(false);
    				PortCacheZone.GetComponent<PortCacheZone>().inMenu = false;
    			}
    			break;
        	default:
        		break;
        }
    }
}
