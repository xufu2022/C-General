// See https://aka.ms/new-console-template for more information
// Create instance of view model
using _03_CreateModify.ViewModels;

CreateViewModel vm = new();

// Call Sample Method
var po= vm.CreateEmptyDocument();

// Stop console to view results
Console.ReadKey();