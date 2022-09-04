# Behavioral Pattern: Visitor

- Describing the visitor pattern
  - Calculating discounts for employees and customers
- Structure of the visitor pattern
- Pattern variation: simplifying the visitor interface

# Visitor
The intent of this pattern is to represent an operation to be performed on the elements of an object structure. Visitor lets you define a new operation without changing the classes of the elements on which it operates. 

# Use Cases for the Visitor Pattern

> When an object structure contains many classes of objects with differing interfaces, and you want to perform operations on them that depend on their concrete classes

> When the classes defining your object structure don't have to change often, but you do often want to define new operations over the structure

> When you've got potentially many operations that need to be performed on objects in your object structure, but not necessarily on all of them



# Pattern Consequences 

> It makes adding new operations easy; you can define a new operation by creating a new visitor: open/closed principle
> A visitor can accumulate info on the objects it visits
> A visitor gathers related operations together (and separates unrelated ones: single responsibility principle
> Adding a new ConcreteElement class can be hard
> It might require you to break encapsulation

