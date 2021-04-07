// ClickerGameFramework.h

#pragma once

#define DEFAULT_DPC 1
#define DEFAULT_DPT 0
#define DEFAULT_MULT 1.15

using namespace System;

namespace ClickerGameFramework 
{	
	public ref class Upgrade
	{
	public:
		delegate bool UnlockCriteria();
		delegate String^ UpgradeBonus();

	private:
		float _baseCost;
		String^ _name;
		UnlockCriteria^ _unlocked;
		UpgradeBonus^ _upgradeBonus;

	public:
		Upgrade(String^, float, UnlockCriteria^, UpgradeBonus^);

		property String^ Name
		{
			String^ get();
		};
		property float BaseCost
		{
			float get();
		};
		property bool Unlocked
		{
			bool get();
		};
		property String^ UpgradeValue
		{
			String^ get();
		};
	};

	public ref class Building
	{
	private:
		float _baseDPT;
		float _baseCost;
		float _currentDPT;
		float _currentCost;
		float _costMultiplyer;
		String^ _name;
		int _quantity;

	public:
		Building();
		Building(String^, float, float);
		Building(String^, float, float, float);

		property float BaseDPT 
		{
			float get();
		};
		property float BaseCost
		{
			float get();
		};
		property float CurrentDPT
		{
			float get();
			void set(float);
		};
		property float CurrentCost
		{
			float get();
			void set(float);
		};
		property float CostMultiplyer
		{
			float get();
			void set(float);
		};
		property String^ Name
		{
			String^ get();
		};
		property int Quantity
		{
			int get();
			void set(int);
		};

		//void addToQuantity(int);
		//void addDPTToMainOperator();
		void updateCost();

		int Test(int);
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
