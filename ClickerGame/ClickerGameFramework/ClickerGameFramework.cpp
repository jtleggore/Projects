// This is the main DLL file.

#include "stdafx.h"

#include "ClickerGameFramework.h"

using namespace System;

using namespace ClickerGameFunctions;

//todo: determine where best to use	* and &
namespace ClickerGameFramework 
{
	//Round to 2 decimal places
	//Note: not working
	float round(float number)
	{
		float newVal = (int)(number * 100 + 0.5);
		return (float)newVal / 100;
	}

	Upgrade::Upgrade(String^ name, float baseCost, UnlockCriteria^ unlockMethod, UpgradeBonus^ upgradeMethod)
	{
		_name = name;
		_baseCost = round(baseCost);
		_unlocked = unlockMethod;
		_upgradeBonus = upgradeMethod;

	}

	float Upgrade::BaseCost::get()
	{
		return Upgrade::_baseCost;
	}

	String^ Upgrade::Name::get()
	{
		return Upgrade::_name;
	}

	bool Upgrade::Unlocked::get()
	{
		return _unlocked();
	}

	String^ Upgrade::UpgradeValue::get()
	{
		return _upgradeBonus();
	}

	Building::Building()
	{

	}

	Building::Building(String^ name, float baseDPT, float baseCost)
	{		
		_name = name;
		_baseDPT = round(baseDPT);
		_baseCost = round(baseCost);
		_currentDPT = DEFAULT_DPT;
		_currentCost = round(baseCost);
		_costMultiplyer = DEFAULT_MULT;
	}

	Building::Building(String^ name, float baseDPT, float baseCost, float costMult)
	{
		_name = name;
		_baseDPT = round(baseDPT);
		_baseCost = round(baseCost);
		_currentDPT = DEFAULT_DPT;
		_currentCost = round(baseCost);
		_costMultiplyer = round(costMult);
	}

	float Building::BaseDPT::get()
	{
		return Building::_baseDPT;
	}

	float Building::BaseCost::get()
	{
		return Building::_baseCost;
	}

	float Building::CurrentDPT::get()
	{
		return Building::_currentDPT;
	}
	void Building::CurrentDPT::set(float amount)
	{
		Building::_currentDPT = round(amount);
	}

	float Building::CurrentCost::get()
	{
		return Building::_currentCost;
	}
	void Building::CurrentCost::set(float amount)
	{
		if (amount > 0)
		{
			Building::_currentCost = round(amount);
		}
	}

	float Building::CostMultiplyer::get()
	{
		return Building::_costMultiplyer;
	}
	void Building::CostMultiplyer::set(float mult)
	{
		if (mult >= 1)
		{
			Building::_costMultiplyer = round(mult);
		}
	}

	String^ Building::Name::get()
	{
		return Building::_name;
	}

	int Building::Quantity::get()
	{
		return Building::_quantity;
	}
	void Building::Quantity::set(int amount)
	{
		if (amount > 0)
		{
			Building::_quantity = amount;
			//todo: change this to an F# formula
			Building::CurrentDPT = Building::BaseDPT * Building::Quantity;

			Building::updateCost();
		}
	}

	//sets cost of building to the next cost
	void Building::updateCost()
	{
		float currentCost = Building::CurrentCost;
		float costMult = Building::CostMultiplyer;

		float nextCost = BuildingFunctions::nextCost(currentCost, costMult);
		Building::CurrentCost = round(nextCost);
	}

	int Building::Test(int test)
	{
		float a = MainFunctions::moneyMultiplyer(1, 1, 1);
		return test * 3;
	}

	MainOperator::MainOperator()
	{
		_baseDPC = DEFAULT_DPC;
		_baseDPT = DEFAULT_DPT;
		_currentDPC = _baseDPC;
		_currentDPT = _baseDPT;
		_currentDollars = 0;
	}

	float MainOperator::BaseDPT::get()
	{
		return MainOperator::_baseDPT;
	}

	float MainOperator::BaseDPC::get()
	{
		return MainOperator::_baseDPC;
	}

	float MainOperator::CurrentDPT::get()
	{
		return MainOperator::_currentDPT;
	}
	void MainOperator::CurrentDPT::set(float dpt)
	{
		if (dpt >= 0)
		{
			MainOperator::_currentDPT = round(dpt);
		}
	}

	float MainOperator::CurrentDPC::get()
	{
		return MainOperator::_currentDPC;
	}
	void MainOperator::CurrentDPC::set(float dpc)
	{
		if (dpc >= 0)
		{
			MainOperator::_currentDPC = round(dpc);
		}
	}

	float MainOperator::CurrentDollars::get()
	{
		return MainOperator::_currentDollars;
	}
	void MainOperator::CurrentDollars::set(float amount)
	{
		if (amount >= 0)
		{
			MainOperator::_currentDollars = round(amount);
		}
	}

	//run everytime click button is clicked
	void MainOperator::doClick(float amount)
	{
		MainOperator::_currentDollars += round(amount);
		//MainOperator::addToCurrentDollars(round(amount));
	}
}