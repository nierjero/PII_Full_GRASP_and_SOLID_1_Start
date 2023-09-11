//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

    public double GetProductionCost() /// El princpio que use para determinar el porque poner la clase en recipe fue GRASP,
                                        ///  entendiendo que era la unica clase con acceso a toda la información de los productos usados por el usuario(INPUT)
{
    double totalCostInput = 0.0;
    double totalCostProduct = 0.0;
    double totalTotalCost = 0.0;

    foreach (Step step in this.steps)
    {
        totalCostInput += step.Quantity * step.Input.UnitCost;
        totalCostProduct += (step.Time/60) * step.Equipment.HourlyCost; 
    }

     totalTotalCost = totalCostInput + totalCostProduct;
    return totalTotalCost;
}

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            Console.WriteLine("Costo total: " + GetProductionCost());
            
        }
    }
}