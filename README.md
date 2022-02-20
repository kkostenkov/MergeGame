
This repo is test task result.
No specs on readability, scalability, maintainability or speed of development were mentioned. So let's just flow with the code.

# MergeGame

## References:

MergeParty Android: https://play.google.com/store/apps/details?id=com.tripledot.merge.party.match.objects.pair.puzzle.game.friends
MergeParty iOS: https://apps.apple.com/us/app/merge-party/id1575528299
MergeMansion Android: https://play.google.com/store/apps/details?id=com.everywear.game
MergeMansion iOS: https://apps.apple.com/us/app/merge-mansion/id1484442152

## You need to implement simple board merge game. 
Game should have a board 7x7 with items on it.
You can merge two identical items to get a leveled up version of that item.
For example (Item A Level 1 + Item A Level 1 -> Item A Level 2)
Items that reached maximum level can no longer be merged.

## Please implement three item types:

- Simple item - just a item that can be merged

- Passive producer - item that spawnes other item (configurable) every X seconds (configurable) without any user interaction.
Spawned item should be placed on any free cell on the board. Still can be merged as simple items.

- Active Producers - item that spawnes other item (configurable) when user clicks on active producer item.

To limit user's ability to spam the board each active producer has charges. Each item spawn decreases charge count by 1.
If there is no charges active producer will no longer spawn items upon a click. 1 charge is refilled every X seconds (configurable).
Active producer can have up to N charges (configurable). Active producer still can be merged as simple items.

Please note that item can be active producer and passive producer at the same time

## Please implement such items:

- Item A Level 1
- Item A Level 2
- Item A Level 3
- Item A Level 4
- Item A Level 5
- Item A Level 6

- Item B Level 1
- Item B Level 2
- Item B Level 3 - Passive Producer (Spawns Item B Level 1 every 10 seconds)
- Item B Level 4 - Passive Producer (Spawns Item B Level 1 every  5 seconds)
- Item B Level 5 - Passive Producer (Spawns Item B Level 1 every  5 seconds) + Active Producer (Spawns - Item A Level 1, Up to 1 charge,  15 seconds refill time)
- Item B Level 6 - Passive Producer (Spawns Item B Level 1 every  5 seconds) + Active Producer (Spawns - Item A Level 1, Up to 2 charges, 10 seconds refill time)
- Item B Level 7 - Passive Producer (Spawns Item B Level 1 every  5 seconds) + Active Producer (Spawns Item A Level 1, Up to 3 charges,  5 seconds refill time)

Starting grid should contain one item - Item B Level 3
Game shoud be able to save\load it's state
You may choose any way to display game: UnityUI/Sprites/3d objects/whatever

We value you time - so no need to implement unit tests for this test task. You can also skip implementation of any sounds.
Please use LTS version of Unity to implement test project