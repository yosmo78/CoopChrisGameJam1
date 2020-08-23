using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public enum BoatButtonTypes
{
    CoveExpansion,
    SpeedBoatBoost,
    InventoryIncrease,
    BoatFactoryLine,
    FactoryLineSpeedIncrease,
    CushionedCargo,
    AutoDelivery,
    QueensBlessing,
    Exit
}

public class BoatUpgradeUI : MonoBehaviour
{
	public int CoveExpansionPrice = 50;
    public int SpeedBoatBoostPrice = 150;
    public int InventoryIncreasePrice = 100;
    public int BoatFactoryLinePrice = 100;
    public int FactoryLineSpeedIncreasePrice = 300;
    public int CushionedCargoPrice = 250;
    public int AutoDeliveryPrice = 1000;
    public int QueensBlessingPrice = 9000;

	public Button CoveExpansionButton;
	public Button SpeedBoatBoostButton;
	public Button InventoryIncreaseButton;
    public Button BoatFactoryLineButton;
    public Button FactoryLineSpeedIncreaseButton;
    public Button CushionedCargoButton;
    public Button AutoDeliveryButton;
    public Button QueensBlessingButton;

    public Button ExitButton;

    public Text storeMessage;

    public GameObject Boat;
    public GameObject BoatUI;
    public GameObject UpgradeZoneOcean;
    public GameObject CoveExpansionRocks;
    public GameObject BoatFactoryLine;
    public GameObject BoatFactoryLineBox; //maybe make child of BoatFactoryLine

    private float timeToAppear = 2f;
    private float timeWhenDisappear;

    public GameObject box;

   	private static bool isCoveExpansionPurchased = false;
    private static bool isSpeedBoatBoostPurchased = false;
    private static bool isInventoryIncreaseMaxed = false;
    private static bool isBoatFactoryLinePurchased = false;
    private static bool isCushionedCargoPurchased = false;
    private static bool isFactoryLineSpeedIncreasePurchased = false;
    private static bool isAutoDeliveryPurchased = false;


	void Start()
    {
        CoveExpansionButton.onClick.AddListener(delegate {TaskWithParameters(BoatButtonTypes.CoveExpansion); });
        SpeedBoatBoostButton.onClick.AddListener(delegate {TaskWithParameters(BoatButtonTypes.SpeedBoatBoost); });
        InventoryIncreaseButton.onClick.AddListener(delegate {TaskWithParameters(BoatButtonTypes.InventoryIncrease); });
    	BoatFactoryLineButton.onClick.AddListener(delegate {TaskWithParameters(BoatButtonTypes.BoatFactoryLine); });
    	FactoryLineSpeedIncreaseButton.onClick.AddListener(delegate {TaskWithParameters(BoatButtonTypes.FactoryLineSpeedIncrease); });
    	CushionedCargoButton.onClick.AddListener(delegate {TaskWithParameters(BoatButtonTypes.CushionedCargo); });
    	AutoDeliveryButton.onClick.AddListener(delegate {TaskWithParameters(BoatButtonTypes.AutoDelivery); });
    	QueensBlessingButton.onClick.AddListener(delegate {TaskWithParameters(BoatButtonTypes.CushionedCargo); });
    	ExitButton.onClick.AddListener(delegate {TaskWithParameters(BoatButtonTypes.Exit); });

    	CoveExpansionButton.GetComponentInChildren<Text>().text = "$"+CoveExpansionPrice;
    	SpeedBoatBoostButton.GetComponentInChildren<Text>().text = "$"+SpeedBoatBoostPrice;
    	InventoryIncreaseButton.GetComponentInChildren<Text>().text = "$"+InventoryIncreasePrice;
    	BoatFactoryLineButton.GetComponentInChildren<Text>().text = "$"+BoatFactoryLinePrice;
    	FactoryLineSpeedIncreaseButton.GetComponentInChildren<Text>().text = "$"+FactoryLineSpeedIncreasePrice;
    	CushionedCargoButton.GetComponentInChildren<Text>().text = "$"+CushionedCargoPrice;
    	AutoDeliveryButton.GetComponentInChildren<Text>().text = "$"+AutoDeliveryPrice;
    	QueensBlessingButton.GetComponentInChildren<Text>().text = "$"+QueensBlessingPrice;
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

	public void TaskWithParameters(BoatButtonTypes tbt)
    {
        //Output this to console when the Button2 is clicked
        switch(tbt)
        {
        	case BoatButtonTypes.CoveExpansion:
        		{
        			if(PlayerStats.money >= CoveExpansionPrice && !isCoveExpansionPurchased)
                    {
                        CoveExpansionRocks.SetActive(false);
                        isCoveExpansionPurchased = true;
                        PlayerStats.money -= CoveExpansionPrice;
                        CoveExpansionButton.GetComponent<Image>().color = new Color32(255,0,0,100);
                        CoveExpansionButton.GetComponentInChildren<Text>().text = "DONE";
                    }
                    else
                    {
                    	if(isCoveExpansionPurchased)
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
        	case BoatButtonTypes.SpeedBoatBoost:
        		{
        			if(PlayerStats.money >= SpeedBoatBoostPrice && !isSpeedBoatBoostPurchased)
                    {
                        Boat.GetComponent<Movement>().maxVelocity *= 1.1f;
                        isSpeedBoatBoostPurchased = true;
                        PlayerStats.money -= SpeedBoatBoostPrice;
                        SpeedBoatBoostButton.GetComponent<Image>().color = new Color32(255,0,0,100);
                        SpeedBoatBoostButton.GetComponentInChildren<Text>().text = "DONE";
                    }
                    else
                    {
                    	if(isSpeedBoatBoostPurchased)
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
        	case BoatButtonTypes.InventoryIncrease:
        		{

        			if(!isInventoryIncreaseMaxed)
        			{
        				if(PlayerStats.money >= InventoryIncreasePrice)
        				{
        					PlayerStats.money -= InventoryIncreasePrice;
        					PlayerStats.BOAT_MAX_INVENTORY += 5;
        					++PlayerStats.amountBoatInventoryUpgrades;
        					InventoryIncreasePrice += 200;
        					if(PlayerStats.amountBoatInventoryUpgrades == PlayerStats.MAX_AMOUNT_BOAT_INVENTORY_UPGRADES)
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
        		}
        		break;
    		case BoatButtonTypes.BoatFactoryLine:
        		{

        			if(PlayerStats.money >= BoatFactoryLinePrice && !isBoatFactoryLinePurchased)
                    {
                    	BoatFactoryLine.SetActive(true);
                        isBoatFactoryLinePurchased = true;
                        PlayerStats.money -= BoatFactoryLinePrice;
                        BoatFactoryLineButton.GetComponent<Image>().color = new Color32(255,0,0,100);
                        BoatFactoryLineButton.GetComponentInChildren<Text>().text = "DONE";
                    }
                    else
                    {
                    	if(isBoatFactoryLinePurchased)
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
    		case BoatButtonTypes.FactoryLineSpeedIncrease:
        		{
        			if(PlayerStats.money >= FactoryLineSpeedIncreasePrice && !isFactoryLineSpeedIncreasePurchased)
                    {
                        BoatFactoryLineBox.GetComponent<Animator>().speed = 2.0f;
                        isFactoryLineSpeedIncreasePurchased = true;
                        PlayerStats.money -= FactoryLineSpeedIncreasePrice;
                        FactoryLineSpeedIncreaseButton.GetComponent<Image>().color = new Color32(255,0,0,100);
                        FactoryLineSpeedIncreaseButton.GetComponentInChildren<Text>().text = "DONE";
                    }
                    else
                    {
                        if(isFactoryLineSpeedIncreasePurchased)
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
    		case BoatButtonTypes.CushionedCargo:
        		{

        			if(PlayerStats.money >= CushionedCargoPrice && !isCushionedCargoPurchased)
                    {
                        PlayerStats.BOAT_BREAKING_VELOCITY = 50;
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
    		case BoatButtonTypes.AutoDelivery:
        		{
        			SetStoreText("TO BE IMPLEMENTED");
        		}
    			break;
    		case BoatButtonTypes.QueensBlessing:
        		{
        			if(PlayerStats.money >= QueensBlessingPrice && !PlayerStats.isQueensBlessingPurchased)
                    {
                        PlayerStats.isQueensBlessingPurchased = true;
                        PlayerStats.updateBoatInventory(0);
                        PlayerStats.money -= QueensBlessingPrice;
                        QueensBlessingButton.GetComponent<Image>().color = new Color32(255,0,0,100);
                        QueensBlessingButton.GetComponentInChildren<Text>().text = "DONE";
                    }
                    else
                    {
                    	if(PlayerStats.isQueensBlessingPurchased)
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
    		case BoatButtonTypes.Exit:
    			{

    				Boat.SetActive(true);
    				BoatUI.SetActive(false);
    				UpgradeZoneOcean.GetComponent<UpgradeZoneOcean>().inMenu = false;
    			}
    			break;
        	default:
        		break;
        }
    }
}
