# Welcome To The Gilded Rose

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=MindShaver_gilded-rose-challenge&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=MindShaver_gilded-rose-challenge)

### What you'll need

* Visual Studio

### The Challenge:

- Complete the User Story (US897387)
- Resolve the Defect (DE783598)
- Create a PR with a passing build

### Description

Hi and welcome to team Gilded Rose. As you know, we are a small inn with a 
prime location in a prominent city ran by a friendly innkeeper named 
Allison. We also buy and sell only the finest goods. Unfortunately, our 
goods are constantly degrading in quality as they approach their sell by 
date. We have a system in place that updates our inventory for us. It was 
developed by a no-nonsense type named Leeroy, who has moved on to new 
adventures.

Leeroy wasn't that big on tests. While
he did get our system out there it seems to have a bug. Also, we need to add a little bit of new functionality to the software.

The patrons have been complaining that their Aged Brie isn't as aged as we say it is.
There must be something wrong with how the quality is being updated but, the owners
can't understand the code enough to take a stab at it.

This is where you come in!

Your task is to fix the bug and add the new feature to our system so that we 
can begin selling a new category of items. First an introduction to our 
system:

### System Documentation

- All items have a **SellIn** value which denotes the number of days we have 
to sell the item
- All items have a **Quality** value which denotes how valuable the item is
- At the end of each day our system lowers both values for every item

Pretty simple, right? Well this is where it gets interesting:

- Once the sell by date has passed, `Quality` degrades *twice as fast*
- The `Quality` of an item is never negative
- "Aged Brie" actually *increases* in `Quality` the older it gets
- The `Quality` of an item is never more than 50
- "Sulfuras", being a legendary item, never has to be sold or decreases 
in `Quality`
- "Backstage passes", like aged brie, increases in `Quality` as it's `SellIn` 
value approaches; `Quality` increases by 2 when there are 10 days or less 
and by 3 when there are 5 days or less but `Quality` drops to 0 after the 
concert

### US897387 - Add Conjured Items

#### "Conjured" items degrade in Quality twice as fast as normal items

```
GIVEN an Item with the prefix [Conjured] is in the System
  (ex. Name = "[Conjured] Potion of Lesser Healing")
WHEN UpdateQuality is run
THEN the Conjured Item's Quality is reduced by TWO
```

### DE783598 - Aged Brie is aging too quickly

Our patrons are saying that their Aged Brie isn't as aged as we are saying.
Refer to the documentation for Aged Brie requirements

## Conclusion

Feel free to make any changes to the UpdateQuality method and add any 
new classes/code as long as everything still works correctly. However, **do not** 
alter the Item class or Items property as those belong to the goblin 
in the corner who will insta-rage and one-shot you as he doesn't 
believe in shared code ownership (you can make the UpdateQuality 
method and Items property static if you like, we'll cover for you).

Just for clarification, an item can never have its Quality increase 
above 50, however "Sulfuras" is a legendary item and as such its 
Quality is 80 and it never alters.
