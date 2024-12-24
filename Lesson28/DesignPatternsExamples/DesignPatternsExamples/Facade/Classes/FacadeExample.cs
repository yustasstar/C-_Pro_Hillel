using System;

namespace DesignPatternsExamples.Facade.Classes
{
    public class FacadeExample
    {
        public void TestFacade()
        {
            Dimmer dimmer = new Dimmer();
            DvdPlayer dvdPlayer = new DvdPlayer();
            Dvd dvd = new Dvd("Nu Pogodi!");
            HomeTheatreFacade homeTheater = new HomeTheatreFacade(dimmer, dvd, dvdPlayer);

            homeTheater.WatchMovie();
            Console.WriteLine();
            homeTheater.Pause();
            Console.WriteLine();
            homeTheater.Resume();
            Console.WriteLine();
            homeTheater.Pause();
        } 
    }
}
