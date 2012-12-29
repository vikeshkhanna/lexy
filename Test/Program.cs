using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixPackApps.Lexy
{
    class Program
    {
        static void Main(string[] args)
        {
            string songPath = @"C:\Users\khann_000\Downloads\ENMFP_codegen\test.m4a";
            Song song = new Song(songPath);
            song.AddLyrics();
        }
    }
}
