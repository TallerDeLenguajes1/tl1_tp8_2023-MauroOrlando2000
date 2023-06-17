using System;
using System.IO;
using System.Collections.Generic;
using ListaDeTareas;

List<Tarea> tareasPendientes = new List<Tarea>();
var tareasRealizadas = new List<Tarea>();
Random rnd = new Random();
int N = rnd.Next(1, 11), num = 0, i, total = 0;
bool anda;
string? text = "", Sumario = "";

for(i=0; i<N; i++)
{
    Tarea NTarea = new Tarea();
    anda = false;
    NTarea.ID = i+1;
    Console.WriteLine("\nTarea " + NTarea.ID);
    while(!anda)
    {
        Console.WriteLine("Ingrese la descipcion de la tarea " + NTarea.ID);
        text = Console.ReadLine();
        if(text == null)
        {
            Console.WriteLine("No puede ser una descripcion nula");
        }
        else
        {
            anda = true;
        }
    }
    NTarea.Desc = text;
    anda = false;
    while(!anda)
    {
        Console.WriteLine("Ingrese la duracion de la tarea " + NTarea.ID);
        text = Console.ReadLine();
        anda = int.TryParse(text, out num);
        if(!anda)
        {
            Console.WriteLine("Valor invalido");
        }
    }
    NTarea.Dura = num;
    Sumario += $"Duración Tarea {NTarea.ID}: {num}\n"; 
    total += num;
    tareasPendientes.Add(NTarea);
}
Sumario += $"Duracion total = {total}\n";

foreach(var tarea in tareasPendientes)
{
    Console.WriteLine("\nTAREA " + tarea.ID);
    Console.WriteLine("Descripcion: " + tarea.Desc);
    Console.WriteLine("Duracion: " + tarea.Dura);
}

anda = false;
while(!anda)
{
    while(!anda)
    {
        Console.WriteLine("\n\nQue desea hacer?\n1. Mostrar Tareas\n2. Mover tarea pendiente a realizada\n3. Buscar tarea por descripcion\n4. Volcar en un archivo las horas totales\nOtro número: Cerrar sesión");
        text = Console.ReadLine();
        anda = int.TryParse(text, out num);
        if(!anda)
        {
            Console.WriteLine("Valor invalido");
        }
    }
    switch(num)
    {
        case 1: Console.WriteLine("\n\nTAREAS PENDIENTES");
                foreach(var tarea in tareasPendientes)
                {
                    Console.WriteLine("\nTAREA " + tarea.ID);
                    Console.WriteLine("Descripcion: " + tarea.Desc);
                    Console.WriteLine("Duracion: " + tarea.Dura);
                }

                Console.WriteLine("\n\nTAREAS REALIZADAS");
                foreach(var tarea in tareasRealizadas)
                {
                    Console.WriteLine("\nTAREA " + tarea.ID);
                    Console.WriteLine("Descripcion: " + tarea.Desc);
                    Console.WriteLine("Duracion: " + tarea.Dura);
                }
                anda = false;
        break;
        case 2: anda = false;
                int count = tareasPendientes.Count();
                while(!anda || num > count)
                {
                    Console.WriteLine("\nQue tarea desea mover como realizada? Ingrese el ID");
                    text = Console.ReadLine();
                    anda = int.TryParse(text, out num);
                    if(!anda || num > count)
                    {
                        Console.WriteLine("Valor invalido");
                    }
                    else
                    {
                        i = 0;
                        while(i < count)
                        {
                            if(num == tareasPendientes[i].ID)
                            {
                                var seleccionado = tareasPendientes[i];
                                tareasRealizadas.Add(seleccionado);
                                tareasPendientes.Remove(seleccionado);
                                count--;
                            }
                            i++;
                        }
                    }
                }
                anda = false;
        break;
        case 3: anda = false;
                while(!anda || text == null)
                {
                    Console.WriteLine("Ingrese la descripcion a buscar");
                    text = Console.ReadLine();
                    if(text == null)
                    {
                        Console.WriteLine("No puede ser una descripcion nula");
                    }
                    else
                    {
                        anda = true;
                    }
                }
                count = tareasPendientes.Count();
                i = 0;
                foreach(var tarea in tareasPendientes)
                {
                    if(tarea.Desc.IndexOf(text) != -1)
                    {
                        Console.WriteLine("TAREA ENCONTRADA");
                        Console.WriteLine("Tarea " + tarea.ID);
                        Console.WriteLine("Descripcion: " + tarea.Desc);
                        Console.WriteLine("Duracion: " + tarea.Dura);
                    }
                    else
                    {
                        i++;
                    }
                }
                if(i == count)
                {
                    Console.WriteLine("TAREA NO ENCONTRADA");
                }
                anda = false;
        break;
        case 4: string archivo = @"D:\git 3.0\tl1_tp8_2023-MauroOrlando2000\duracion.txt";
        using(StreamWriter sw = File.CreateText(archivo))
        {
            sw.Write(Sumario);
        }
        anda = false;
        break;
        default: anda = true;
        break;
    }
}