(***************************
GETTING STARTED
---------------
1) Open this file
2) Press [Shift]+[P]
3) Type and select "FSI: start" and hit [Enter]
4) Select next line:

#load "Test.fsx";;

5) press [Alt]+[Enter]
6) To re-evaluate go into TERMINAL press arrow up until the "#load .." command shows up and press [Enter]

HINT:
Consider adding this to your VS Code settings:
    FSharp.fsiExtraParameters = [
        "--quiet",
        "--shadowcopyreferences+"
    ]
****************************)

#load "TestTools.fsx"
#load "MainMod/Emergencies.fsx"
open TestTools
open EMT.Modding

//getEmergency "ForestFireLarge"
//|> showEmergency

printfn "Broken Emergencies:"
printfn ""
getAllEmergenciesNot100Percent ()
|> Seq.iter showEmergency

