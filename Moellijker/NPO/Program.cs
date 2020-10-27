using System;

namespace NPO
{
    class Program
    {
        static void Main(string[] args)
        {
            Jasper j = new Jasper();
            Radiostation npo3 = new Radiostation();
            npo3.Subscribers += ViaAether;
            npo3.Subscribers += ViaSMS;
            npo3.Subscribers += ViaTeletext;
            npo3.Subscribers += ViaPostduif;
            npo3.Subscribers += ViaAether;
            npo3.Subscribers += ViaSMS;
            npo3.Subscribers += ViaTeletext;
            npo3.Subscribers += ViaPostduif;
            npo3.Subscribers += ViaAether;
            npo3.Subscribers += ViaSMS;
            npo3.Subscribers += ViaTeletext;
            npo3.Subscribers += ViaPostduif;
            npo3.Subscribers += ViaAether;
            npo3.Subscribers += ViaSMS;
            npo3.Subscribers += ViaTeletext;
            npo3.Subscribers += ViaPostduif;
            npo3.Subscribers += ViaAether;
            npo3.Subscribers += ViaSMS;
            npo3.Subscribers += ViaTeletext;
            npo3.Subscribers += ViaPostduif;
            npo3.Subscribers += ViaAether;
            npo3.Subscribers += ViaSMS;
            npo3.Subscribers += ViaTeletext;
            npo3.Subscribers += ViaPostduif;
            npo3.Subscribers += j.ViaRooksignalen;

            //npo3.Subscribers("Heyyy klojo's");

            npo3.Broadcast();

        }

        static void ViaAether(string message)
        {
            Console.WriteLine($"Via ether: {message}");
        }
        static void ViaSMS(string message)
        {
            Console.WriteLine($"Via SMS: {message}");
        }
        static void ViaTeletext(string message)
        {
            Console.WriteLine($"Via teletext: {message}");
        }
        static void ViaPostduif(string message)
        {
            Console.WriteLine($"Via postduif: {message}");
        }
    }
}
