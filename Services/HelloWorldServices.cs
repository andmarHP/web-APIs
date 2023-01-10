using System.Collections.Generic;
using System;
using webAPI.Models;

namespace webAPI.Services
{
    public class HelloWorldServices:IHelloWorldService
    {
        private static List<Boleto> lstBoletos = new List<Boleto>();
        public HelloWorldServices()
        {
            lstBoletos = new List<Boleto>()
            {
                new Boleto{ Name = "Carlos"},
                new Boleto{ Name = "Maria"},
                new Boleto{ Name = "Luisa"},
                new Boleto{ Name = "Pedro"},
                new Boleto{ Name = "Jose"},
                new Boleto{ Name = "Antonio"},
                new Boleto{ Name = "Aldonsa"},
                new Boleto{ Name = "Sofia"},
                new Boleto{ Name = "Miguel"},
                new Boleto{ Name = "Fernanda"},
            };
        }
        public string GetHelloWorld()
        {
            return "Hello World";
        }
        public string GetName(string name)
        {
            return "Hello" + name;
        }
        public List<int> GetNumeros()
        {
            var list = new List<int>(){1,2,3,4,5,6,7,8,9,10};
            return list.ToList();
        }
        public List<Boleto> GetBoletos()
        {
            var myLista = lstBoletos;
            return myLista;
        }
    }

    public interface IHelloWorldService
    {
        string GetHelloWorld();
        string GetName(string name);
        List<int> GetNumeros();
        List<Boleto> GetBoletos();
    }
}