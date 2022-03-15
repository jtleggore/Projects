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

	BaseGameClass::BaseGameClass()
	{
		_costMultiplier = DEFAULT_COST_MULT;
	}
	
	String^ BaseGameClass::Name::get()
	{
		return BaseGameClass::_name;
	}

	float BaseGameClass::BaseCost::get()
	{
		return BaseGameClass::_baseCost;
	}

	float BaseGameClass::CurrentCost::get()
	{
		return BaseGameClass::_currentCost;
	}
	void BaseGameClass::CurrentCost::set(float amount)
	{
		if (amount > 0)
		{
			BaseGameClass::_currentCost = round(amount) * BaseGameClass::CostMultiplier * BaseGameClass::GlobalCostMultiplier;
		}
		//can passs in 0 to have the currentCost be recalculated
		else 
		{
			BaseGameClass::_currentCost = BaseGameClass::_currentCost * BaseGameClass::CostMultiplier * BaseGameClass::GlobalCostMultiplier;
		}
	}

	float BaseGameClass::CostMultiplier::get()
	{
		return BaseGameClass::_costMultiplier;
	}
	void BaseGameClass::CostMultiplier::set(float mult)
	{
		if (mult > 0)
		{
			BaseGameClass::_costMultiplier = round(mult);
		}
	}

	float BaseGameClass::GlobalCostMultiplier::get()
	{
		return BaseGameClass::_globalCostMultiplier;
	}
	void BaseGameClass::GlobalCostMultiplier::set(float mult)
	{
		if (mult > 0)
		{
			BaseGameClass::_globalCostMultiplier = round(mult);
		}
	}

	Upgrade::Upgrade(String^ name, float baseCost, UnlockCriteria^ unlockMethod, UpgradeBonus^ upgradeMethod)
	{
		_name = name;
		_baseCost = round(baseCost);
		_currentCost = _baseCost;
		_unlocked = unlockMethod;
		_upgradeBonus = upgradeMethod;
	}

	bool Upgrade::Unlocked::get()
	{
		return _unlocked();
	}

	int Upgrade::UpgradeValue::get()
	{
		return _upgradeBonus();
	}

	Building::Building(String^ name, float baseDPT, float baseCost)
	{		
		_name = name;
		_baseDPT = round(baseDPT);
		_baseCost = round(baseCost);
		_currentDPT = DEFAULT_DPT;
		_dptMultiplier = DEFAULT_DPT_MULT;
		_currentCost = round(baseCost);
		_nextCostMultiplier = DEFAULT_NEXTCOST_MULT;
	}

	Building::Building(String^ name, float baseDPT, float baseCost, float costMult)
	{
		_name = name;
		_baseDPT = round(baseDPT);
		_baseCost = round(baseCost);
		_currentDPT = DEFAULT_DPT;
		_currentCost = round(baseCost);
		_nextCostMultiplier = round(costMult);
	}

	float Building::BaseDPT::get()
	{
		return Building::_baseDPT;
	}

	float Building::CurrentDPT::get()
	{
		return Building::_currentDPT;
	}
	void Building::CurrentDPT::set(float amount)
	{
		if (amount > 0)
		{
			Building::_currentDPT = round(amount) * Building::DPTMultiplier * Building::GlobalDPTMultiplier;
		}
		//can pass in 0 to have the currentDPT be recalculated
		else
		{
			Building::_currentDPT = Building::_currentDPT * Building::DPTMultiplier * Building::GlobalDPTMultiplier;
		}
	}

	float Building::nextCostMultiplier::get()
	{
		return Building::_nextCostMultiplier;
	}
	void Building::nextCostMultiplier::set(float mult)
	{
		if (mult >= 1)
		{
			Building::_nextCostMultiplier = round(mult);
		}
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

	float Building::DPTMultiplier::get()
	{
		return Building::_dptMultiplier;
	}
	void Building::DPTMultiplier::set(float mult)
	{
		if (mult > 0)
		{
			Building::_dptMultiplier = round(mult);
		}
	}

	float Building::GlobalDPTMultiplier::get()
	{
		return Building::_globalDptMultiplier;
	}
	void Building::GlobalDPTMultiplier::set(float mult)
	{
		if (mult > 0)
		{
			Building::_globalDptMultiplier = round(mult);
		}
	}

	//sets cost of building to the next cost
	void Building::updateCost()
	{
		float currentCost = Building::CurrentCost;
		float costMult = Building::nextCostMultiplier;

		float nextCost = BuildingFunctions::nextCost(currentCost, costMult);
		Building::CurrentCost = round(nextCost) * BaseGameClass::CostMultiplier * BaseGameClass::GlobalCostMultiplier;
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