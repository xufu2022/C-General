# Behavioral Pattern: Chain of Responsibility

Describing the chain of responsibility pattern 
- Document validation and approval chain

Structure of the chain of responsibility pattern

## Chain of Responsibility
The intent of this pattern is to avoid coupling the sender of a request to 
its receiver by giving more than one object a chance to handle the 
request. It does that by chaining the receiving objects and passing the 
request along the chain until an object handles it. 

## Describing the Chain of Responsibility Pattern

- Too many conditional statements
- Validation method becomes bloated
- Cannot easily reuse this code

IHandler<T>
void Handle(T request