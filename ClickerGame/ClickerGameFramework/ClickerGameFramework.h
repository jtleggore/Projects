// ClickerGameFramework.h

#pragma once

#define DEFAULT_DPC 1
#define DEFAULT_DPT 0
#define DEFAULT_MULT 1.15

using namespace System;

namespace ClickerGameFramework 
{	
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
		Building(String^, float, float);
		Building(String^, float, float, float);

		const float getBaseDPT();

		const float getBaseCost();

		const float getCurrentDPT();
		void setCurrentDPT(float);

		const float getCurrentCost();
		void setCurrentCost(float);

		const float getCostMultiplyer();
		void setCostMultiplyer(float);

		const String^ getName();

		const int getQuantity();
		void addToQuantity(int);

		void addDPTToMainOperator();
		void updateCost();

		int Test(int);
	};

	public ref class Upgrade
	{
		private:
			float _baseCost;
	};

	//represents the "game object"
	public ref class MainOperator
	{
		//DPC = dollars per click
		//DPT = dollars per tick
		private:
			static float _baseDPC;
			static float _baseDPT;
			static float _currentDPT;
			static float _currentDPC;
			static float _currentDollars;

		public:
			//static pseudo-constructor
			static void InitializeMainOperator();

			static const float getBaseDPC();

			static const float getBaseDPT();

			static const float getCurrentDPT();
			static void setCurrentDPT(float);

			static const float getCurrentDPC();
			static void setCurrentDPC(float);

			static const float getCurrentDollars();
			static void addToCurrentDollars(float);

			static void doClick(float);
	};
}
