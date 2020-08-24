using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public enum PortTankButtonTypes
{
    SellPortInventory,
    PortInventoryIncrease,
    DepositBoatInventory,
    WithdrawTankInventory,
    BuyStaffOfTheHero,
    Exit
}

public class PortTankCacheUI : MonoBehaviour
{
	public int SellPortInventoryPrice = 10;
    public int PortInventoryIncreasePrice = 150;
    public int BuyStaffOfTheHeroPrice = 9999;
    

	public Button SellPortInventoryButton = null;
	public Button PortInventoryIncreaseButton = null;
	public Button DepositBoatInventoryButton = null;
    public Button WithdrawTankInventoryButton = null;
    public Button BuyStaffOfTheHeroButton = null;

    public Button ExitButton;

    public Text PortInventoryText;
    public Text TankInventoryText;
    public Text BoatInventoryText;

    public Text storeMessage;

    public GameObject Tank;
    public GameObject Boat;
    public GameObject TankPortUI;
    public GameObject PortCacheTankZone;
    public GameObject PortCacheBoatTankZone;

    private float timeToAppear = 2f;
    private float timeWhenDisappear;

    private static bool isInventoryIncreaseMaxed = false;


	void Start()
    {
        SellPortInventoryButton.onClick.AddListener(delegate {TaskWithParameters(PortTankButtonTypes.SellPortInventory); });
        PortInventoryIncreaseButton.onClick.AddListener(delegate {TaskWithParameters(PortTankButtonTypes.PortInventoryIncrease); });
        DepositBoatInventoryButton.onClick.AddListener(delegate {TaskWithParameters(PortTankButtonTypes.DepositBoatInventory); });
    	WithdrawTankInventoryButton.onClick.AddListener(delegate {TaskWithParameters(PortTankButtonTypes.WithdrawTankInventory); });
    	BuyStaffOfTheHeroButton.onClick.AddListener(delegate {TaskWithParameters(PortTankButtonTypes.BuyStaffOfTheHero); });
    	ExitButton.onClick.AddListener(delegate {TaskWithParameters(PortTankButtonTypes.Exit); });

    	SellPortInventoryButton.GetComponentInChildren<Text>().text = "+$"+SellPortInventoryPrice;
    	PortInventoryIncreaseButton.GetComponentInChildren<Text>().text = "$"+PortInventoryIncreasePrice;
    	DepositBoatInventoryButton.GetComponentInChildren<Text>().text = "-1 B";
    	WithdrawTankInventoryButton.GetComponentInChildren<Text>().text = "+1 T";
    	BuyStaffOfTheHeroButton.GetComponentInChildren<Text>().text = "$"+BuyStaffOfTheHeroPrice;

        PortInventoryText.text = PlayerStats.tankPortInventory + ":" + PlayerStats.TANK_PORT_MAX_INVENTORY;
        TankInventoryText.text = PlayerStats.tankInventory + ":" + PlayerStats.TANK_MAX_INVENTORY;
        BoatInventoryText.text = PlayerStats.boatInventory + ":" + PlayerStats.BOAT_MAX_INVENTORY;
        storeMessage.text = "";

        //if(!PortCacheBoatZone.GetComponent<PortCacheBoatZone>().inMenu )
            WithdrawTankInventoryButton.interactable = false;

        //if(!PortCacheZone.GetComponent<PortCacheZone>().inMenu )
            DepositBoatInventoryButton.interactable = false;
    }


    void Update()
    {
        PortInventoryText.text = PlayerStats.tankPortInventory + ":" + PlayerStats.TANK_PORT_MAX_INVENTORY;
        TankInventoryText.text = PlayerStats.tankInventory + ":" + PlayerStats.TANK_MAX_INVENTORY;
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

	public void TaskWithParameters(PortTankButtonTypes tbt)
    {
        //Output this to console when the Button2 is clicked
        switch(tbt)
        {
        	case PortTankButtonTypes.SellPortInventory:
        		{
                    if(PlayerStats.tankPortInventoryHas(1))
                    {
                        --PlayerStats.tankPortInventory;
                        PlayerStats.money += SellPortInventoryPrice;
                    }
                    else
                    {
                        SetStoreText("PORT INVENTORY EMPTY");
                    }
        		}
        		break;
        	case PortTankButtonTypes.PortInventoryIncrease:
        		{
        			if(!isInventoryIncreaseMaxed)
                    {
                        if(PlayerStats.money >= PortInventoryIncreasePrice)
                        {
                            PlayerStats.money -= PortInventoryIncreasePrice;
                            PlayerStats.TANK_PORT_MAX_INVENTORY += 5;
                            ++PlayerStats.amountTankPortInventoryUpgrades;
                            PortInventoryIncreasePrice += 100;
                            if(PlayerStats.amountTankPortInventoryUpgrades == PlayerStats.MAX_AMOUNT_TANK_PORT_INVENTORY_UPGRADES)
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
        	case PortTankButtonTypes.DepositBoatInventory:
        		{
                    if(PlayerStats.boatInventoryHas(1) && PlayerStats.tankPortInventory < PlayerStats.TANK_PORT_MAX_INVENTORY)
                    {
                        PlayerStats.updateBoatInventory(-1);
                        ++PlayerStats.tankPortInventory;
                    }
                    else
                    {
                        if(PlayerStats.boatInventoryHas(1))
                        {
                            SetStoreText("PORT INVENTORY FULL");
                        }
                        else
                        {
                            SetStoreText("BOAT INVENTORY EMPTY");
                        }
                    }
        		}
        		break;
    		case PortTankButtonTypes.WithdrawTankInventory:
        		{
                    if(PlayerStats.tankPortInventoryHas(1) && !PlayerStats.isTankInventoryFull())
                    {
                        PlayerStats.updateTankInventory(1);
                        --PlayerStats.tankPortInventory;
                    }
                    else
                    {
                        if(PlayerStats.isTankInventoryFull())
                        {
                            SetStoreText("TANK INVENTORY FULL");
                        }
                        else
                        {
                            SetStoreText("PORT INVENTORY EMPTY");
                        }
                    }
        		}
    			break;
    		case PortTankButtonTypes.BuyStaffOfTheHero:
        		{
        			Debug.Log("BuyStaffOfTheHero purchased");
        		}
    			break;
    		case PortTankButtonTypes.Exit:
    			{
                    if(PortCacheTankZone.GetComponent<PortCacheTankZone>().inMenu )
                    {
                        Tank.SetActive(true);//maybe not set truck to inactive but just re-enable Movement script
                        PortCacheTankZone.GetComponent<PortCacheTankZone>().inMenu = false;
                    }

                    if(PortCacheBoatTankZone.GetComponent<PortCacheBoatTankZone>().inMenu)
                    {
                        Boat.SetActive(true);
                        PortCacheBoatTankZone.GetComponent<PortCacheBoatTankZone>().inMenu = false;
                    }

                    TankPortUI.SetActive(false);
    			}
    			break;
        	default:
        		break;
        }
    }
}
