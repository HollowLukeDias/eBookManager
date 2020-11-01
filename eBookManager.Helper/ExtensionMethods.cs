using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using eBookManager.Engine;

namespace eBookManager.Helper
{
    public static class ExtensionMethods
    {

        /// <summary>
        /// Helper function that tries to parse into an integer
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultInteger"></param>
        /// <returns></returns>
        public static int ToInt(this string value, int defaultInteger = 0)
        {
            try
            {
                if (int.TryParse(value, out int validInteger))
                { 
                    return validInteger;
                }
                else
                {
                    return defaultInteger;
                }
            }
            catch
            {
                return defaultInteger;
            }
        }

        /// <summary>
        /// Helper functions that turns the bytes ammount into MegaBytes
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static double ToMegaBytes(this long bytes) 
            => ( bytes > 0) ? ((bytes / 1024f) / 1024f) : bytes;


        /// <summary>
        /// Checks if a storage space already exists
        /// </summary>
        /// <param name="space"></param>
        /// <param name="nameValueToCheck"></param>
        /// <param name="storageSpaceId"></param>
        /// <returns></returns>
        public static bool StorageSpaceExists(this List<StorageSpace> space, string nameValueToCheck, out int storageSpaceId)
        {
            bool exists = false;
            storageSpaceId = 0;
            if (space.Count() != 0)
            {
                //Tries to find a storage space with the same name, if it is not found, the ID of the storage space will be the next available integer
                int count = (from r in space
                             where r.Name.Equals(nameValueToCheck)
                             select r).Count();
                if (count > 0) exists = true;
                storageSpaceId = (from r in space
                                  select r.ID).Max() + 1;
            }
            return exists;
        }

        /// <summary>
        /// Asynchronously write into the data store
        /// </summary>
        /// <param name="value"></param>
        /// <param name="storagePath"></param>
        /// <param name="appendToExistingFile"></param>
        /// <returns></returns>
        public async static Task WriteToDataStore(this List<StorageSpace> value,
            string storagePath, bool appendToExistingFile = false)
        {
            //Creates the fille and serializes the information on value into the file with that path
            using (FileStream fs = File.Create(storagePath))
                await JsonSerializer.SerializeAsync(fs, value);
        }
        
        /// <summary>
        /// Adynchronously reads from the data store
        /// </summary>
        /// <param name="value"></param>
        /// <param name="storagePath"></param>
        /// <returns></returns>
        public async static Task<List<StorageSpace>> ReadFromDataStore(this List<StorageSpace> value, string storagePath)
        {
            //If the file doesn't exist, it will be created
            if(!File.Exists(storagePath))
            {
                var newFile = File.Create(storagePath);
                newFile.Close();
            }

            //It open the file and puts the Json information into the storage spaces
            FileStream fileStream = File.OpenRead(storagePath);
            if (fileStream.Length == 0) return new List<StorageSpace>();

            var storageList = await JsonSerializer.DeserializeAsync<List<StorageSpace>>(fileStream);

            //Returns the storage space list with all the informations inside the Json inside of it
            return storageList;
        }
    }
}
