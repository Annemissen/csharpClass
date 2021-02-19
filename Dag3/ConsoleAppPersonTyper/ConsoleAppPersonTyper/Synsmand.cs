using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPersonTyper
{
    /**
     *   En synsmand er også ansat på et værksted og er mekaniker. For hver Synsmand holder rede på, hvor mange syn han har lavet på en uge. 
     *   Hans ugeløn beregnes som antal syn i den pågældende uge * 290.
     */
    public class Synsmand : Mekaniker
    {

        public Synsmand(string navn, string adresse, int årForSvendeprøve, double timeløn, int antalSynDenneUge)
            : base(navn, adresse, årForSvendeprøve, timeløn)
        {
            AntalSynDenneUge = antalSynDenneUge;
        }

        public Synsmand(string navn, string adresse, int årForSvendeprøve, double timeløn)
            : base(navn, adresse, årForSvendeprøve, timeløn)
        {
            AntalSynDenneUge = 0;
        }

        public int AntalSynDenneUge { get; set; }
       
        public override double Ugeløn()
        {
            return base.Ugeløn() + AntalSynDenneUge * 209;
        }

        public override void print()
        {
            Console.WriteLine($"Navn: {Navn}, Adr: {Adresse}, År for svendeprøve: {ÅrForSvendeprøve}, Timeløn: {Timeløn}, " +
                $"Antal syn denne uge: {AntalSynDenneUge}, Ugeløn: {this.Ugeløn()}");

        }


    }
}
