using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPersonTyper
{
    /**
     * For mekanikere regi­stre­res endvidere år for svendeprøve samt en timeløn. Igen skal det være muligt at hente og opdatere begge attributter.
     */
    public class Mekaniker : Person
    {

        public Mekaniker(string navn, string adresse, int årForSvendeprøve, double timeløn) : base(navn, adresse)
        {
            ÅrForSvendeprøve = årForSvendeprøve;
            Timeløn = timeløn;
        }

        public int ÅrForSvendeprøve { get; set; }
        
        public double Timeløn { get; set; }


        public override void print()
        {
            Console.WriteLine($"Navn: {Navn}, Adr: {Adresse}, År for svendeprøve: {ÅrForSvendeprøve}, Timeløn: {Timeløn}, Ugeløn: {this.Ugeløn()}");
        }

        public virtual double Ugeløn()
        {
            return Timeløn * 37;
        }
    }
}
