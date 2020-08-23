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

    private float timeToAppear = 2f;
    private float timeWhenDisappear;



   	private static bool isRoadExpansion1Purchased = false;
    private static bool isRoadExpansion2Purchased = false;
    private static bool isInventoryIncreasePurchased = false;
    private static bool isSpeedIncreasePurchased = false;
    private static bool isCushionedCargoPurchased = false;
    private static bool isProductionIncreasePurchased = false;
    private static bool isAutoDeliveryPurchased = false;
    private static bool isKingBlessingPurchased = false;


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
                        Debug.Log("RoadExpansion1 purchased");
                        isRoadExpansion1Purchased = true;
                        PlayerStats.money -= RoadExpansion1Price;
                        RoadExpansion1Button.GetComponent<Image>().color = new Color32(255,0,0,100);
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
        			Debug.Log("RoadExpansion2 purchased");

         			RoadExpansion2Button.GetComponent<Image>().color = new Color32(255,0,0,100);
        		}
        		break;
        	case TruckButtonTypes.InventoryIncrease:
        		{
        			Debug.Log("InventoryIncrease purchased");
        			PlayerStats.TRUCK_MAX_INVENTORY += 5;
        			//need to modify text length above vehicles in main scene
        		}
        		break;
    		case TruckButtonTypes.SpeedIncrease:
        		{
        			Debug.Log("SpeedIncrease purchased");
        		}
    			break;
    		case TruckButtonTypes.CushionedCargo:
        		{
        			Debug.Log("CushionedCargo purchased");
        		}
    			break;
    		case TruckButtonTypes.ProductionIncrease:
        		{
        			Debug.Log("ProductionIncrease purchased");
        		}
    			break;
    		case TruckButtonTypes.AutoDelivery:
        		{
        			Debug.Log("AutoDelivery purchased");
        		}
    			break;
    		case TruckButtonTypes.KingBlessing:
        		{
        			Debug.Log("KingBlessing purchased");
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
