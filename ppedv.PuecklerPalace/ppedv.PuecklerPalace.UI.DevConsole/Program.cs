﻿using Autofac;
using Microsoft.EntityFrameworkCore;
using ppedv.PuecklerPalace.Logic;
using ppedv.PuecklerPalace.Model.Contracts;
using ppedv.PuecklerPalace.Model.DomainModel;

Console.WriteLine("*** Pückler Palace v0.1 PREMIUM EDITION ***");
string conString = "Server=(localdb)\\mssqllocaldb;Database=PücklerDb_Test;Trusted_Connection=true;";

//DI direkt per Hand
//IRepository repo = new ppedv.PuecklerPalace.Data.Db.PuecklerContextRepositoryAdapter(conString);

//DI per Reflection
//var path = @"C:\Users\Fred\source\repos\ppedvAG\241410_Architektur\ppedv.PuecklerPalace\ppedv.PuecklerPalace.Data.Db\bin\Debug\net8.0\ppedv.PuecklerPalace.Data.Db.dll";
//var ass = Assembly.LoadFrom(path);
//var typeMitRepo = ass.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IRepository)));
//var repo = (IRepository)Activator.CreateInstance(typeMitRepo, conString);
//OrderService os = new OrderService(repo);


//DI per AutoFac
var builder = new ContainerBuilder();
builder.RegisterType<OrderService>();
builder.Register(x => new ppedv.PuecklerPalace.Data.Db.PuecklerContextRepositoryAdapter(conString))
       .AsImplementedInterfaces()
       .As<IRepository>();

var container = builder.Build();

OrderService os = container.Resolve<OrderService>();
var repo = container.Resolve<IRepository>();

foreach (var eis in repo.GetAll<Eissorte>().OrderBy(x => x.Preis))
{
    Console.WriteLine($"{eis.Name} - {eis.Eistyp} {eis.Preis}");
}

Console.WriteLine($"Most Orderd: {os.GetMostOrderdEissorte()?.Name}");