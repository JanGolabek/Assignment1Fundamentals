# Build a console application in .NET

For this assignment I made a quite primitive RPG game

## Diagram and system explanation

With help from draw.io I managed to make a diagram the system's architecture and how I understood the assignment. 

The main class, Warrior, has most of the program's functionality, but the only variables that get made in the class are the warrior's name and level. This is where we generate the new warrior. The LevelUp method uses the warrior's attributes and level to calculate and update the values. The calculating of total attributes also happens here, since the Class has access to both EQ and Attributes. At last, the Display method, which displays the warrior's stats to the user.

Class, or WarriorClass, contains a local ClassName and gets it's attributes from the Attributes class. This class conatins only static integers which get used in other classes. In case of adding more both classes (f.e a ninja class) and attributes (f.e an armour attributes) we can just update these files.

Damage Class returns an integer calculated from the warrior's attributes and the warrior's weapon's damage.

EQ, or equipmnent, is a list of slots where the warrior may equip items. In the Item class we can see that and item consists of a name, an EQ-slot, a required level, and an integer item attribute. If the warrior's level is high enough, the item gets exported from the Not Valid to the Valid Types Class. This is also where Equip method is placed, which allows the user to equip the available items. In case of wanting to add new items to the game, we can simply add them in the Item class.
