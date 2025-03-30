# Tutorial

## Topic

is boolean statement

## Author

Please write your name below. By adding your name as the author, you are certifying that you have researched and written all of the content on this page in your own words, and did not copy and paste it from another source.

Author name: Garrett Helms

## Overview

"is" in c# is shorthand for type checking. It checks whether an object is of a certain type.

## Purpose

This speeds things up tremendously in our GameManager. by checking the type of an object that collides with the player object, we can define whether that player will get \_lives-- or \_score++.

## Syntax

in our code, we use it to check if an object at index I is of the type "Bomb". if it is, lives are deducted. if not, then it is a reward and points are added.

```
 if (_gameObjects[i] is Bomb)
    _lives--;
else if (_gameObjects[i] is Reward)
    _score++;
```

## Discussion

So from what I've read online, this has to do with the concept of type checking, where we check if a statement will evaluate to true based on the type of the object. C# has very strong element-typing, so we can leverage that to our advantage by checking the typing of objects that collide with the player.

## Other Interesting Notes

This could also be used in combination with type-casting to do a "type-safe cast".
