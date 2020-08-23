using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public enum TruckButtonTypes
{
    RoadExpansion1,
    RoadExpansion2,
    InventoryIncrease,
    SpeedIncrease,
    CushionedCargo,
    ProductionIncrease,
    AutoDelivery,
    KingBlessing,
    Exit
}

public class TruckUpgradeUI : MonoBehaviour
{
	public int RoadExpansion1Price = 50;
    public int RoadExpansion2Price = 150;
    public int InventoryIncreasePrice = 100;
    public int SpeedIncreasePrice = 100;
    public int CushionedCargoPrice = 300;
    public int ProductionIncreasePrice = 250;
    public int AutoDeliveryPrice = 1000;
    public int KingBlessingPrice = 9000;

	public Button RoadExpansion1Button;
	public Button RoadExpansion2Button;
	public Button InventoryIncreaseButton;
    public Button SpeedIncreaseButton;
    public Button CushionedCargoButton;
    public Button ProductionIncreaseButton;
    public Button AutoDeliveryButton;
    public Button KingBlessingButton;

    public Button ExitButton;

    public Text storeMessage;

    public GameObject Truck;
    public GameObject TruckUI;
    public GameObject UpgradeZone;
    public GameObject hazardShortCut1;
    public GameObject hazardShortCut2;

    private float timeToAppear = 2f;
    private float timeWhenDisappear;

    public GameObject box;

   	private static bool isRoadExpansion1Purchased = false;
    private static bool isRoadExpansion2Purchased = false;
    private static bool isInventoryIncreaseMaxed = false;
    private static bool isSpeedIncreasePurchased = false;
    private static bool isCushionedCargoPurchased = false;
    private static bool isProductionIncreasePurchased = false;
    private static bool isAutoDeliveryPurchased = false;


	void Start()
    {
        RoadExpansion1Button.onClick.AddListener(delegate {TaskWithParameters(TruckButtonTypes.RoadExpansion1); });
        RoadExpansion2Button.onClick.AddListener(delegate {TaskWithParameters(TruckButtonTypes.RoadExpansion2); });
        InventoryIncreaseButton.onClick.AddListener(delegate {TaskWithParameters(TruckButtonTypes.InventoryIncrease); });
    	SpeedIncreaseButton.onClick.AddListener(delegate {TaskWithParameters(TruckButtonTypes.SpeedIncrease); });
    	CushionedCargoButton.onClick.AddListener(delegate {TaskWithParameters(TruckButtonTypes.CushionedCargo); });
    	ProductionIncreaseButton.onClick.AddListener(delegate {TaskWithParameters(TruckButtonTypes.ProductionIncrease); });
    	AutoDeliveryButton.onClick.AddListener(delegate {TaskWithParameters(TruckButtonTypes.AutoDelivery); });
    	KingBlessingButton.onClick.AddListener(delegate {TaskWithParameters(TruckButtonTypes.KingBlessing); });
    	ExitButton.onClick.AddListener(delegate {TaskWithParameters(TruckButtonTypes.Exit); });

    	RoadExpansion1Button.GetComponentInChildren<Text>().text = "$"+RoadExpansion1Price;
    	RoadExpansion2Button.GetComponentInChildren<Text>().text = "$"+RoadExpansion2Price;
    	InventoryIncreaseButton.GetComponentInChildren<Text>().text = "$"+InventoryIncreasePrice;
    	SpeedIncreaseButton.GetComponentInChildren<Text>().text = "$"+SpeedIncreasePrice;
    	CushionedCargoButton.GetComponentInChildren<Text>().text = "$"+CushionedCargoPrice;
    	ProductionIncreaseButton.GetComponentInChildren<Text>().text = "$"+ProductionIncreasePrice;
    	AutoDeliveryButton.GetComponentInChildren<Text>().text = "$"+AutoDeliveryPrice;
    	KingBlessingButton.GetComponentInChildren<Text>().text = "$"+KingBlessingPrice;
    }

    void Update()
    {
    	if(!isInventoryIncreaseMaxed)
    	{
    		InventoryIncreaseButton.GetComponentInChildren<Text>().text = "$"+InventoryIncreasePrice;
    	}
    	else
    	{
    		InventoryIncreaseButton.GetComponentInChildren<Text>().text = "DONE";
    	}
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

	public void TaskWithParameters(TruckButtonTypes tbt)
    {
        //Output this to console when the Button2 is clicked
        switch(tbt)
        {
        	case TruckButtonTypes.RoadExpansion1:
        		{
        			if(PlayerStats.money >= RoadExpansion1Price && !isRoadExpansion1Purchased)
                    {
                        hazardShortCut1.SetActive(false);
                        isRoadExpansion1Purchased = true;
                        PlayerStats.money -= RoadExpansion1Price;
                        RoadExpansion1Button.GetComponent<Image>().color = new Color32(255,0,0,100);
                        RoadExpansion1Button.GetComponentInChildren<Text>().text = "DONE";
                    }
                    else
                    {
                    	if(isRoadExpansion1Purchased)
                    	{
                    		SetStoreText("ALREADY PURCHASED");
                    	}
                    	else
                    	{
                        	SetStoreText("NOT ENOUGH MONEY");
                        }
                    }
        		}
        		break;
        	case TruckButtonTypes.RoadExpansion2:
        		{
        			if(PlayerStats.money >= RoadExpansion2Price && !isRoadExpansion2Purchased)
                    {
                        hazardShortCut2.SetActive(false);
                        isRoadExpansion2Purchased = true;
                        PlayerStats.money -= RoadExpansion2Price;
                        RoadExpansion2Button.GetComponent<Image>().color = new Color32(255,0,0,100);
                        RoadExpansion2Button.GetComponentInChildren<Text>().text = "DONE";
                    }
                    else
                    {
                    	if(isRoadExpansion2Purchased)
                    	{
                    		SetStoreText("ALREADY PURCHASED");
                    	}
                    	else
                    	{
                        	SetStoreText("NOT ENOUGH MONEY");
                        }
                    }
        		}
        		break;
        	case TruckButtonTypes.InventoryIncrease:
        		{

        			if(!isInventoryIncreaseMaxed)
        			{
        				if(PlayerStats.money >= InventoryIncreasePrice)
        				{
        					PlayerStats.money -= InventoryIncreasePrice;
        					PlayerStats.TRUCK_MAX_INVENTORY += 5;
        					++PlayerStats.amountTruckInventoryUpgrades;
        					InventoryIncreasePrice += 100;
        					if(PlayerStats.amountTruckInventoryUpgrades == PlayerStats.MAX_AMOUNT_TRUCK_INVENTORY_UPGRADES)
        					{
        						isInventoryIncreaseMaxed = true;
        						InventoryIncreaseButton.GetComponent<Image>().color = new Color32(255,0,0,100);
                       	 		InventoryIncreaseButton.GetComponentInChildren<Text>().text = "DONE";
        					}
        				}
        				else
        				{
        					SetStoreText("NOT ENOUGH MONEY");
        				}
        			}
        			else
        			{
        				SetStoreText("MAX INVENTORY");
        			}
        			//need to modify text length above vehicles in main scene
        		}
        		break;
    		case TruckButtonTypes.SpeedIncrease:
        		{

        			if(PlayerStats.money >= SpeedIncreasePrice && !isSpeedIncreasePurchased)
                    {
                    	Truck.GetComponent<Movement>().maxVelocity *= 1.1f;
                        isSpeedIncreasePurchased = true;
                        PlayerStats.money -= SpeedIncreasePrice;
                        SpeedIncreaseButton.GetComponent<Image>().color = new Color32(255,0,0,100);
                        SpeedIncreaseButton.GetComponentInChildren<Text>().text = "DONE";
                    }
                    else
                    {
                    	if(isSpeedIncreasePurchased)
                    	{
                    		SetStoreText("ALREADY PURCHASED");
                    	}
                    	else
                    	{
                        	SetStoreText("NOT ENOUGH MONEY");
                        }
                    }
        		}
    			break;
    		case TruckButtonTypes.CushionedCargo:
        		{
        			if(PlayerStats.money >= CushionedCargoPrice && !isCushionedCargoPurchased)
                    {
                    	PlayerStats.BREAKING_VELOCITY = 50;
                        isCushionedCargoPurchased = true;
                        PlayerStats.money -= CushionedCargoPrice;
                        CushionedCargoButton.GetComponent<Image>().color = new Color32(255,0,0,100);
                        CushionedCargoButton.GetComponentInChildren<Text>().text = "DONE";
                    }
                    else
                    {
                    	if(isCushionedCargoPurchased)
                    	{
                    		SetStoreText("ALREADY PURCHASED");
                    	}
                    	else
                    	{
                        	SetStoreText("NOT ENOUGH MONEY");
                        }
                    }
        		}
    			break;
    		case TruckButtonTypes.ProductionIncrease:
        		{

        			if(PlayerStats.money >= ProductionIncreasePrice && !isProductionIncreasePurchased)
                    {
        				box.GetComponent<Animator>().speed = 1.1f;
                        isProductionIncreasePurchased = true;
                        PlayerStats.money -= ProductionIncreasePrice;
                        ProductionIncreaseButton.GetComponent<Image>().color = new Color32(255,0,0,100);
                        ProductionIncreaseButton.GetComponentInChildren<Text>().text = "DONE";
                    }
                    else
                    {
                    	if(isProductionIncreasePurchased)
                    	{
                    		SetStoreText("ALREADY PURCHASED");
                    	}
                    	else
                    	{
                        	SetStoreText("NOT ENOUGH MONEY");
                        }
                    }
        		}
    			break;
    		case TruckButtonTypes.AutoDelivery:
        		{
        			SetStoreText("TO BE IMPLEMENTED");
        		}
    			break;
    		case TruckButtonTypes.KingBlessing:
        		{
        			if(PlayerStats.money >= KingBlessingPrice && !PlayerStats.isKingBlessingPurchased)
                    {
                        PlayerStats.isKingBlessingPurchased = true;
                        PlayerStats.updateTruckInventory(0);
                        PlayerStats.money -= KingBlessingPrice;
                        KingBlessingButton.GetComponent<Image>().color = new Color32(255,0,0,100);
                        KingBlessingButton.GetComponentInChildren<Text>().text = "DONE";
                    }
                    else
                    {
                    	if(PlayerStats.isKingBlessingPurchased)
                    	{
                    		SetStoreText("ALREADY PURCHASED");
                    	}
                    	else
                    	{
                        	SetStoreText("NOT ENOUGH MONEY");
                        }
                    }
        		}
    			break;
    		case TruckButtonTypes.Exit:
    			{

    				Truck.SetActive(true);
    				TruckUI.SetActive(false);
    				UpgradeZone.GetComponent<UpgradeZoneCity>().inMenu = false;
    			}
    			break;
        	default:
        		break;
        }
    }
}
