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
        /// Tries to parse into an integer
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
        /// Turns the bytes ammount into MegaBytes
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
            if(!File.Exists(storagePath))
            {
                var newFile = File.Create(storagePath);
                newFile.Close();
            }

            FileStream fileStream = File.OpenRead(storagePath);
            FileStream fs = fileStream;
            if (fs.Length == 0) return new List<StorageSpace>();

            var storageList = await JsonSerializer.DeserializeAsync<List<StorageSpace>>(fs);

            return storageList;
        }
    }
}
