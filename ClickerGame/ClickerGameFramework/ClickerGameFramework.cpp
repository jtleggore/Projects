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

	const float Building::getBaseDPT()
	{
		return Building::_baseDPT;
	}

	const float Building::getBaseCost()
	{
		return Building::_baseCost;
	}

	const float Building::getCurrentDPT()
	{
		return Building::_currentDPT;
	}

	void Building::setCurrentDPT(float amount)
	{
		if (amount >= 0) 
		{
			Building::_currentDPT = round(amount);
		}
	}

	const float Building::getCurrentCost()
	{
		return Building::_currentCost;
	}

	void Building::setCurrentCost(float amount)
	{
		if (amount > 0)
		{
			Building::_currentCost = round(amount);
		}
	}

	const float Building::getCostMultiplyer()
	{
		return Building::_costMultiplyer;
	}

	void Building::setCostMultiplyer(float mult)
	{
		if (mult >= 1)
		{
			Building::_costMultiplyer = round(mult);
		}
	}

	const String^ Building::getName()
	{
		return Building::_name;
	}

	const int Building::getQuantity()
	{
		return Building::_quantity;
	}
	//pass in negative to subtract buildings
	void Building::addToQuantity(int amount)
	{
		Building::_quantity += amount;
		//todo: change this to an F# formula
		Building::setCurrentDPT(Building::getBaseDPT() * Building::_quantity);
		Building::updateCost();
	}

	void Building::addDPTToMainOperator() 
	{
		MainOperator::addToCurrentDollars(Building::getCurrentDPT());
	}

	//sets cost of building to the next cost
	void Building::updateCost()
	{
		float currentCost = Building::getCurrentCost();
		float costMult = Building::getCostMultiplyer();

		float nextCost = BuildingFunctions::nextCost(currentCost, costMult);
		Building::setCurrentCost(round(nextCost));
	}

	int Building::Test(int test)
	{
		float a = MainFunctions::moneyMultiplyer(1, 1, 1);
		return test * 3;
	}

	void MainOperator::InitializeMainOperator()
	{
		_baseDPC = DEFAULT_DPC;
		_baseDPT = DEFAULT_DPT;
		_currentDPC = _baseDPC;
		_currentDPT = _baseDPT;
		_currentDollars = 0;
	}

	const float MainOperator::getBaseDPT()
	{
		return MainOperator::_baseDPT;
	}

	const float MainOperator::getBaseDPC()
	{
		return MainOperator::_baseDPC;
	}

	const float MainOperator::getCurrentDPT()
	{
		return MainOperator::_currentDPT;
	}
	void MainOperator::setCurrentDPT(float dpt)
	{
		if (dpt >= 0)
		{
			MainOperator::_currentDPT = round(dpt);
		}
	}

	const float MainOperator::getCurrentDPC()
	{
		return MainOperator::_currentDPC;
	}
	void MainOperator::setCurrentDPC(float dpc)
	{
		if (dpc >= 0)
		{
			MainOperator::_currentDPC = round(dpc);
		}
	}

	const float MainOperator::getCurrentDollars()
	{
		return MainOperator::_currentDollars;
	}
	//pass in negative to subtract money
	void MainOperator::addToCurrentDollars(float amount)
	{
		MainOperator::_currentDollars += round(amount);
	}

	//run everytime click button is clicked
	void MainOperator::doClick(float amount)
	{
		MainOperator::addToCurrentDollars(round(amount));
	}
}