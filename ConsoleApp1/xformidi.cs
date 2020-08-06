using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    class xformidi
    {
        midiman conf;
	midimanSources sources;
        midimanRegions regions;
        midimanPlaylists playlist;

        int sourceCount;

       private midiman DeserializeObject(string filename)
        {
            Console.WriteLine("Reading with Stream");
            // Create an instance of the XmlSerializer.
            XmlSerializer serializer =
            new XmlSerializer(typeof(midiman));

            //midiman conf;


            using (Stream reader = new FileStream(filename, FileMode.Open))
            {
                // Call the Deserialize method to restore the object's state.
                conf = (midiman)serializer.Deserialize(reader);
            }
           sources    = conf.Items[0] as midimanSources;
           regions    = conf.Items[1] as midimanRegions;
           playlist = conf.Items[2] as midimanPlaylists;


            sourceCount = sources.Source.Length;


            return conf;
        }
        public override string ToString()
        {
            string str = base.ToString() + "\nSources are: \n";
            foreach (var s in sources.Source)
            {
                str += String.Format("   id {0} name {1}\n", s.id, s.name);
            }
            str += "Regions are: \n";
            foreach (var r in regions.Region)
            {
                str += String.Format("   id {0} name {1}\n", r.id, r.name);
            }
            str += "Playlists are: \n";

            foreach (var p in playlist.Playlist)
            {
                str += String.Format("   id {0} name {1}\n", p.id, p.name);
            }

            return str;
        }
        public string[] GetSourceFileNames()
        {

            string[] fname = new string[sourceCount];
            int i = 0;
            foreach (var s in sources.Source)
            {
                fname[i] = s.name;i++;
            }

            return fname;
        }
        public xformidi(string fname)
        {
            conf = DeserializeObject(fname);
        }
    }
}
