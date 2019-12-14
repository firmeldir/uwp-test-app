using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Model;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Serialization;

namespace UWP.Data
{
    class FileManager
    {

        public async static Task<List<Soldier>> GetSoldier()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.GetFileAsync("data.txt");
            string input = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);

            Debug.WriteLine(input);

            Team deserializedTeam = Newtonsoft.Json.JsonConvert.DeserializeObject<Team>(input);

            return deserializedTeam.soldiers.ToList();
        }

        public async static void Write(List<Soldier> soldiers)
        {
            Team team = new Team();
            
            team.soldiers = soldiers.ToArray();

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(team);

            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync("data.txt" ,  Windows.Storage.CreationCollisionOption.ReplaceExisting);

            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, output);

        }


    }
}

