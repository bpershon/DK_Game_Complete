# Donkey Kong Country - By Macrosoft
This is the full documentation for this project. It will be updated more as the game progresses.

## Running the project
The project is a standard visual studio solution. The one catch is that we setup MonoGame as a dependency using Nuget. This means that before you can build the project for the first time, you may have to restore the packages in Visual Studio. Below are step-by-step instructions on how to do this.

### Restoring Nuget Packages in VS
1. Open the project in Visual Studio and right click on the solution in the solution manager.
2. Select the option "Restore Nuget Packages". It is possible that this option will not appear if Nuget was not installed properly on your marchine - for example, this is the case on the school computers. If this is the case, you'll have to add MonoGame manually. Instructions for this are shown below.
3. Check the "References" section to assure that MonoGame appears without a red X
4. Ensure the project builds.

### Adding MonoGame manually (without Nuget)
1. Open the project and click the arrow to display all of the items under "References" in the solution explorer.
2. You should see a reference to MonoGame, with a red X. Delete this reference.
3. Right click on your project and click "Add -> Reference". 
4. In the window that appears, click the "Browse" option and navigate to the directory in which MonoGame is installed. Open the file containing the compiled libraries(DesktopGL) and select "MonoGame.dll".
5. The project should now build.

### Player Controls
- Left = Move Left
- Right = Move Right
- Down = Crouch
- Up = Jump
- A = Swap characters (Diddy vs. DK) or dismount from Rambi
- X = Roll or Throw Barrel or charge with Rambi
- R = Reset gameplay to initial state
(Note: Press R after dying to reset, game automatically resets after winning)
- Q = Quit game

### Code Analysis Warnings
We suppressed various warnings from Visual Studio's Code Analysis tool under these rationales.

- CA1002 ("Change 'List<...> to use Collection<...>"): List<...> is type-safe, but Collection<...> is not.
- CA1006 ("Consider a design where..."): This design was recommended in class.
- CA1014 ("Mark '...' with CLSCompliant(true) ..."): We were instructed to ignore this.
- CA1026 ("Replace method ... with an overload that supplies all default arguments"): We will not need to specify each argument by default.
- CA1044 ("Because property... is write-only..."): This property should remain a property so that it can be used as a private field by an implementing class.
- CA1051 ("Because field... is visible..."): This field is not accessed like a property, it exists for its extending classes.
- CA1801 ("Parameter ... is never used"): It will be used in later Sprints.
- CA1811 ("... appears to have no upstream public or protected callers"): It will be used in later Sprints.
- CA1815 ("... should override Equals / equality operators"):  We will not need these operators.
- CA1822 (""The 'this' parameter is never used.): It will be used in later Sprints. 
- CA1823 ("It appears that field ... is never used or is only assigned to"): It will be used in later Sprints.
- CA2214 ("... contains a call chain... Review the following..."):  We need these implementing classes to simplify our state logic.  We have reviewed the code stack, there are no unintended consequences.
- CA2227 ("Change... to be read-only..."): This change breaks our codebase, this property is set in current code.
- CA1006 ("DoNotNestGenericTypesInMemberSignatures"): Dictionary maps a tuple of 2 gameobject types and a collision side. Matt advised the tuple creation/nesting was fine as this mimics examples in collision slides
- CA1708 ("IdentifiersShouldDifferByMoreThanCase"): Error is a result of the protected modifier used for the interal property values. DKKongTile is used as a base class to decorate the 4 kong tiles
- CA1051 ("DoNotDeclareVisibleInstanceFields"): same rationale as above
- CA1024 ("UsePropertiesWhereAppropriate for FontFactory.GetHudFont"): In this case, it makes sense for readability purposes that we access the hudfont property in this manner