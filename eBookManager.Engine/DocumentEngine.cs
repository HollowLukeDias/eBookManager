using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace eBookManager.Engine
{
    public class DocumentEngine
    {
     
        /// <summary>
        /// Returns a tuple with useful file properties
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public (DateTime dateCreated,
                DateTime lastDateAccessed,
                string fileName,
                string fileExtension,
                long fileLength,
                bool error)
                GetFileProperties(string filePath)
        {
            //Initializes the tuple with default values
            var returnTuple = (created: DateTime.MinValue,
                               lastDateAccessed: DateTime.MinValue, name: "", ext: "",
                               fileSize: 0L, error: false);

            //Tries to find the file with the path equals to filePath, if it can be found, its values are added, otherwise error returns as true
            try
            {
                FileInfo fi = new FileInfo(filePath);
                fi.Refresh();
                returnTuple = (fi.CreationTime, fi.LastAccessTime, fi.Name, fi.Extension, fi.Length, false);
            }
            catch
            {
                returnTuple.error = true;
            }
            return returnTuple;
        }


    }
}
