using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPersonTyper
{
    /**
     *   For værkførere (der også er mekanikere) registreres år for udnævnelse til værkfører samt størrelsen af det tillæg pr. uge, 
     *   som værk­føreren gives ud over den almindelige timeløn.
     */
    public class Værkfører : Mekaniker
    {


        public Værkfører(string navn, string adresse, int årForSvendeprøve, double timeløn, int årForUdnævnelse, double tillægPrUge) 
            : base (navn, adresse, årForSvendeprøve, timeløn)
        {
            ÅrForUdnævnelse = årForUdnævnelse;
            TillægPrUge = tillægPrUge;
        }

        public int ÅrForUdnævnelse { get; }
        public double TillægPrUge { get; set; }

        public override void print()
        {
            Console.WriteLine($"Navn: {Navn}, Adr: {Adresse}, År for svendeprøve: {ÅrForSvendeprøve}, Timeløn: {Timeløn}, " +
                $"År for udnævnelse: {ÅrForUdnævnelse}, Tillæg pr. uge {TillægPrUge}, Ugeløn: {this.Ugeløn()}");

        }

        public override double Ugeløn()
        {
            return base.Ugeløn() + TillægPrUge;
        }
    }
}
