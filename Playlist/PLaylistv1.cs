
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

public class Song
{

    public string Title { get; private set; }
    public string Artist { get; private set; }
    public double Duration { get; private set; }


    private  Song(string Titile,string Artist,double Duration)
    {
        this.Title = Titile;
        this.Artist = Artist;
        this.Duration = Duration;

    }

    public static Song Create(string Title, string Artist, double Duration)
    {
        if (Duration <= 0)
            throw new ArgumentException("Duration must be positive");

        return new Song(Title, Artist, Duration);
    }
    
}






public class Playlist
{

    List<Song> songs = new List<Song>();
    public void Addsong(string Title, string Artist, double Duration)
    {
        // 🔹 Ավելացնել երգ (անվտանգ՝ Create մեթոդով)
        Song song = Song.Create(Title, Artist, Duration);
        songs.Add(song);

    }


    public void ShowAll()
    {

        foreach (var song in songs)
        {
            Console.WriteLine($"{song.Title} - {song.Artist} was added!");
        }


    }


    //Sort by Title  
    public List<Song> SortByTitle()
    {
        return songs.OrderBy(s => s.Title).ToList();
    }

    // Sort By Artist
    public List<Song> SortByArtist()
    {
        return songs.OrderBy(s => s.Artist).ToList();
    }
    //Sort by minutes
    public List<Song> SortByDurationDescending()
    {
        return songs.OrderByDescending(s => s.Duration).ToList();
    }



    // 🔹 Դասավորել ըստ տևողության (նվազման կարգով)
    // 
    /*public Sortby(List songs)
     {
        var Sortedbytitle = songs.OrderBy(s => s.Title).ToList() ;
        var SortedByArtist = songs.OrderBy(s => s.Artist).ToList();
        var SortedByDuration = songs.OrderBy(s => s.duration).ToList();

         return List<SortedByArtist>;
    }

      }*/

    public double TotalDuration()
    {
        double sum = 0;
        foreach (var song in songs)
        {
            sum = sum + (song.Duration);

            //syntax error (double - int)
            //int amboxj = (int)sum;
            //int mnacord = sum - amboxj;

            while (sum - Math.Truncate(sum) >= 0.60)
            {
                double amboxj = Math.Truncate(sum);
                double mnacord = sum - amboxj;
                sum = (amboxj + 1) + (mnacord - 0.60);

            }

        }
        return sum;
    }

}


    class Program
    {

        static void Main(string[] args)
        {
            //stexcel nor playlist arajin@
            var Playlist = new Playlist();

            //avelancel nor erger 
            //var song1 = new Song("Kolibri", "Miyagi", 3.46);
            //var song2 = new Song("Patron", "Miyagi", 3.36);
            //Song songs = new Song.Addsong(song1);
            //Song songs = new Song.Addsong(song1);
            
            Playlist.Addsong("patron", "Miyagi", 3.42);
            Playlist.Addsong("Brat peredal", "Andy panda", 3.24);
            Playlist.Addsong("Kolibri", "Miyagi", 2.40);

        //cuyc tal bolor@
        Playlist.ShowAll();


        Console.WriteLine("\nPLaylist is sorted by the name of the artist");
          var SortT = Playlist.SortByTitle();
        foreach (var song in SortT)
        {

            Console.WriteLine($"{song.Title}-{song.Artist}:{song.Duration}");

        }
        Console.WriteLine("\nPLaylist is sorted by the duration ");
         var SortD = Playlist.SortByDurationDescending();
        foreach (var song in SortD)
        {
            Console.WriteLine($"{song.Title}-{song.Artist}:{song.Duration}");
        }

        Console.WriteLine("\nPLaylist is sorted by the Title ");
        var SortA = Playlist.SortByArtist();
       foreach (var song in SortA)
        {
            Console.WriteLine($"{song.Artist}-{song.Title}:{song.Duration}");

        }
        double total = Playlist.TotalDuration();
            Console.WriteLine($"\nTotal amount of minutes is  {total:F2} ");

            //double totalsum = TotalDuration(sum);
            /*Console.WriteLine($"Sum duration of the playlist is,{sum}");

           foreach (var song in  playlist.SortedByArtist())
             {
                Console.WriteLine(" {0} - {1} ",Song.Artist,song.Title);
            }

            Console.ReadKey();*/
            Console.WriteLine("\nPlease enter  any key");
            Console.ReadKey();


        }

    }







