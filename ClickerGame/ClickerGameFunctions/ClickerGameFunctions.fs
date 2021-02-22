namespace ClickerGameFunctions
open System

(*type Class1() = 
    member this.X = "F#"*)

module MainFunctions = 

    //calculates current dollars per second and dollars per click
    let moneyMultiplyer baseDPS multDPS addDPS : float32 =
        //let baseDPS = 1.0F
        multDPS * baseDPS + addDPS

    let example1 = moneyMultiplyer 0.5F 1.5F 2.0F

module BuildingFunctions =
    //calculates cost of next building
    let nextCost currentCost multiplyer : float32 = 
        currentCost * multiplyer
        
    //calculates new DPT for a building
    let nextDPT baseDPT quantity : float32 =
        baseDPT * quantity

(*module BuildingFunctions =
    let DEFAULT_MULT : float32 = 1.15F

    let private nextCostDefault currentCost : float32 =
        currentCost * DEFAULT_MULT
    let private nextCostCustom currentCost multiplyer : float32 = 
        currentCost * multiplyer

    type Parameters = 
    | Default of float32
    | Custom of float32 * float32

    //calculates cost of next building
    let nextCost = function
        | Default(currentCost) -> nextCostDefault currentCost
        | Custom(currentCost, multiplyer) -> nextCostCustom currentCost multiplyer

    //let nextCost currentCost : float32 =
    //    currentCost * DEFAULT_MULT
    //let nextCost currentCost multiplyer : float32 = 
    //    currentCost * multiplyer
        
    //calculates new DPT for a building
    let nextDPT baseDPT quantity : float32 =
        baseDPT * quantity
*)

(*module Test =
    let a =
        BuildingFunctions.BuildingCost.nextCost*)