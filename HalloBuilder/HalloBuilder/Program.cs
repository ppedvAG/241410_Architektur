// See https://aka.ms/new-console-template for more information
using HalloBuilder;

Console.WriteLine("Hello, World!");


var s1 = new Schrank.Builder("blau")
                    .SetAnzBöden(2)
                    .SetAnzTüren(14)
                    .Create();
