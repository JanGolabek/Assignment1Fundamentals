# Build a console application in .NET

For this assignment I made an RPG game in which a user can make their own warrior, give them a name, level them up, and equip them with items. 

## System explanation

With help from draw.io I managed to make a diagram of the system's architecture and how I understood the assignment. 

The main class, Warrior, has most of the program's functionality. This is where we can create the warrior, equip him, level him up, calculate his total attributes and damage. 

EQ, or equipmnent, is a list of slots where the warrior may equip items. In the Item class we can see that an item consists of a name, an EQ-slot and a required level. The Item is the parent of both Weapon and ArmorItem. WeaponItem consists of the field used in Item, but has two own fields WeaponDamage (an int) and WeaponType (an enum). WeaponDamage is used to calculate the total damage, and WeaponType holds information about which type of weapon the item is. 

## Diagram and project's architecture


![image](https://github.com/JanGolabek/Assignment1Fundamentals/assets/77743690/d25675f5-93db-45ff-bb8a-d94734c8b86f)

This image shows what I pictured the structere would look like in the beginning. Unfortunetly, the diagram did not save and I only have this screenshot. To make a comparison I would have to make a new one, something I simply don't have the time to do because I have to start on the assignment two.

I used a little too much time on trying to make my own understanding of the assignment by drawing a structure of it, instead of following the assignment step by step. Even though my assignment is far from complete, I'm really glad that I used this UML-diagram approach because I finally understood what OOP really is about. It's about building a structure and making it as easy as possible to maintain. It's about thinking logically and looking "into the future".

This database diagramming that I am familiar with made me understand why the structure of the program is so important. I thought of the O's as foreign keys which we get from other tables (classes). It's about sharing the functionality between the objects, not making everything in one file and making the code unchangeable and unworkable with. 

One thing I definitely did wrong was to print things out in the console, instead of just making tests. This approach was completely wrong and took a very long time to fix (in the end I only managed to make 6 tests). I'm a so called visual programmer who likes when the code makes things right in front of me, without thinking about the later consequences of it. Maybe the right approach would be to not only print things out in the console, but maybe make tests at the same time. Some kind of a hybrid solution.

Even though I didn't manage to find enough time to make the tests, my code shows that most of the functions that were meant wo work, worked (but in console, not in tests). Things started to go a little bit south after this commit:
https://github.com/JanGolabek/Assignment1Fundamentals/commit/a594a9b926d17335f366e0606a5f628545e5fb6f

## Unit testing and dependencies

This console app was made in .NET 6.0 and Xunit framework for testing. To run the application simply clone the repository and run the program with an IDE which can open code wrote in C# (Visual Studio).



## Final reflection

I wish I had more time to finish the assignment. Unfortunately we have to start on a new assignment tomorrow. One thing I see that I definitely did wrong was not making a Hero/Warrior parent with subclasses as children. Instead, I made an object called CharacterClass. I can see how that's not a good approach with regard to principles of OOP. That's a thing I definitely would change. I need to get better at time managing with projects in C#, since I'm completely new to the subject. I learned a lot from this assignment and will try to finish it in my spare time in the future.



## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

Please make sure to update tests as appropriate.

## Author

Jan Golabek
