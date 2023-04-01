using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eigth_Laba
{
    public enum StateCodes
    {
        UP_TO_DATE,
        UPDATED_FILES,
        DELETED_FILES,
        NEW_FILES
    }

    class Model
    {
        private string mainFolderPath;
        private string secondaryFolderPath;
        private string[] MainFolderFiles;
        private string[] SecondaryFolderFiles;

        public Model(string MainFolderPath, string SecondaryFolderPath)
        {
            MainFolderFiles = Directory.GetFiles(MainFolderPath);
            SecondaryFolderFiles = Directory.GetFiles(SecondaryFolderPath);
            mainFolderPath = MainFolderPath;
            secondaryFolderPath = SecondaryFolderPath;
        }

        public bool Synchronize()
        {
            bool Success = true;
            try
            {
                foreach (string FilePath in SecondaryFolderFiles)
                {
                    File.Delete(FilePath);
                }

                foreach (string FilePath in MainFolderFiles)
                {
                    string FileName = Path.GetFileName(FilePath);
                    File.Copy(FilePath, secondaryFolderPath + @"\" + FileName);
                }
            }
            catch (Exception)
            {
                Success = false;
            }
            return Success;
        }
        
        public Dictionary<int, string[]> CheckStates()
        {
            MainFolderFiles = Directory.GetFiles(mainFolderPath);
            string[] updatedSecondaryFolderFiles = Directory.GetFiles(secondaryFolderPath);
            string[] addedFiles = Array.Empty<string>();
            string[] deletedFiles = Array.Empty<string>();
            IEnumerable<string> addedFilesCollection = updatedSecondaryFolderFiles.Except(MainFolderFiles);
            IEnumerable<string> deletedFilesCollection = MainFolderFiles.Except(updatedSecondaryFolderFiles);
            List<string> UpdatedFiles = new();
            Dictionary<int, string[]> Result = new();

            if (addedFilesCollection != null)
            {
                addedFiles = (string[])addedFilesCollection;
            }

            if (deletedFilesCollection != null)
            {
                deletedFiles = (string[])deletedFilesCollection;
            }

            foreach(string FilePath in MainFolderFiles)
            {
                string MainFileName = Path.GetFileName(FilePath);
                string SecondaryPath = secondaryFolderPath + @"\" + MainFileName;
                if (File.Exists(SecondaryPath)) {
                    using StreamReader MainFile = new(FilePath);
                    using StreamReader SecondaryFile = new(SecondaryPath);
                    if (MainFile.GetHashCode() != SecondaryFile.GetHashCode())
                    {
                        UpdatedFiles.Add(SecondaryPath);
                    }
                }
            }

            if (addedFiles.Length != 0)
            {
                Result.Add((int)StateCodes.NEW_FILES, addedFiles);
            }

            if (deletedFiles.Length != 0)
            {
                Result.Add((int)StateCodes.DELETED_FILES, deletedFiles);
            }

            if (UpdatedFiles.Count != 0)
            {
                Result.Add((int)StateCodes.UPDATED_FILES, UpdatedFiles.ToArray());
            }
            
            if (Result.Count == 0)
            {
                string[] AllGood = { "Все файлы синхронизированы!" };
                Result.Add((int)StateCodes.UP_TO_DATE, AllGood);
            }

            return Result;
        }
    }
}
