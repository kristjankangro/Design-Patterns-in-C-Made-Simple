# Design Patterns in C# Made Simple by Zoran Horvat


# 5 Abstract Factory
## Goal
### Good
* decouple consumer from constructing related objects
  * standardize interaction with constructed objects
  * Concrete set of classes provides concrete factory
  * Consumer does not know concrete classes
  * Concrete set of classes can be substituted later
* Applies to consumer using related objects in an operation
* Substitutes concrete implementations would be impossible
### Pitfalls
* decoupling is incomplete
* subtle coupling with concrete
* construction process makes libs operate differently
* attempts to smooth differences out