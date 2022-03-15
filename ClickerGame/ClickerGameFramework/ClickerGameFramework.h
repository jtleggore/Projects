// ClickerGameFramework.h

#pragma once

#define DEFAULT_DPC 1
#define DEFAULT_DPT 0
#define DEFAULT_DPT_MULT 1
#define DEFAULT_COST_MULT 1
#define DEFAULT_NEXTCOST_MULT 1.15

using namespace System;

//todo: replace multiplyers with F# equations
namespace ClickerGameFramework 
{	
	//Class that holds common data of all game constructs
	public ref class BaseGameClass abstract
	{
	protected:
		float _baseCost;
		float _currentCost;
		String^ _name;
		//cost mult specific to an instance
		float _costMultiplier;

		//cost mult to entire game
		static float _globalCostMultiplier = DEFAULT_COST_MULT;

	public:
		BaseGameClass();

		property String^ Name
		{
			String^ get();
		};
		property float BaseCost
		{
			float get();
		};
		property float CurrentCost
		{
			float get();
			void set(float);
		};
		property float CostMultiplier
		{
			float get();
			void set(float);
		};

		static property float GlobalCostMultiplier
		{
			float get();
			void set(float);
		};
	};

	/*//Class that holds common data of all DPT (Dollars per tick) game objects
	private ref class BaseDPTObject : BaseGameClass
	{
	private:
		float _baseDPT;
		float _currentDPT;
		float _dptMultiplier;
	};

	//Class that holds common data of all DPC (Dollars per click) game objects
	private ref class BaseDPCObject : BaseGameClass
	{
	private:
		float _baseDPC;
		float _currentDPC;
		float _dpcMultiplier;
	};*/

	public ref class Upgrade : BaseGameClass
	{
	public:
		delegate bool UnlockCriteria();
		delegate int UpgradeBonus();

	private:
		UnlockCriteria^ _unlocked;
		UpgradeBonus^ _upgradeBonus;

	public:
		Upgrade(String^ name, float baseCost, UnlockCriteria^ unlockMethod, UpgradeBonus^ upgradeMethod);

		property bool Unlocked
		{
			bool get();
		};
		property int UpgradeValue
		{
			int get();
		};
	};

	public ref class Building : BaseGameClass
	{
	private:
		float _baseDPT;
		float _currentDPT;
		float _nextCostMultiplier;
		int _quantity;
		//DPT mult specific to an instance
		float _dptMultiplier;

		//DPT mult to entire game
		static float _globalDptMultiplier;

	public:
		Building(String^ name, float baseDPT, float baseCost);
		Building(String^ name, float baseDPT, float baseCost, float costMult);

		property float BaseDPT 
		{
			float get();
		};
		property float CurrentDPT
		{
			float get();
			void set(float);
		};
		property float nextCostMultiplier
		{
			float get();
			void set(float);
		};
		property int Quantity
		{
			int get();
			void set(int);
		};
		property float DPTMultiplier
		{
			float get();
			void set(float);
		};

		static property float GlobalDPTMultiplier
		{
			float get();
			void set(float);
		};

		void updateCost();
	};

	//represents the "game object"
	public ref class MainOperator
	{
		//DPC = dollars per click
		//DPT = dollars per tick
		private:
			float _baseDPC;
			float _baseDPT;
			float _currentDPT;
			float _currentDPC;
			float _currentDollars;

		public:
			MainOperator();

			property float BaseDPC
			{
				float get();
			};
			property float BaseDPT
			{
				float get();
			};
			property float CurrentDPT
			{
				float get();
				void set(float);
			};
			property float CurrentDPC
			{
				float get();
				void set(float);
			};
			property float CurrentDollars
			{
				float get();
				void set(float);
			};

			void doClick(float);
	};
}
